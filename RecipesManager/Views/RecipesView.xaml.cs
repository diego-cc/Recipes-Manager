﻿using RecipesData.Setup;
using RecipesManager.ViewModels;
using RecipesManager.ViewModels.Services;
using System;
using System.Windows.Controls;

namespace RecipesManager.Views
{
    /// <summary>
    /// Interaction logic for RecipesView.xaml
    /// </summary>
    public partial class RecipesView : UserControl, IViewRecipesViewModel
    {
        public RecipesView(IViewRecipesViewModel recipesViewModel)
        {
            InitializeComponent();
            DataContext = recipesViewModel;
        }

        public RecipesView()
        {
            InitializeComponent();
        }
    }
}
