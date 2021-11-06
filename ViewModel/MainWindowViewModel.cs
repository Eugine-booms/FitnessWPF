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
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private User curentUser =new User().GetSomeUser();

        //public MainWindowViewModel()
        //{
        //    curentUser.GetSomeUser();
        //}
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
