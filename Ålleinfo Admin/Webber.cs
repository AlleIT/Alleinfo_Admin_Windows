using System;
using System.Collections.Specialized;
using System.Net;
using System.Text;

namespace Ålleinfo_Admin
{
    public static class Webber
    {
        const String Error_NoResponse = "Servern svarade inte";
        const String URI = "http://83.223.17.30/AlleIT/Alleinfo/winadmin/RequestHandler.php"; //OBS! ändra till https:// när port 443 är öppnad!

        const String userParam = "username";
        const String passParam = "password";
        const String actionParam = "reqaction";

        public static String Username;
        private static String Password;

        public static Webresponse Login(String username, String password)
        {
            const String action_testCredentials = "testCreds";
            const String acceptedMessage = "Inloggad!";


            Webresponse response = new Webresponse();

            NameValueCollection reqParams = new NameValueCollection();
            reqParams.Add(userParam, username);
            reqParams.Add(passParam, password);
            reqParams.Add(actionParam, action_testCredentials);

            using (WebClient WC = new WebClient())
            {
                try
                {
                    response.Message = Encoding.UTF8.GetString(WC.UploadValues(URI, reqParams));

                    if(String.IsNullOrWhiteSpace(response.Message))
                    {
                        response.Message = Error_NoResponse;
                    }

                    response.Successful = response.Message.Equals(acceptedMessage, StringComparison.OrdinalIgnoreCase);
                }
                catch (Exception e)
                {
                    response = new Webresponse(false, e.Message);
                }
            }

            if (response.Successful)
            {
                Username = username;
                Password = password;
            }

            return response;
        }
    }
}
