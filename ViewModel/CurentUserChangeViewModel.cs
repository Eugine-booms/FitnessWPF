using FitnessWPF.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FitnessWPF.ViewModel
{
    public class CurentUserChangeViewModel : INotifyPropertyChanged
    {
        private ICollection<User> _users;
        public ICollection<User> Users
        {

            get => _users;
            set
            {
                _users = value;
                OnPropertyChanged("users");
            }

        }
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
        private UserManager _userManager;

        public CurentUserChangeViewModel()
        {
            _userManager = new UserManager();
            _userManager.LoadUsers();
            Users = _userManager.users;
            
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
