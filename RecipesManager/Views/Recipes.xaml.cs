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

namespace RecipesManager
{
    /// <summary>
    /// Interaction logic for Recipes.xaml
    /// </summary>
    public partial class Recipes
    {
        public Recipes()
        {
            InitializeComponent();
        }

        private void Recipes_Loaded(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Handles unsaved data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Recipes_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
        }
    }
}
