﻿using System;
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
    /// Interaction logic for Screen.xaml
    /// </summary>
    public partial class Screen : Window
    {
        public Navigator Guide = new Navigator();
        public Screen()
        {
            InitializeComponent();
            Startup();
        }

        private void Startup()
        {
            // Instantiate Parent window for navigator
            Guide.ParentWindow = this;

            Guide.Next(new PlanView());
        }
    }
}