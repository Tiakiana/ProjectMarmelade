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

namespace ProjectJam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Domain.DomainController.getDCT().onStart("M1");
        }
        private void resetFields()
        {
            tb_prodID.Text = "";
            dt_DatePicker.Text = "";
            tb_TestActivities.Text = "";
            tb_ExpectedRes.Text = "";
            tb_Employee.Text = "";
            tb_comment.Text = "";
            tb_comment_chng.Text = "";
            tb_Employee_chng.Text = "";
            tb_qualityTestID.Text = "";
            tb_qualityTestID_chng.Text = "";
            tb_result.Text = "";
            tb_result_chng.Text = "";
            tb_TestActivities_chng.Text = "";
            Txt_boxQualityTest.Text = "";
            Txt_boxReturnMsg_chng.Text = "";
        }
        private void btn_Create_Click(object sender, RoutedEventArgs e)
        {
            DateTime? date = dt_DatePicker.SelectedDate;
            Domain.DomainController.getDCT().GetQualityTestController().CreateQualityTest(Int32.Parse(tb_prodID.Text), dt_DatePicker.DisplayDate, tb_TestActivities.Text, tb_ExpectedRes.Text,tb_Employee.Text, null, null);
            resetFields();
        }

        private void btn_getQualityTest_Click(object sender, RoutedEventArgs e)
        {
            int a = 0;
            string b = null;
            try
            {
                a = int.Parse(tb_qualityTestID.Text);
                try
                {
                    b = Domain.DomainController.getDCT().GetQualityTestController().GetQualityTest(a);
                }
                catch (Exception)
                {
                    MessageBox.Show("The quality test does not exist");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please type in an ID not a sentence");
            }

            Txt_boxQualityTest.Text = b;
        }

        private void btn_storeResult_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                Domain.DomainController.getDCT().GetQualityTestController().ChangeQualityTest((bool)cb_TestDone.IsChecked,(bool)cb_approved.IsChecked,tb_result.Text, tb_comment.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("You did something wrong!");
            }
            MessageBox.Show("The result has been saved");
            resetFields();
        }

        private void btn_getQualityTest_chng_Click(object sender, RoutedEventArgs e)
        {
            int a = 0;
            string[] b = null;
            try
            {
                a = int.Parse(tb_qualityTestID_chng.Text);
                try
                {
                    b = Domain.DomainController.getDCT().GetQualityTestController().GetQualityTestAsArray(a);
                    tb_result_chng.Text = b[0];
                    tb_TestActivities_chng.Text = b[1];
                    tb_comment_chng.Text = b[2];
                    tb_ExpectedRes_chng.Text = b[3];
                    //dt_DatePicker.SelectedDate = b[4];
                    cb_approved_chng.IsChecked = Boolean.Parse(b[5]);
                    cb_TestDone_chng.IsChecked = Boolean.Parse(b[6]);
                    tb_Employee_chng.Text = b[7];
                }
                catch (Exception)
                {
                    MessageBox.Show("The quality test does not exist");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please type in an ID not a sentence");
            }

          
        }

       

    }
}
