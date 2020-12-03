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
            var tryInt = Int32.TryParse(tbPieces.Text, out int resultPieces);
            var tryDec = Decimal.TryParse(tbPrice.Text, out decimal resultPrice);
            if (tbName.Text == "" || tbComplexity.Text == "" || tbPhoto.Text == "")
                MessageBox.Show("Please enter a name and complexity, and give a link to a picture!");
            else if (!tryDec)
                MessageBox.Show("Please enter a valid price (Decimal)!");
            else if (!tryInt)
                MessageBox.Show("Please enter a valid number of pieces (Integer)!");
            else
            {
                _crudManager.CreateModel(tbName.Text, resultPrice, tbComplexity.Text,
                                         resultPieces, tbTutorial.Text, tbPhoto.Text);
                _crudManager.ColoursForModel(_crudManager.ColoursList, tbName.Text, _crudManager.PiecesList);
                MessageBox.Show("Model has been created!");
            }
            
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
            try
            {
                label.Visibility = Visibility.Visible;
                btnSubmitPieces.Visibility = Visibility.Visible;
                tbPieceNo.Visibility = Visibility.Visible;
            }
            catch (Exception) 
            {
                //Left blank intentionally, as the program won't crash on double clicking
                //without selecting an item
            }
        }

        private void btnSubmitPieces_Click(object sender, RoutedEventArgs e)
        {
            var isInt = Int32.TryParse(tbPieceNo.Text, out int pieceNumber);
            if (isInt)
            {
                _crudManager.PiecesList.Add(pieceNumber);
                var colour = _crudManager.GetColourFromName(lbColours.SelectedItem?.ToString());
                _crudManager.ColoursList.Add(colour);

                var piecesToNo = Int32.Parse(tbPieces.Text);
                piecesToNo += pieceNumber;
                tbPieces.Text = piecesToNo.ToString();
            }
            else
                MessageBox.Show("Please enter an integer for number of pieces!");            
            tbPieceNo.Text = "";
            label.Visibility = Visibility.Hidden;
            btnSubmitPieces.Visibility = Visibility.Hidden;
            tbPieceNo.Visibility = Visibility.Hidden;
        }
    }
}
