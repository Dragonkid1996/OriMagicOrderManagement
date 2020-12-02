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
        CRUDManager _crudManager = new CRUDManager();

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
            _crudManager.CreateModel(tbName.Text, Int32.Parse(tbPrice.Text), tbComplexity.Text,
                                     Int32.Parse(tbPieces.Text), tbTutorial.Text, tbPhoto.Text);
            _crudManager.ColoursForModel(_crudManager.ColoursList, tbName.Text, _crudManager.PiecesList);
        }

        public void RefreshColours() 
        {
            var colourList = _crudManager.GetAllColourNames();
            lbColours.ItemsSource = null;
            lbColours.ItemsSource = colourList;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            OwnerHome ownerHome = new OwnerHome();
            this.NavigationService.Navigate(ownerHome);
        }

        private void btnColour_Click(object sender, RoutedEventArgs e)
        {
            NewColour newColour = new NewColour();
            newColour.ShowDialog();
            RefreshColours();
        }

        private void lbColours_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            label.Visibility = Visibility.Visible;
            btnSubmitPieces.Visibility = Visibility.Visible;
            tbPieceNo.Visibility = Visibility.Visible;
        }

        private void btnSubmitPieces_Click(object sender, RoutedEventArgs e)
        {
            var pieceNumber = Int32.Parse(tbPieceNo.Text);
            var colour = _crudManager.GetColourFromName(lbColours.SelectedItem?.ToString());
            _crudManager.PiecesList.Add(pieceNumber);
            _crudManager.ColoursList.Add(colour);
            tbPieceNo.Text = "";
            label.Visibility = Visibility.Hidden;
            btnSubmitPieces.Visibility = Visibility.Hidden;
            tbPieceNo.Visibility = Visibility.Hidden;
        }
    }
}
