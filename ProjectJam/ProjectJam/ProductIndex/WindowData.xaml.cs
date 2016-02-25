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

namespace View
{
    /// <summary>
    /// Interaction logic for WindowData.xaml
    /// </summary>
    public partial class WindowData : Window
    {
        public WindowData(string s)
        {
            InitializeComponent();
            ShowData(s);
        }
        public void ShowData(string s)
        {
            s = s.Replace(";", System.Environment.NewLine);                      
            label_Data.Content = s;
        }
    }
}
