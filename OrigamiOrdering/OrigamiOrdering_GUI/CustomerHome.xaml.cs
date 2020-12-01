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
            using (var db = new origamiContext())
            {
                var modelList = db.Models.ToList();
                foreach (var item in modelList)
                {
                    this.lvModels.Items.Add(new { Photo = LoadImage(item.LinkToPhoto.ToString()), Name = item.ModelName, Price = item.ModelPrice });
                }
            }
        }

        private BitmapImage LoadImage(string fileName)
        {
            var source = new BitmapImage(new Uri(Directory.GetCurrentDirectory()+ @"..\..\..\..\..\OrigamiImages/" + fileName));
            source.DecodePixelHeight = 100;
            source.DecodePixelWidth = 100;

            return source;
        }
    }
}
