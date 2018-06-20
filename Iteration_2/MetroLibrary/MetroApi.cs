using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MetroLibrary
{
        public class MetroApi
    {

        private const string API_END_POINT = "https://data.metromobilite.fr/api";

        /// <summary>
        /// Methode Permet d'obtenir les lignes
        /// </summary>
        /// <param name="longitude"></param>
        /// <param name="latitude"></param>
        /// <param name="rayon"></param>
        /// <returns></returns>
        public List<Lines> getLines(double longitude = 5.731879, double latitude = 45.158616, int rayon = 300)
        {

            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");

            WebRequest request = WebRequest.Create($"{API_END_POINT}/linesNear/json?x={longitude}&y={latitude}&dist={rayon}&details=true");

            string jsonResponse = doRequest(request);

            List<Lines> listFromServer = JsonConvert.DeserializeObject<List<Lines>>(jsonResponse);

            return listFromServer;
        }

        public string getLinesJSON( double longitude = 5.731879, double latitude = 45.158616, int rayon = 300)
        {

            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");

            WebRequest request = WebRequest.Create($"{API_END_POINT}/linesNear/json?x={longitude}&y={latitude}&dist={rayon}&details=true");

            string jsonResponse = doRequest(request);
            
            return jsonResponse;
        }


        public FeatureCollection getGetFeatures(string line)
        {
            line = line.Replace(":", "_");

            WebRequest request = WebRequest.Create($"{API_END_POINT}/lines/json?types=ligne&codes={line}");

            string jsonResponse = doRequest(request);

            FeatureCollection listFromServer = JsonConvert.DeserializeObject<FeatureCollection>(jsonResponse);

            return listFromServer;
        }

        public string getGetFeaturesJSON(string line)
        {
            line = line.Replace(":", "_");

            WebRequest request = WebRequest.Create($"{API_END_POINT}/lines/json?types=ligne&codes={line}");

            string jsonResponse = doRequest(request);

            return jsonResponse;
        }


        public List<LinesDescription> getDescriptionOfLine(string id)
        {

            WebRequest request = WebRequest.Create($"{API_END_POINT}/routers/default/index/routes?codes={id}");

            string jsonResponse = doRequest(request);

            List<LinesDescription> listFromServer = JsonConvert.DeserializeObject<List<LinesDescription>>(jsonResponse);

            return listFromServer;

        }

        public string getDescriptionOfLineJSON(string id)
        {

            WebRequest request = WebRequest.Create($"{API_END_POINT}/routers/default/index/routes?codes={id}");

            string jsonResponse = doRequest(request);

            return jsonResponse;

        }

        public List<string> getGetStopZone(string line)
        {
            List<string> stopZones = new List<string>();
            line = line.Replace(":", "_");

            WebRequest request = WebRequest.Create($"{API_END_POINT}/lines/json?types=ligne&codes={line}");

            string jsonResponse = doRequest(request);

            FeatureCollection listFromServer = JsonConvert.DeserializeObject<FeatureCollection>(jsonResponse);


            foreach(Feature feature in listFromServer.features)
            {
                foreach(string stopZone in feature.properties.ZONES_ARRET)
                {
                    stopZones.Add(stopZone);

                }
            }

            return stopZones;
        }


        private string doRequest(WebRequest request)
        {
            StreamReader reader = null;
            Stream dataStream = null;
            HttpWebResponse response = null;
            string responseFromServer = "";

            try
            {
                response = (HttpWebResponse)request.GetResponse();

                dataStream = response.GetResponseStream();

                reader = new StreamReader(dataStream);

                responseFromServer = reader.ReadToEnd();

            }
            catch (Exception e)
            {
                Console.Write($"Error : {e.Message}");
            }
            finally
            {
                reader.Close();
                dataStream.Close();
                response.Close();

            }

            return responseFromServer;


        }

    }
}
