using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            string wUser = Environment.UserName;
            DateTime wDayTest = new DateTime(2018, 6, 19, 14, 00, 00);

            Message wMessage = new Message(wDayTest, wUser);

            Console.Write(wMessage.getHelloMessage());
            Console.ReadKey();
        }
    }
}
