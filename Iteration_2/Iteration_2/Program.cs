using System.Collections.Generic;
using System.Drawing;
using Console = Colorful.Console;

namespace Iteration_2
{
    class Program
    {
        static void Main(string[] args)
        {

            ApiWebRequest apiWebRequest = new ApiWebRequest();

            List<Lines> resultGetLine = apiWebRequest.getLines();

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

                        List<LinesDescription> resultDescriptionOfLine = apiWebRequest.getDescriptionOfLine(lineIdName);

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

            Console.Read();

        }
    }
}
