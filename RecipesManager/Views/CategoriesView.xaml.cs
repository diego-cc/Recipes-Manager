﻿using RecipesManager.ViewModels.Services;
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

namespace RecipesManager.Views
{
    /// <summary>
    /// Interaction logic for CategoriesView.xaml
    /// </summary>
    public partial class CategoriesView : UserControl, IViewCategoriesViewModel
    {
        public CategoriesView(IViewCategoriesViewModel categoriesViewModel)
        {
            InitializeComponent();
            DataContext = categoriesViewModel;
        }

        public CategoriesView()
        {
            InitializeComponent();
        }
    }
}
