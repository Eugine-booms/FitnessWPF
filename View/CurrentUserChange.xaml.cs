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
using System.Windows.Shapes;

namespace FitnessWPF.View
{
    /// <summary>
    /// Логика взаимодействия для CurrentUserChenge.xaml
    /// </summary>
    public partial class CurrentUserChange : Window
    {
        public CurrentUserChange()
        {
            InitializeComponent();
            Loaded += CurrentUserChange_Loaded;
        }

        private void CurrentUserChange_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = new CurentUserChangeViewModel();
        }
    }
}
