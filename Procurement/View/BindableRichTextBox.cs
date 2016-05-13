using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace Procurement.View
{
    public class BindableRichTextBox : RichTextBox
    {
        public static readonly DependencyProperty DocumentProperty = DependencyProperty.Register("Document", typeof(FlowDocument), typeof(BindableRichTextBox), new FrameworkPropertyMetadata(null, new PropertyChangedCallback(OnDocumentChanged)));

        public new FlowDocument Document
        {
            get
            {
                return (FlowDocument)this.GetValue(DocumentProperty);
            }

            set
            {
                this.SetValue(DocumentProperty, value);
            }
        }

        public static void OnDocumentChanged(DependencyObject obj,
            DependencyPropertyChangedEventArgs args)
        {
            RichTextBox rtb = (RichTextBox)obj;
            rtb.Document = args.NewValue as FlowDocument ?? new FlowDocument();
        }
    }

    public class BindableRichTextBoxString : RichTextBox
    {

        public String Text
        {
            get { return (String)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public static DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(String), typeof(BindableRichTextBoxString),new PropertyMetadata(OnDocumentChanged));

        public static void OnDocumentChanged(DependencyObject obj,
            DependencyPropertyChangedEventArgs args)
        {
            var rtf = obj as BindableRichTextBoxString;
            if (rtf == null)
                return;
            if (args.NewValue == null)
                rtf.Document = new FlowDocument(); //Document is not amused by null

            ReadText(rtf.Text, rtf.Document);

        }
        private static void ReadText(string thestring, FlowDocument inFlowDocument)
        {
            if (inFlowDocument == null)
                inFlowDocument = new FlowDocument();
            if (thestring == null) 
                return;
            using (var reader = new StringReader(thestring))
            {
                string newLine;
                while ((newLine = reader.ReadLine()) != null)
                {
                    var paragraph = new Paragraph(new Run(newLine))
                    {
                        Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0xAB, 0x90, 0x66)),
                        FontWeight = FontWeights.Bold
                    };
                    inFlowDocument.Blocks.Add(paragraph);
                }
            }
        }
    }


}
