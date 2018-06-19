using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    class Message
    {

        private int coco { get;}

        public DateTime pDate { get; set; }

        public int pHours { get; set; }

        public DayOfWeek pDay { get; set; }

        public string pUserName { get; set; }

        private string pMessage { get; set; }


        public Message(DateTime aDate, string aUserName)
        {
            coco = 10;
            pDate = aDate;
            pHours = aDate.Hour;
            pDay = aDate.DayOfWeek;
            pUserName = aUserName;
          
        }


        public string getHelloMessage()
        {
            if (!pDay.Equals(DayOfWeek.Saturday) && !pDay.Equals(DayOfWeek.Sunday))

            {

                if (pHours <= 9 && pDay == DayOfWeek.Monday)
                {
                    pMessage = $"Bon week-end {pUserName}";

                }

                if (pHours > 9 && pHours < 13)
                {
                    pMessage = $"Bonjour {pUserName}";

                }

                if (pHours >= 13 && pHours < 18)
                {
                    pMessage = $"Bon après-midi {pUserName}";

                }

                if (pHours >= 18 && !pDay.Equals(DayOfWeek.Wednesday))
                {
                    pMessage = $"Bonsoir {pUserName}";

                }

                if (pHours >= 18 && pDay.Equals(DayOfWeek.Wednesday))
                {
                    pMessage = $"Bon week-end {pUserName}";

                }

            }
            else if (pDay.Equals(DayOfWeek.Saturday) || pDay.Equals(DayOfWeek.Sunday))
            {

                pMessage = $"Bon week-end {pUserName}";

            }

            return pMessage;

        }

    }
}
