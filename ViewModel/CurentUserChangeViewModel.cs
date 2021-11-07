﻿using FitnessWPF.Model;
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

namespace FitnessWPF.ViewModel
{
    public class CurentUserChangeViewModel : DependencyObject, INotifyPropertyChanged
    {
        public string Filtertext
        {
            get { return (string)GetValue(FiltertextProperty); }
            set 
            { 
                SetValue(FiltertextProperty, value);
                OnPropertyChanged("Filtertext");
            }
        }

        // Using a DependencyProperty as the backing store for Filtertext.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FiltertextProperty =
            DependencyProperty.Register("Filtertext", typeof(string), typeof(CurentUserChangeViewModel), new PropertyMetadata("", FilterText_Changed));

        private static void FilterText_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var curent = d as CurentUserChangeViewModel;
            if (curent != null)
            {
                curent.Users.Filter = null;
                curent.Users.Filter = curent.FilterUsers;
            }
        }

        public ICollectionView Users
        {
            get { return (ICollectionView)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Items.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register("Items", typeof(ICollectionView), typeof(CurentUserChangeViewModel), new PropertyMetadata(null));
        //public ObservableCollection<User> Users { get; private set; }

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
        public CurentUserChangeViewModel()
        {
            Users = CollectionViewSource.GetDefaultView(UserManager.LoadUsers());
            //Users = new ObservableCollection<User>(UserManager.LoadUsers());
            EnterUserCommand = new DelegateCommand(EnterUser, CanEnterUser);
            NewUserCommand = new DelegateCommand(NewUser);
            Users.Filter = FilterUsers;
        }

        private bool FilterUsers(object obj)
        {
            bool result = true;
            var curent = obj as User;
            if (curent!=null  && !curent.Name.Contains(Filtertext))
            {
                result = false;
            }
            if (CurentUser != null)
            {
                Filtertext = CurentUser.Name;
            }
            else
            {
                foreach (User item in Users)
                {
                    if (Filtertext == item.Name)
                    {
                        CurentUser = item;
                        break;
                    }
                }
            }
           return result;
        }

        private bool CanEnterUser(object arg)
        {
            return (arg as User) != null;
        }

        private void NewUser(object obj)
        {
            var newUserwindow = new CreateNewUser();
            var newUserwindowViewModel = new CreateNewUserViewModel();
            newUserwindow.ShowDialog();
        }

        private void EnterUser(object obg)
        {
            var newUserwindow = new MainWindow();
            var newUserwindowViewModel = new MainWindowViewModel();
            newUserwindow.ShowDialog();

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public ICommand EnterUserCommand { get; private set; }
        public ICommand NewUserCommand { get; private set; }
    }
}
