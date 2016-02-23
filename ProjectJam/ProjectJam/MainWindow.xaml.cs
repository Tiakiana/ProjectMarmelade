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
            tb_ExpectedRes_chng.Text = "";
            cb_approved_chng.IsChecked = false;
            cb_approved.IsChecked = false;
            cb_TestDone.IsChecked = false;
            cb_TestDone_chng.IsChecked = false;
        }
        private void btn_Create_Click(object sender, RoutedEventArgs e)
        {
            Domain.DomainController.getDCT().GetQualityTestController().CreateQualityTest(Int32.Parse(tb_prodID.Text), dt_DatePicker.SelectedDate, tb_TestActivities.Text, tb_ExpectedRes.Text,tb_Employee.Text, null, null);
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
                    dp_datepicker_chng.SelectedDate = DateTime.Parse(b[4]);
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

        private void btn_approveResults_chng_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                Domain.DomainController.getDCT().GetQualityTestController().ChangeAllQualityTest(int.Parse(tb_qualityTestID_chng.Text),
                tb_TestActivities_chng.Text, tb_result_chng.Text, tb_ExpectedRes_chng.Text,
                tb_comment_chng.Text, (DateTime)dp_datepicker_chng.SelectedDate, tb_Employee_chng.Text, (bool)cb_approved_chng.IsChecked, (bool)cb_TestDone_chng.IsChecked);
                resetFields();
                MessageBox.Show("Changes Saved");
            }
            catch (Exception)
            {
                MessageBox.Show("Something Aint Right");
                
            }
            
            

        }

        private void btn_CheckProduction_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Domain.DomainController.getDCT().GetQualityTestController().CheckProduction(Int32.Parse(tb_prodID.Text)))
                {
                    MessageBox.Show("Production exists");
                }
                else
                {
                    MessageBox.Show("Production Does not exist");

                }
            }
            catch (Exception)
            {

                MessageBox.Show("You must enter a valid number. Use only numbers 0-9");
            }
            
        }

        private void btn_Reset_Click(object sender, RoutedEventArgs e)
        {
            resetFields();
        }

        private void btn_Reset2_Click(object sender, RoutedEventArgs e)
        {
            resetFields();
        }
    }
}
