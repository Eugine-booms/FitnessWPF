using FitnessWPF.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FitnessWPF.View;


namespace FitnessWPF.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private User _curentUser;

        public User CurentUser
        {
            get => _curentUser;
            set 
            {
                _curentUser = value;
                OnPropertyChanged("CurentUser"); 
            }
        }
        public MainWindowViewModel()
        {
            CurentUser = new User() { Name="nobody"};
            ShowUserChangeViewCommand = new DelegateCommand(UserChange);
            CurentCalories = "s";
        }

        

        private string _curentCalories;

        public string CurentCalories
        {
            get { return _curentCalories; }
            set 
            { 
                _curentCalories = "Всего - потрачено = осталось";
                OnPropertyChanged("CurentCalories");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public ICommand ShowUserChangeViewCommand { get; private set; }
        private void UserChange(object obj)
        {
            CurentUserChangeViewModel vm = new CurentUserChangeViewModel();
            var newUserwindow = new CurrentUserChange() {DataContext=vm };
            newUserwindow.ShowDialog();
            if (newUserwindow.DialogResult==true)
            {
                CurentUser = vm.CurentUser;
            }
        }
    }
}
