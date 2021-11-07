using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessWPF.Model
{
   public static class UserManager
    {
        private static readonly IDataSaver dataSaver = new SerializationSaver();
        //public ICollection<User> users { get; set; }
        public static ICollection<User> LoadUsers()
        {
           var  users = dataSaver.Load<User>();
           return users;
            
        }
        public static void SaveUsers(ICollection<User> users)
        {
            dataSaver.Save(users.ToList());
        }
    }
}
