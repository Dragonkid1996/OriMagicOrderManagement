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

namespace OrigamiOrdering_GUI
{
    /// <summary>
    /// Interaction logic for OriMagicHome.xaml
    /// </summary>
    public partial class OriMagicHome : Page
    {
        public OriMagicHome()
        {
            InitializeComponent();
        }

        private void btnOwner_Click(object sender, RoutedEventArgs e)
        {
            OwnerHome ownerHome = new OwnerHome();
            this.NavigationService.Navigate(ownerHome);
        }

        private void btnCustomer_Click(object sender, RoutedEventArgs e)
        {
            CustomerHome customerHome = new CustomerHome();
            this.NavigationService.Navigate(customerHome);
        }
    }
}
