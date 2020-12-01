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
        public OwnerHome()
        {
            InitializeComponent();
            RefreshModels();
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
            using (var db = new origamiContext())
            {
                var modelList = db.Models.ToList();
                foreach (var item in modelList)
                {
                    this.lvModels.Items.Add(new { Photo = item.LinkToPhoto, Name = item.ModelName });
                }                   
            }
        }
    }
}
