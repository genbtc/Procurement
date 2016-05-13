﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using POEApi.Model;
using Procurement.ViewModel;

namespace Procurement.Controls
{
    public partial class SetBuyoutView : UserControl
    {
        public SetBuyoutView()
        {
            InitializeComponent();
            this.DataContext = new SetBuyoutViewModel();
        }

        public event PricingInfoHandler Update;
        public event SaveImageHandler SaveImageClicked;
        public delegate void PricingInfoHandler(ItemTradeInfo info);
        public delegate void SaveImageHandler();

        public void Save_Clicked(object sender, System.Windows.RoutedEventArgs e)
        {
            var vm = (this.DataContext as SetBuyoutViewModel);
            Update(new ItemTradeInfo(vm.BuyoutInfo.GetSaveText(), vm.PriceInfo.GetSaveText(), vm.OfferInfo.GetSaveText(), vm.Notes));
        }
        private void RemoveBuyout_Click(object sender, RoutedEventArgs e)
        {
            Update(new ItemTradeInfo());
        }

        public void SaveImage_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            SaveImageClicked();
        }

        public void Timestamp_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Notes.Text += DateTime.Now + Environment.NewLine;
        }

        public void SetBuyoutInfo(ItemTradeInfo buyoutInfo)
        {
            (this.DataContext as SetBuyoutViewModel).SetBuyoutInfo(buyoutInfo);
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter)
                return;

            this.Notes.Text += Environment.NewLine;
            this.Notes.CaretIndex = this.Notes.Text.Length;
            e.Handled = true;
        }
    }
}
