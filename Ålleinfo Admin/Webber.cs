using System;
using System.Collections.Specialized;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace Ålleinfo_Admin
{
    public static class Webber
    {
        const String Error_NoResponse = "Servern svarade inte";
        const String URI = "http://83.223.17.30/AlleIT/Alleinfo/winadmin/RequestHandler.php"; //OBS! ändra till https:// när port 443 är öppnad!

        const String userParam = "username";
        const String passParam = "password";
        const String actionParam = "reqaction";
        const String imageParam = "image";
        const String descriptionParam = "description";
        const String socURLParam = "socialURL";

        const String action_testCredentials = "testCreds";
        const String action_getHome = "getHome";
        const String action_setHome = "setHome";

        const String acceptedMessage = "accepted";

        public static String Username;
        private static String Password;

        public static Webresponse Login(String username, String password)
        {
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

                    if (String.IsNullOrWhiteSpace(response.Message))
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

        public static HomeData GetHome()
        {
            HomeData data = new HomeData();

            Webresponse response = new Webresponse();

            NameValueCollection reqParams = new NameValueCollection();
            reqParams.Add(userParam, Username);
            reqParams.Add(passParam, Password);
            reqParams.Add(actionParam, action_getHome);

            using (WebClient WC = new WebClient())
            {
                try
                {
                    response.Message = Encoding.UTF8.GetString(WC.UploadValues(URI, reqParams));

                    if (String.IsNullOrWhiteSpace(response.Message))
                    {
                        response.Message = Error_NoResponse;
                    }

                    response.Successful = response.Message.Substring(0, Math.Min(acceptedMessage.Length, response.Message.Length)).Equals(acceptedMessage, StringComparison.OrdinalIgnoreCase);

                    if (response.Successful)
                    {
                        response.Message = response.Message.Substring(acceptedMessage.Length);
                    }
                }
                catch (Exception e)
                {
                    response = new Webresponse(false, e.Message);
                }
            }

            if (response.Successful)
            {
                try
                {
                    HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(response.Message.Substring(0, response.Message.IndexOf(",")));
                    HttpWebResponse httpWebReponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    Stream stream = httpWebReponse.GetResponseStream();

                    String description = response.Message.LastIndexOf(",") == response.Message.IndexOf(",") + 1 ? "" : response.Message.Substring(response.Message.IndexOf(",") + 1, response.Message.LastIndexOf(",") - response.Message.IndexOf(",") - 1);
                    String socURL = response.Message.LastIndexOf(",") + 1 >= response.Message.Length ? "" : response.Message.Substring(response.Message.LastIndexOf(",") + 1);

                    return new HomeData(Image.FromStream(stream), description, socURL);
                }
                catch (Exception e)
                {
                    AdminForm.errorMessages.Enqueue("Utskottets bild kunde inte hämtas!"
                        + Environment.NewLine + Environment.NewLine
                        + "Felmeddelande:" + Environment.NewLine
                        + e.Message.ToString()
                        + Environment.NewLine + Environment.NewLine
                        + "Ytterligare info:"
                        + Environment.NewLine
                        + e.StackTrace.ToString());


                    return new HomeData(null, null, null);
                }
            }
            else
            {
                AdminForm.errorMessages.Enqueue("Utskottets bild kunde inte hämtas!"
                    + Environment.NewLine + Environment.NewLine
                    + "Felmeddelande:" + Environment.NewLine
                    + response.Message);
                return new HomeData(null, null, null);
            }

        }

        public static Webresponse SetHome(HomeData data)
        {
            Webresponse response = new Webresponse();

            NameValueCollection reqParams = new NameValueCollection();
            reqParams.Add(userParam, Username);
            reqParams.Add(passParam, Password);
            reqParams.Add(actionParam, action_setHome);
            reqParams.Add(imageParam, imageToBase64(data.logo));
            reqParams.Add(descriptionParam, data.description);
            reqParams.Add(socURLParam, data.socialURL);

            using (WebClient WC = new WebClient())
            {
                try
                {
                    response.Message = Encoding.UTF8.GetString(WC.UploadValues(URI, reqParams));

                    if (String.IsNullOrWhiteSpace(response.Message))
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

            return response;
        }

        private static String imageToBase64(Image image)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                // Convert Image to byte[]
                image.Save(stream, ImageFormat.Png);
                byte[] imageBytes = stream.ToArray();

                // Convert byte[] to Base64 String
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }
    }
}
