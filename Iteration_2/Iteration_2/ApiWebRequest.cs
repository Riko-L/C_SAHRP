using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Iteration_2
{
    class ApiWebRequest
    {



        public ApiWebRequest() {}

   

        public List<Lines> getLines()
        {
            // Create a request for the URL. 		
            WebRequest request = WebRequest.Create("http://data.metromobilite.fr/api/linesNear/json?x=5.715510&y=45.190924&dist=600&details=true");
            // If required by the server, set the credentials.
            request.Credentials = CredentialCache.DefaultCredentials;
            // Get the response.
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            // Display the status.
            Console.WriteLine(response.StatusDescription);
            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
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
            // Create a request for the URL. 		
            WebRequest request = WebRequest.Create($"https://data.metromobilite.fr/api/lines/json?types=ligne&codes={line}");
            // If required by the server, set the credentials.
            request.Credentials = CredentialCache.DefaultCredentials;
            // Get the response.
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
          
            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();

            FeatureCollection listFromServer = JsonConvert.DeserializeObject<FeatureCollection>(responseFromServer);

            reader.Close();
            dataStream.Close();
            response.Close();

            return listFromServer;
        }

    }
}
