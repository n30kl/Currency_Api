using System.IO;
using System.Net;

namespace currency_api_by_n30_kl
{
    public class Get
    {
        public static string GetStr(string A)
        {

            System.Net.HttpWebRequest request = (HttpWebRequest)WebRequest.Create(A); 

            request.Method = "GET";

            WebResponse response = request.GetResponse(); 

            Stream s = response.GetResponseStream(); 

            StreamReader reader = new StreamReader(s); 

            string answer = reader.ReadToEnd();

            response.Close();

            return answer;
        }

    }
}
