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
using System.Windows.Shapes;
using static ChrisCurran_S00210475_Final_Exam.RentalProperty;

namespace ChrisCurran_S00210475_Final_Exam
{
    /// <summary>
    /// Interaction logic for PropertyAdd.xaml
    /// </summary>
    public partial class PropertyAdd : Window
    {
        public PropertyAdd()
        {
            InitializeComponent();
            cmbTypeOfRental.Items.Add("Flat"); //Sets the combo box values
            cmbTypeOfRental.Items.Add("House");
            cmbTypeOfRental.Items.Add("Share");
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PropertyDetails db = new PropertyDetails();
                using (db)
                {
                    RentalProperty newEntry = new RentalProperty() { Location = tbxLocation.Text, Price = Convert.ToDecimal(tbxPrice.Text), Description = tblkDescription.Text, TypeOfRental = cmbTypeOfRental.SelectedItem.ToString(), PropertyImage = "/images/" + cmbTypeOfRental.SelectedValue.ToString().ToLower() + ".png"};
                    db.Properties.Add(newEntry); //Adds the new entry
                    db.SaveChanges(); //Saves the added property to the database
                    MessageBox.Show("Property Added");
                    ((MainWindow)Application.Current.MainWindow).lbxListings.Items.Refresh(); //Refreshes listbox when saved
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("The following error has occurred: " + err.Message); //Catches any errors such as non inputted fields
            }
        }
    }
}
