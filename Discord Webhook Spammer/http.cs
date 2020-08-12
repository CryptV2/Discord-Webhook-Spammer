using System.Collections.Specialized;
using System.Net;

namespace WindowsFormsApp1
{
    internal class Http
    {

        public static byte[] Post(string uri, NameValueCollection pairs)
        {
            byte[] numArray;
            using (WebClient webClient = new WebClient())
            {
                numArray = webClient.UploadValues(uri, pairs);
            }

            return numArray;
        }
    }
}