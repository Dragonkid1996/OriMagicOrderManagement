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

namespace OrigamiOrdering_GUI
{
    /// <summary>
    /// Interaction logic for OwnerHome.xaml
    /// </summary>
    public partial class OwnerHome : Page
    {
        CRUDManager _crudManager = new CRUDManager();
        public OwnerHome()
        {
            InitializeComponent();
            RefreshModels();
            RefreshOrders();
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            OriMagicHome oriMagicHome = new OriMagicHome();
            this.NavigationService.Navigate(oriMagicHome);
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            ModelCreation modelCreation = new ModelCreation();
            this.NavigationService.Navigate(modelCreation);
        }

        private void RefreshModels()
        {
            lvModels.Items.Clear();
            var modelList = _crudManager.GetAllModels();
            foreach (var item in modelList)
            {
                this.lvModels.Items.Add(new { Photo = item.LinkToPhoto, Name = item.ModelName });
            } 
        }

        private void RefreshOrders()
        {
            lvOrders.Items.Clear();
            var orders = _crudManager.GetAllOrders();
            foreach (var item in orders)
            {
                this.lvOrders.Items.Add(new { ID = item.OrderId, ModelName =  item.Model.ModelName, Price = item.TotalPrice.ToString("C"), Date = item.OrderDate });
            }
        }

        private void lvModels_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var modelChosen = lvModels.SelectedItem.ToString().Split(',');
                var onlyModel = modelChosen[1].Split('=');
                var modelName = onlyModel[1].Trim();
                modelName = modelName.Remove(modelName.Length - 2, 2);
            
                var model = _crudManager.GetModelFromName(modelName);
                ModelDetails modelDetails = new ModelDetails();
                modelDetails.lblId.Content = model.ModelId.ToString();
                modelDetails.tbName.Text = model.ModelName;
                modelDetails.tbPrice.Text = model.ModelPrice.ToString();            
                modelDetails.tbComplexity.Text = model.ModelComplexity;
                modelDetails.tbPieces.Text = model.ModelPiecesNumber.ToString();
                modelDetails.tbPhoto.Text = model.LinkToPhoto;
                modelDetails.tbTutorial.Text = model.LinkToTutorial;
                modelDetails.RefreshColours();
                modelDetails.ShowDialog();
                RefreshModels();
            }
            catch (Exception)
            {
                //Left blank intentionally, as the program won't crash on double clicking
                //without selecting an item
            }
        }

        private void lvOrders_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var orderChosen = lvOrders.SelectedItem.ToString().Split(',');
                var onlyOrder = orderChosen[0].Split('=');
                var orderId = onlyOrder[1].Trim();

                _crudManager.DeleteOrder(orderId);
                RefreshOrders();
            }            
            catch (Exception)
            {
                //Left blank intentionally, as the program won't crash on double clicking
                //without selecting an item
            }
        }
    }
}
