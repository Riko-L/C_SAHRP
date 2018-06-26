using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Model
{
    /// <summary>
    /// Initializes a new instance of the User class 
    /// </summary>
    class User
    {
        public string pFirstName { get; set; }
        public string pLastName { get; set; }
        public string pEmail { get; set; }

        public User() { }

        public User(string aFirstName, string aLastName, string aEmail)
        {
            pFirstName = aFirstName;
            pLastName = aLastName;
            pEmail = aEmail;
        }

        public string getFullName()
        {
            return $"{pFirstName} {pLastName}";
        }
    }
}
