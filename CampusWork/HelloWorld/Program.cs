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
            Program wProg = new Program();
            wProg.startProg();

        }



        public void startProg()
        {

            string wUser = Environment.UserName;

            DateTime wDayTest = new DateTime(2018, 6, 25, 8, 00, 00);

            Message wMessage = new Message(wDayTest, wUser);
           

            String wAnswer;

            do
            {
                Console.WriteLine(wMessage.getHelloMessage());
                wAnswer = Console.ReadLine();

            }
            while (wAnswer != "exit");

        }
    }
}
