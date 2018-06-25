using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroLibraryGoogle;

namespace MetroLibrary
{
    internal class WokingTasks
    {

        public List<StopLines> convertStopLines(string jsonResponse)
        {
            List<StopLines> listFromServer = new List<StopLines>();

            listFromServer = JsonConvert.DeserializeObject<List<StopLines>>(jsonResponse);

            return listFromServer;
        }


        public List<StopLines> delDuplicateItem(List<StopLines> collection)
        {


            List<StopLines> collectionWOutDuplicate = new List<StopLines>(collection.GroupBy(item => item.name).Select(item => item.First()));


           

            foreach (StopLines stopLineWD in collectionWOutDuplicate)
            {
                foreach (StopLines stopLine in collection)
                {   //merci Alex 
                    if (stopLineWD.name.Equals(stopLine.name))
                    {
                        List<string> newLines = new List<string>(stopLineWD.lines.Union(stopLine.lines));

                        stopLineWD.GetType().GetProperty("lines").SetValue(stopLineWD, newLines);
                    }
                }
            }



            return collectionWOutDuplicate;
        }


        public List<LinesDescription> convertLinesDescription(string jsonResponse)
        {
            List<LinesDescription> listFromServer = new List<LinesDescription>();

            listFromServer = JsonConvert.DeserializeObject<List<LinesDescription>>(jsonResponse);

            return listFromServer;
        }


        public List<LinesDescription> delDuplicateItem(List<LinesDescription> collection)
        {
            List<LinesDescription> cleanList = new List<LinesDescription> ();

            cleanList = collection.GroupBy(item => item.id).Select(item => item.First()).ToList();

            return cleanList;
        }



        public AdressToGPSGoogle convertAdressGoogle(string jsonResponse)
        {
            AdressToGPSGoogle listFromServer = new AdressToGPSGoogle();

            listFromServer = JsonConvert.DeserializeObject<AdressToGPSGoogle>(jsonResponse);

            return listFromServer;
        }




    }
}
