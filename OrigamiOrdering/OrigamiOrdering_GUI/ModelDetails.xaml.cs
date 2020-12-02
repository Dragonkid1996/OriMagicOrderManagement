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
        public ModelDetails()
        {
            InitializeComponent();
            RefreshColours();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RefreshColours()
        {
            using (var db = new origamiContext())
            {
                var selectColours =
                    from jt in db.JtModelColours.Include(jt => jt.Colour)
                    where jt.ModelId == Int32.Parse(lblId.Content.ToString())
                    select new { Colour = jt.Colour, Pieces = jt.PiecesOfColour };
                foreach (var item in selectColours)
                {
                    lvColours.Items.Add(new { ColourName = item.Colour, PiecesNo = item.Pieces });
                }
            }
        }
    }
}
