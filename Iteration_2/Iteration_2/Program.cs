using System.Collections.Generic;
using System.Drawing;
using Console = Colorful.Console;
using MetroLibrary;
using Newtonsoft.Json.Linq;

namespace Iteration_2
{
    class Program
    {
        static void Main(string[] args)
        {
            MetroApi metroApi = new MetroApi();

            List<Lines> resultGetLine = metroApi.getLines();

            List<string> lineWithoutDuplicate = new List<string>();


            foreach (Lines line in resultGetLine)
            {
                Console.BackgroundColor = Color.White;
                Console.ForegroundColor = Color.Black;

                if (!lineWithoutDuplicate.Contains(line.id))
                {
                    Console.WriteLine($"Identifiant de l'arret la ligne : {line.id}");
                    Console.WriteLine($"Nom de l''arret : {line.name}");
                    lineWithoutDuplicate.Add(line.id);
                }

                List<string> lineIdNameWithoutDuplicate = new List<string>();

                foreach (string lineIdName in line.lines)
                {
                    if (!lineIdNameWithoutDuplicate.Contains(lineIdName))
                    {
                        lineIdNameWithoutDuplicate.Add(lineIdName);

                        List<LinesDescription> resultDescriptionOfLine = metroApi.getDescriptionOfLine(lineIdName);

                        foreach (LinesDescription lnDesc in resultDescriptionOfLine)
                        {

                            var colorback = System.Drawing.ColorTranslator.FromHtml($"#{lnDesc.color}");

                            Console.ForegroundColor = colorback;
                            Console.WriteLine($"Nom de la ligne (id) : {lineIdName} ===>  Nom de la ligne : {lnDesc.longName} ==> Nom court de la ligne : {lnDesc.shortName} ==> Type de la ligne: {lnDesc.mode} ");
                            Console.ForegroundColor = Color.Black;
                        }

                    }
                }

                Console.WriteLine();
            }


            //////////////////TEST/////////////////////
            string testJObjet = metroApi.getLinesJSON();

            string test2JObjet = metroApi.getGetFeaturesJSON("SEM:A");

            string test3JObjet = metroApi.getDescriptionOfLineJSON("SEM:A");



            Console.WriteLine(testJObjet);
            Console.WriteLine();


            Console.WriteLine(test2JObjet);
            Console.WriteLine();


            Console.WriteLine(test3JObjet);
            Console.WriteLine();

            

            Console.Read();

        }
    }
}
