using System;
using System.Collections.Generic;
using System.IO;
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

namespace mokup1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string file_name = "mokup.txt";
        
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void greet_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string firstname = txtfirst_name.Text;
                string lastname = txtlast_name.Text;
                var date = dpdate.SelectedDate.Value;
                if (firstname == "" || lastname == "" || date == null)
                     throw new Exception("inserisci i valori mancanti");
                else if (date > DateTime.Now)
                    throw new Exception("Non puoi essere nato nel futuro");
                else
                    MessageBox.Show($"welcome! ti chiami {firstname}, il tuo cognome è {lastname} e sei nato il {date}");
            }catch (Exception ex)
            {
                MessageBox.Show("Non puoi essere nato nel futuro");
                MessageBox.Show("inserisci i valori mancanti");
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            btnPrint.IsEnabled = true;
        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            string firstname = txtfirst_name.Text;
            string lastname = txtlast_name.Text;
            var date = dpdate.SelectedDate.Value;
            try
            {
                using (StreamWriter w = new StreamWriter(file_name, true))
                {
                    w.WriteLine($"{firstname} {lastname} {date}");
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "errore", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
