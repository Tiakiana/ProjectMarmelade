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
using ProjectJam.Controllers;


namespace ProjectJam.Views
{
    /// <summary>
    /// Interaction logic for AddResourceView.xaml
    /// </summary>
    public partial class AddResourceView : UserControl
    {
        public AddResourceView()
        {
            InitializeComponent();
        }

        private void buttonAccept_Click(object sender, RoutedEventArgs e)
        {
            if (textboxName.Text.Length > 0 && textboxType.Text.Length > 0 && textboxPrice.Text.Length > 0)
            {
                double price = -1;
                try
                {
                    price = Convert.ToDouble(textboxPrice.Text);
                    if (price > 0)
                    {
                        DataFactory.AddResource(textboxName.Text, textboxType.Text, price);
                        Destroy();
                    }
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.Message);
                }
            }
        }

        private void Destroy()
        {
            Window parent = Window.GetWindow(this);
            parent.Close();
        }
    }
}
