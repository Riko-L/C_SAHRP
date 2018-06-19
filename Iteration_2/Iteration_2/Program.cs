using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
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

            List<string> lsfClean = new List<string>();


            foreach (Lines line in resultGetLine)
            {
                if (!lsfClean.Contains(line.id))
                {
                    Console.WriteLine($"Identifiant de l'arret la ligne : {line.id}");
                    Console.WriteLine($"Nom de l''arret : {line.name}");
                    lsfClean.Add(line.id);
                }

                List<string> lnNbreClean = new List<string>();
                foreach (string lnNbre in line.lines)
                {
                    if (!lnNbreClean.Contains(lnNbre))
                    {
                       
                        Console.Write($"Nom de la ligne : {lnNbre} ===> ");
                        lnNbreClean.Add(lnNbre);

                        FeatureCollection resultGetFeatures = apiWebRequest.getGetFeatures(lnNbre);

                        foreach (Feature feature in resultGetFeatures.features)
                        {

                            int [] colorText = feature.properties.COULEUR_TEXTE.Split(',').Select(Int32.Parse).ToArray();
                            int [] color = feature.properties.COULEUR.Split(',').Select(Int32.Parse).ToArray();

                            Console.BackgroundColor = Color.FromArgb(color[0], color[1], color[2]);
                            Console.WriteLine($"Libéllé de l'arrêt : {feature.properties.LIBELLE}", Color.FromArgb(colorText[0], colorText[1], colorText[2]) );
                            


                        }

                    }
                }
                Console.WriteLine();
                Console.WriteLine();
            }




            Console.Read();
            // Cleanup the streams and the response.

        }
    }
}
