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


            List<StopLines> resultGetLine = metroApi.getStopLines();




            foreach (StopLines line in resultGetLine)
            {
                Console.BackgroundColor = Color.White;
                Console.ForegroundColor = Color.Black;

                Console.WriteLine($"Identifiant de l'arret la ligne : {line.id}");
                Console.WriteLine($"Nom de l''arret : {line.name}");

                List<string> lineIdNameWithoutDuplicate = new List<string>();

                foreach (string lineIdName in line.lines)
                {
                    if (!lineIdNameWithoutDuplicate.Contains(lineIdName))
                    {
                        lineIdNameWithoutDuplicate.Add(lineIdName);

                        List<LinesDescription> resultDescriptionOfLine = metroApi.getInforamtionsOfLine(lineIdName);

                        foreach (LinesDescription lnDesc in resultDescriptionOfLine)
                        {

                            var colorback = ColorTranslator.FromHtml($"#{lnDesc.color}");

                            Console.ForegroundColor = colorback;
                            Console.WriteLine($"Nom de la ligne (id) : {lineIdName} ===>  Nom de la ligne : {lnDesc.longName} ==> Nom court de la ligne : {lnDesc.shortName} ==> Type de la ligne: {lnDesc.mode} ");
                            Console.ForegroundColor = Color.Black;
                        }

                    }
                }

                Console.WriteLine();
            }


            //////////////////TEST/////////////////////
            List<string> stops = metroApi.getGetStopZone("SEM:B");

            foreach (var item in stops)
            {
                Console.WriteLine(item);
            }




            Console.Read();

        }
    }
}
