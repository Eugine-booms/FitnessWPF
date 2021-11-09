using FitnessWPF.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using FitnessWPF.ViewModel.Base;

namespace FitnessWPF.ViewModel
{

    internal class CreateNewUserViewModel : ViewModelBase, INotifyPropertyChanged
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
      
    }
}
