using HomeOffice.Calendar.Models;
using HomeOffice.Calendar.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HomeOffice.Calendar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel _viewModel;

        public List<HomeOfficeInfo> DatabaseHomeOfficeList { get;  set; }

        public MainWindow()
        {
            InitializeComponent();

            _viewModel = new MainWindowViewModel();

            DataContext = _viewModel;

            ItemList.ItemsSource = _viewModel.ItemListTable;
            ItemList.SelectedItem = _viewModel.SelectedItemTable;

        }

        private void PreviewOnlyNumber(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
