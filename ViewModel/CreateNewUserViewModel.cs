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

    public class CreateNewUserViewModel : INotifyPropertyChanged
    {
        private User user;

        public CreateNewUserViewModel()
        {
            this.user = new User();
        }
        public void SetUserName(string Name)
        {
            user.Name = Name;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
