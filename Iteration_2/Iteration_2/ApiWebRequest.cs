using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Iteration_2
{
    class ApiWebRequest
    {

        private const string API_END_POINT = "https://data.metromobilite.fr/api";

        public ApiWebRequest() {}

        public List<Lines> getLines(double longitude = 5.733195, double latitude = 45.18579)
        {

            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
          
            WebRequest request = WebRequest.Create($"{API_END_POINT}/linesNear/json?x={longitude}&y={latitude}&dist=360&details=true");
           
            request.Credentials = CredentialCache.DefaultCredentials;
       
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
          
            Stream dataStream = response.GetResponseStream();
            
            StreamReader reader = new StreamReader(dataStream);
          
            string responseFromServer = reader.ReadToEnd();

            List<Lines> listFromServer = JsonConvert.DeserializeObject<List<Lines>>(responseFromServer);

            reader.Close();
            dataStream.Close();
            response.Close();

            return listFromServer;
        }

        public FeatureCollection getGetFeatures(string line)
        {
            line = line.Replace(":", "_");
          
            WebRequest request = WebRequest.Create($"{API_END_POINT}/lines/json?types=ligne&codes={line}");
           
            request.Credentials = CredentialCache.DefaultCredentials;
           
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
          
            Stream dataStream = response.GetResponseStream();
         
            StreamReader reader = new StreamReader(dataStream);
          
            string responseFromServer = reader.ReadToEnd();

            FeatureCollection listFromServer = JsonConvert.DeserializeObject<FeatureCollection>(responseFromServer);

            reader.Close();
            dataStream.Close();
            response.Close();

            return listFromServer;
        }

        public List<LinesDescription> getDescriptionOfLine(string id)
        {
            
            WebRequest request = WebRequest.Create($"{API_END_POINT}/routers/default/index/routes?codes={id}");
            
            request.Credentials = CredentialCache.DefaultCredentials;
           
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
          
            Stream dataStream = response.GetResponseStream();
           
            StreamReader reader = new StreamReader(dataStream);
            
            string responseFromServer = reader.ReadToEnd();

            List<LinesDescription> listFromServer = JsonConvert.DeserializeObject<List<LinesDescription>>(responseFromServer);

            reader.Close();
            dataStream.Close();
            response.Close();

            return listFromServer;

        }

    }
}
