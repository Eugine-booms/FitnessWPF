using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessWPF.Model
{
   public class UserManager
    {
        private readonly IDataSaver dataSaver = new SerializationSaver();
        public ICollection<User> users { get; set; }
        public void LoadUsers()
        {
           var  users = dataSaver.Load<User>();
           this.users = users;
            
        }
        public void SaveUsers()
        {
            dataSaver.Save(users.ToList());
        }
    }
}
