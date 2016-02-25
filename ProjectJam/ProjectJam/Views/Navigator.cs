using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ProjectJam.Views
{
    class Navigator
    {
        public Window ParentWindow { get; set; }

        private UserControl currentView;
        private UserControl previousView;

        public void Next(UserControl view)
        {
            // Verify Parent window exist
            VerifyParent();

            if (currentView == null)
            {
                currentView = view;
            }
            else
            {
                previousView = currentView;
                currentView = view;
            }

            ParentWindow.Content = view;
        }

        /// <summary>
        /// Go back to previous UserControl
        /// This do only one record usercontrol, which mean it can only go one step back
        /// </summary>
        public void Back()
        {
            VerifyParent();
            if (previousView != null)
            {
                UserControl temp = previousView;
                previousView = currentView;
                currentView = temp;

                ParentWindow.Content = currentView;
            }
        }

        private void VerifyParent()
        {
            if (ParentWindow == null)
            {
                throw new MissingFieldException("ParentWindow is require before calling Next() or Back() method");
            }
        }
    }
}
