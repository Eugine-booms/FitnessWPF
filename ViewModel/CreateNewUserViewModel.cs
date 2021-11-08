using FitnessWPF.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FitnessWPF.ViewModel
{

    public class CreateNewUserViewModel : DependencyObject, INotifyPropertyChanged
    {
        public User User { get; private set; }
        public string Login
        {
            get { return User.Name?? ""; }
            set { User.Name = value; OnPropertyChanged("Login"); }
        }
        private bool _radioButtonMale;

        public bool RadioButtonMale
        {
            get { return _radioButtonMale; }
            set 
            { 
                _radioButtonMale = value;
                if (RadioButtonFeMale && value)
                {
                    RadioButtonFeMale = false;
                }
                OnPropertyChanged("RadioButtonMale");
            }
        }
        private bool _radioButtonFeMale;

        public bool RadioButtonFeMale
        {
            get { return _radioButtonFeMale; }
            set 
            { 
                _radioButtonFeMale = value;
                OnPropertyChanged("RadioButtonFeMale");
                if (RadioButtonMale && value)
                {
                    RadioButtonMale = false;
                }
            }
        }

        public string Password
        {
            get { return (string)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Password.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.Register("Password", typeof(string), typeof(CreateNewUserViewModel), new PropertyMetadata(""));

        
        private string _password2;
        public string Password2
        {
            get { return _password2; }
            set { _password2 = value; OnPropertyChanged("Password2"); }
        }
        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; OnPropertyChanged("Email"); }
        }


        public CreateNewUserViewModel()
        {
            this.User = new User();
            CreateNewUserCommand = new DelegateCommand(CreateNewUser);
        }

        private void CreateNewUser(object obj)
        {
            Gender gender=Gender.Male;
            if (RadioButtonMale)
            {
                gender = Gender.Male;
            }
            else if (RadioButtonFeMale)
                {
                    gender = Gender.Famale;
                }
            
           
            if (CheckParam())
            {
                var user = new User(Login, gender, Password, Email);
                User = user;
            }
        }

        private bool CheckParam()
        {
            //TODO Проверка параметров
            return true;
            throw new NotImplementedException();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        public ICommand CreateNewUserCommand { get; private set; }
    }
}
