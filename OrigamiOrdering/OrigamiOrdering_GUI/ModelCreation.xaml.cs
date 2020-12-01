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
    /// Interaction logic for ModelCreation.xaml
    /// </summary>
    public partial class ModelCreation : Page
    {
        public ModelCreation()
        {
            InitializeComponent();
            RefreshColours();
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            OriMagicHome oriMagicHome = new OriMagicHome();
            this.NavigationService.Navigate(oriMagicHome);
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RefreshColours() 
        {
            using(var db = new origamiContext())
            {
                lbColours.ItemsSource = null;
                var colourList = db.Colours.Select(c => c.Colour1).ToList();
                lbColours.ItemsSource = colourList;
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            OwnerHome ownerHome = new OwnerHome();
            this.NavigationService.Navigate(ownerHome);
        }
    }
}
