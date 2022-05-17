using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static ChrisCurran_S00210475_Final_Exam.RentalProperty;

namespace ChrisCurran_S00210475_Final_Exam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<RentalProperty> allProperties = new List<RentalProperty>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PropertyDetails db = new PropertyDetails();
            var query = from p in db.Properties
                        orderby p.Price
                        select p;
            allProperties = query.ToList();
            lbxListings.ItemsSource = allProperties;
        }

        private void lbxListings_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RentalProperty selected = lbxListings.SelectedItem as RentalProperty;
            if (selected != null)
            {
                tblkDescription.Text = selected.Description;
            }
        }
    }
}
