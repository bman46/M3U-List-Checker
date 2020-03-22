using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace M3U_List_Checker
{
    class Check
    {
        public static int excludedChans = 0;
        public static bool ExistanceCheck(string link)
        {
            var request = (HttpWebRequest)WebRequest.Create(link);
            //request.Method = "HEAD";
            request.Timeout = 500;
            try
            {
                var response = (HttpWebResponse)request.GetResponse();
                var success = response.StatusCode == HttpStatusCode.OK && response.ContentLength > 0;

                response.Close();
                if (!success)
                {
                    Console.WriteLine("Response error on link " + link);
                    excludedChans++;
                }
                return success;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error on link " + link + " Error: " + e);
                excludedChans++;
                return false;
            }
        }
    }
}
