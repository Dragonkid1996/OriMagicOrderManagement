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
using System.Windows.Shapes;
using OrigamiOrdering;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace OrigamiOrdering_GUI
{
    /// <summary>
    /// Interaction logic for ModelDetails.xaml
    /// </summary>
    public partial class ModelDetails : Window
    {
        CRUDManager _crudManager = new CRUDManager();
        public ModelDetails()
        {
            InitializeComponent();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            _crudManager.DeleteModel(tbName.Text);
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            btnDelete.Visibility = Visibility.Hidden;
            btnUpdate.Visibility = Visibility.Hidden;
            btnSubmit.Visibility = Visibility.Visible;
            tbPrice.IsEnabled = true;
            tbComplexity.IsEnabled = true;
            tbPieces.IsEnabled = true;
            tbTutorial.IsEnabled = true;
            tbPhoto.IsEnabled = true;
        }

        public void RefreshColours()
        {
            var isInt = Int32.TryParse(lblId.Content.ToString(), out int idToInt);
            if (!isInt)
                MessageBox.Show("Please enter an integer!");
            else
            {
                using (var db = new origamiContext())
                {
                    var selectColours =
                        from jt in db.JtModelColours.Include(jt => jt.Colour)
                        where jt.ModelId == idToInt
                        select new {ID = jt.IndexId, Colour = jt.Colour.Colour1, Pieces = jt.PiecesOfColour };

                    foreach (var item in selectColours)
                    {
                        lvColours.Items.Add(new {ID = item.ID, ColourName = item.Colour, PiecesNo = item.Pieces });
                    }
                }
            }                        
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            var isDec = Decimal.TryParse(tbPrice.Text, out decimal price);
            var isInt = Int32.TryParse(tbPieces.Text, out int pieces);

            if (tbComplexity.Text == "" || tbPhoto.Text == "")
                MessageBox.Show("Please enter a complexity and photo link!");
            else if (!isDec)
                MessageBox.Show("Please enter a valid price (Decimal)!");
            else if (!isInt)
                MessageBox.Show("Please enter a valid total number of pieces (Integer)!");
            else
            {
                btnDelete.Visibility = Visibility.Visible;
                btnSubmit.Visibility = Visibility.Hidden;

                _crudManager.UpdateModel(tbName.Text, price, tbComplexity.Text,
                                        pieces, tbTutorial.Text, tbPhoto.Text);
                this.Close();
            }
            
        }

        private void tbTutorial_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
