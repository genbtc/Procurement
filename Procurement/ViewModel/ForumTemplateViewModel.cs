using System.ComponentModel;
using Procurement.Controls;

namespace Procurement.ViewModel
{
    internal class ForumTemplateViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ForumTemplateViewModel()
        {
            this.Text = ForumExportTemplateReader.GetTemplate(null);
            ForumExportTemplateReader.OnTemplateReloaded += new PropertyChangedEventHandler(ForumExportTemplateReader_OnTemplateReloaded);
        }

        void ForumExportTemplateReader_OnTemplateReloaded(object sender, PropertyChangedEventArgs e)
        {
            this.Text = sender.ToString();
        }

        private void onPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        private string text;
        public string Text
        {
            get { return text; }
            set
            {
                text = value;
                onPropertyChanged("Text");
            }
        }

        internal void Save()
        {
            ForumExportTemplateReader.SaveTemplate(Text);
        }
    }
}
