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
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            OriMagicHome oriMagicHome = new OriMagicHome();
            this.NavigationService.Navigate(oriMagicHome);
        }

        private void RefreshModels()
        {
            var modelList = _crudManager.GetAllModels();
            foreach (var item in modelList)
            {
                this.lvModels.Items.Add(new { Photo = LoadImage(item.LinkToPhoto.ToString()), Names = item.ModelName, Price = item.ModelPrice });
            }
        }

        private void RefreshBasket()
        {
            lbBasket.ItemsSource = null;
            foreach (var item in _crudManager.Basket)
            {
                lbBasket.Items.Add(item.ModelName);
            }
            
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
            var chosen = sender as ListBox;
            var modelChosen = chosen.SelectedItem.ToString();
            var model = _crudManager.GetModelFromName(modelChosen);
            _crudManager.Basket.Add(model);
            RefreshBasket();
        }

        private void btnBuy_Click(object sender, RoutedEventArgs e)
        {
            _crudManager.CreateOrder(_crudManager.Basket, Int32.Parse(lblPrice.Content.ToString()));
        }
    }
}
