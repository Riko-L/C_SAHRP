using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Threading;

namespace MetroLibrary
{
    public class MetroApi
    {


        private const string API_END_POINT = "https://data.metromobilite.fr/api";

        private WokingTasks workTask;

        public MetroApi()
        {
            workTask = new WokingTasks();

        }

        /// <summary>
        /// Methode Permet d'obtenir les arrêts disponibles pour un point GPS donné avec un rayon d'action donné
        /// </summary>
        /// <param name="longitude">Longitude</param>
        /// <param name="latitude">Latitude</param>
        /// <param name="rayon">Rayoun</param>
        /// <returns>Collection d'arrêts</returns>
        public List<StopLines> getStopLines(double longitude = 5.731879, double latitude = 45.158616, int rayon = 300)
        {
            //Pour que lors de la convertion de double en string le '.' reste
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");

            WebRequest request = WebRequest.Create($"{API_END_POINT}/linesNear/json?x={longitude}&y={latitude}&dist={rayon}&details=true");

            string jsonResponse = doRequest(request);

            List<StopLines> convert = workTask.convertStopLines(jsonResponse);

            var clean = workTask.delDuplicateItem(convert);

            return clean;
        }

        /// <summary>
        /// Methode Permet d'obtenir les arrêts disponibles pour un point GPS donné avec un rayon d'action donné
        /// </summary>
        /// <param name="longitude">Longitude</param>
        /// <param name="latitude">Latitude</param>
        /// <param name="rayon">Rayoun</param>
        /// <returns>JSON</returns>
        public string getStopLines_JSON(double longitude = 5.731879, double latitude = 45.158616, int rayon = 300)
        {
            //Pour que lors de la convertion de double en string le '.' reste
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");

            WebRequest request = WebRequest.Create($"{API_END_POINT}/linesNear/json?x={longitude}&y={latitude}&dist={rayon}&details=true");

            string jsonResponse = doRequest(request);

            return jsonResponse;
        }

        /// <summary>
        /// Obtenir toutes les caractéristiques de la ligne
        /// </summary>
        /// <param name="line"></param>
        /// <returns>Collection</returns>
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

        /// <summary>
        /// Permet d'obtenir les informations de la ligne
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Collection de LinesDescription </returns>
        public List<LinesDescription> getInforamtionsOfLine(string id)
        {

            WebRequest request = WebRequest.Create($"{API_END_POINT}/routers/default/index/routes?codes={id}");

            string jsonResponse = doRequest(request);

            List<LinesDescription> listFromServer = JsonConvert.DeserializeObject<List<LinesDescription>>(jsonResponse);

            List<LinesDescription> convert = workTask.convertLinesDescription(jsonResponse);

            var clean = workTask.delDuplicateItem(convert);

            return listFromServer;

        }

        public string getDescriptionOfLineJSON(string id)
        {

            WebRequest request = WebRequest.Create($"{API_END_POINT}/routers/default/index/routes?codes={id}");

            string jsonResponse = doRequest(request);

            return jsonResponse;

        }

        /// <summary>
        /// Retour la liste de tous les arrêts de la ligne
        /// </summary>
        /// <param name="line"></param>
        /// <returns>Collection des arrêts</returns>
        public List<string> getGetStopZone(string line)
        {
            List<string> stopZones = new List<string>();
            line = line.Replace(":", "_");

            WebRequest request = WebRequest.Create($"{API_END_POINT}/lines/json?types=ligne&codes={line}");

            string jsonResponse = doRequest(request);

            FeatureCollection listFromServer = JsonConvert.DeserializeObject<FeatureCollection>(jsonResponse);


            foreach (Feature feature in listFromServer.features)
            {
                foreach (string stopZone in feature.properties.ZONES_ARRET)
                {
                    stopZones.Add(stopZone);

                }
            }

            return stopZones;
        }

        /// <summary>
        /// Execute la requète 
        /// </summary>
        /// <param name="request"></param>
        /// <returns>un json</returns>
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
