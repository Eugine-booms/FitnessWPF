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
    internal class MainWindowViewModel : ViewModelBase
    {
        private User curentUser =new User().GetSomeUser();

        //public MainWindowViewModel()
        //{
        //    curentUser.GetSomeUser();
        //}
        
    }
}
