using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MetroLibrary;

namespace MetroLibraryGoogle
{
    public class GoogleApi
    {
        const string END_POINT = "https://maps.googleapis.com/maps/api/geocode/json";

        const string KEY = "AIzaSyA_xavejOvzbJuKdxo42UIuN-094dPW9qQ";

        WokingTasks workTask;

        public GoogleApi()
        {
            workTask = new WokingTasks();
        }


        public string getGpsLocation_JSON(string address)
        {
            WebRequest request = WebRequest.Create($"{END_POINT}?address={address}&{KEY}");

            string jsonResponse = doRequest(request);

            return jsonResponse;
        }


        public AdressToGPSGoogle getGpsLocation(string address)
        {
            WebRequest request = WebRequest.Create($"{END_POINT}?address={address}&key={KEY}");

            string jsonResponse = doRequest(request);

            AdressToGPSGoogle adressToGPSGoogles = new AdressToGPSGoogle();

            adressToGPSGoogles = workTask.convertAdressGoogle(jsonResponse);

            return adressToGPSGoogles;
        }


        string doRequest(WebRequest request)
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
