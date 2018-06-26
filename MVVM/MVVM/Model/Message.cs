using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Model
{
    class Message
    {
        public string pMessage { get; set; }
        
        public User pDestinataire { get; set; }

        public User pExpediteur { get; set; }


        public Message() { }

        public Message(User aDestinataire, User aExpediteur, string aMessage)
        {
            pDestinataire = aDestinataire;
            pExpediteur = aExpediteur;
            pMessage = aMessage;
        }
    }
}
