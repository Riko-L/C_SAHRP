using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    class Message
    {

        public DateTime pDate { get; set; }

        public int pHours { get; set; }

        public DayOfWeek pDay { get; set; }

        public string pUserName { get; set; }

        public string pMessage { get; set; }

        public int pLimitHoursMorning { get; set; }

        public int pLimitHoursAfternoon { get; set; }

        public int pLimitHoursEvening { get; set; }



        public Message(DateTime aDate, string aUserName, int aLimitHoursMorning = 9, int aLimitHoursAfternoon = 13, int aLimitHoursEvening = 18)
        {

            pDate = aDate;
            pHours = aDate.Hour;
            pDay = aDate.DayOfWeek;
            pUserName = aUserName;
            pLimitHoursMorning = aLimitHoursMorning;
            pLimitHoursAfternoon = aLimitHoursAfternoon;
            pLimitHoursEvening = aLimitHoursEvening;
        }

        public Message()
        {

        }


        public string getHelloMessage()
        {

            if ((pDay.Equals(DayOfWeek.Saturday) || pDay.Equals(DayOfWeek.Sunday))
                         || (pHours < pLimitHoursMorning && pDay == DayOfWeek.Monday)
                         || (pHours >= pLimitHoursEvening && pDay.Equals(DayOfWeek.Friday)))
            {

                pMessage = $"Bon week-end {pUserName}";

            }
            else if (pHours >= pLimitHoursMorning && pHours < pLimitHoursAfternoon)
            {
                pMessage = $"Bonjour {pUserName}";

            }

            else if (pHours >= pLimitHoursAfternoon && pHours < pLimitHoursEvening)
            {
                pMessage = $"Bon après-midi {pUserName}";

            }

            else
            {
                pMessage = $"Bonsoir {pUserName}";

            }
            return pMessage;

        }

    }
}

