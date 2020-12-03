using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OrigamiOrdering;
using System.Linq;
using System.IO;

namespace OrigamiOrdering_GUI
{
    /// <summary>
    /// Interaction logic for CustomerHome.xaml
    /// </summary>
    public partial class CustomerHome : Page
    {
        CRUDManager _crudManager = new CRUDManager();
        public CustomerHome()
        {
            InitializeComponent();
            RefreshModels();
            lblPrice.Content = "0.00";
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            _crudManager.Basket = null;
            OriMagicHome oriMagicHome = new OriMagicHome();
            this.NavigationService.Navigate(oriMagicHome);
        }

        private void RefreshModels()
        {
            var modelList = _crudManager.GetAllModels();
            foreach (var item in modelList)
            {
                this.lvModels.Items.Add(new { Photo = item.LinkToPhoto, Names = item.ModelName, Price = item.ModelPrice });
            }
        }

        private void RefreshBasket()
        {
            lbBasket.ItemsSource = null;
            lbBasket.Items.Clear();
            foreach (var item in _crudManager.Basket)
            {
                lbBasket.Items.Add(item.ModelName);
            }
            lblPrice.Content = _crudManager.GetTotalPrice().ToString("F");
        }

        public BitmapImage LoadImage(string fileName)
        {
            var source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + @"..\..\..\..\..\OrigamiImages/" + fileName));
            source.DecodePixelHeight = 100;
            source.DecodePixelWidth = 100;

            return source;
        }

        private void lvModels_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try 
            {
                var modelChosen = lvModels.SelectedItem.ToString().Split(',');
                var onlyModel = modelChosen[1].Split('=');
                var modelName = onlyModel[1].Trim();
                var model = _crudManager.GetModelFromName(modelName);
                _crudManager.Basket.Add(model);
                RefreshBasket();
            }
            catch (Exception) 
            {
                //Left blank intentionally, as the program won't crash on double clicking
                //without selecting an item
            }            
        }

        private void btnBuy_Click(object sender, RoutedEventArgs e)
        {
            bool isDec = Decimal.TryParse(lblPrice.Content.ToString(), out decimal result);
            if (isDec)
                _crudManager.CreateOrder(_crudManager.Basket, result);
            else
                MessageBox.Show("Please enter a number!");
            MessageBox.Show("Order has been placed!");
        }

        private void lbBasket_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                _crudManager.RemoveFromBasket(lbBasket.SelectedItem.ToString());
                RefreshBasket();
            }
            catch (Exception) 
            {
                //Left blank intentionally, as the program won't crash on double clicking
                //without selecting an item
            }
        }
    }
}
