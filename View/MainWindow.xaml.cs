using FitnessWPF.ViewModel;
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

namespace FitnessWPF.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
            DataContext = new MainWindowViewModel();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = new MainWindowViewModel();
        }

        private void MenuUser_Click(object sender, RoutedEventArgs e)
        {

        }
        private void MenuExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
