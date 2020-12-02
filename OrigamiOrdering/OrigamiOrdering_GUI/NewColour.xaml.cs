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

namespace OrigamiOrdering_GUI
{
    /// <summary>
    /// Interaction logic for NewColour.xaml
    /// </summary>
    public partial class NewColour : Window
    {
        CRUDManager _crudManager = new CRUDManager();
        public NewColour()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            _crudManager.CreateColour(tbColour.Text);            
            this.Close();
        }
    }
}
