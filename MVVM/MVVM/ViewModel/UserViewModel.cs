using MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.ViewModel
{
     class UserViewModel : BaseViewModel
    {

        public User pUser { get; set; }

        public ObservableCollection<User> pUsers { get; set; }

        public UserViewModel()
        {
            LoadUsers();
        }

        public void LoadUsers()
        {
            ObservableCollection<User> wUsers = new ObservableCollection<User>();

            wUsers.Add(new User { pFirstName = "Mark", pLastName = "Allain" , pEmail = "mark.A@toto.com"});
            wUsers.Add(new User { pFirstName = "Allen", pLastName = "Brown" , pEmail = "allen.B@toto.com" });
            wUsers.Add(new User { pFirstName = "Linda", pLastName = "Hamerski" , pEmail = "linda.H@toto.com" });

            pUsers = wUsers;
        }

    }
}
