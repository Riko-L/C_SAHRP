using MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.ViewModel
{
    class MessageViewModel : BaseViewModel
    {

        public Message pMessage { get; set; }

        public ObservableCollection<User> pUsers { get; set; }

        public ObservableCollection<Message> pMessages { get; set; }


        public MessageViewModel()
        {
            pMessages = new ObservableCollection<Message>();
            LoadUsers();

        }


        public void setMessage(User aDestinataire, User aExpediteur, string aMessage)
        {
            if (aDestinataire != null && aExpediteur != null && aMessage != null)
            {
                Message pMessage = new Message(aDestinataire, aExpediteur, aMessage);

                pMessages.Add(pMessage);
            }
        }



        public void LoadUsers()
        {
            ObservableCollection<User> wUsers = new ObservableCollection<User>();

            wUsers.Add(new User { pFirstName = "Mark", pLastName = "Allain", pEmail = "mark.A@toto.com" });
            wUsers.Add(new User { pFirstName = "Allen", pLastName = "Brown", pEmail = "allen.B@toto.com" });
            wUsers.Add(new User { pFirstName = "Linda", pLastName = "Hamerski", pEmail = "linda.H@toto.com" });

            pUsers = wUsers;
        }
    }
}
