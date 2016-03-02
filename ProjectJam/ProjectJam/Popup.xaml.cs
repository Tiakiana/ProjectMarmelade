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
using ProjectJam.Views;

namespace ProjectJam
{
    /// <summary>
    /// Interaction logic for Popup.xaml
    /// </summary>
    public partial class Popup : Window
    {
        public Navigator Guide = new Navigator();

        public Popup(UserControl viewControl, double width = 350, double height = 500)
        {
            InitializeComponent();

            this.Width = width;
            this.Height = height;

            Guide.ParentWindow = this;
            Guide.Next(viewControl);
        }

    }
}
