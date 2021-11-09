using FitnessWPF.Model;
using FitnessWPF.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Forms;
using System.Windows.Input;
using FitnessWPF.ViewModel.Base;

namespace FitnessWPF.ViewModel
{
    internal class CurentUserChangeViewModel : ViewModelBase, INotifyPropertyChanged
    {

        private ICollectionView _users;
        public ICollectionView Users
        {
            get => _users;
            set => Set(ref _users, value);
        }

        
        private string _textBoxLogin;
        public string TextBoxLogin
        {
            get => _textBoxLogin;
            set => Set(ref _textBoxLogin, value);
        }
        private User _curentUser;
        public User CurentUser
        {
            get => _curentUser;
            set => Set(ref _curentUser, value);
            

        }
        public CurentUserChangeViewModel()
        {
            Users = CollectionViewSource.GetDefaultView(UserManager.LoadUsers());
            EnterUserCommand = new DelegateCommand(EnterUser, CanEnterUser);
            NewUserCommand = new DelegateCommand(NewUser);
        }

        private bool CanEnterUser(object arg)
        {
            return (arg as User) != null;
        }
        private void EnterUser(object obg)
        {
            var newUserwindow = new MainWindow();
            var newUserwindowViewModel = new MainWindowViewModel();
            newUserwindow.ShowDialog();

        }
        private void NewUser(object obj)
        {
            var newUserwindow = new CreateNewUser();
            var newUserwindowViewModel = new CreateNewUserViewModel();
            newUserwindow.ShowDialog();
        }

        public ICommand EnterUserCommand { get; private set; }
        public ICommand NewUserCommand { get; private set; }
    }
}
