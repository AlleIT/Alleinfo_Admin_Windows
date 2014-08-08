using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace Ålleinfo_Admin
{
    public static class Webber
    {
        #region Constants

        #region Default Server

        const String Error_NoResponse = "Servern svarade inte";
        const String URI = "http://83.223.17.30/AlleIT/Alleinfo/winadmin/RequestHandler.php"; //OBS! ändra till https:// när port 443 är öppnad!

        #endregion

        #region Parameters

        const String userParam = "username";
        const String passParam = "password";
        const String actionParam = "reqaction";
        const String imageParam = "image";
        const String descriptionParam = "description";
        const String socURLParam = "socialURL";
        const String colorParam = "color";
        const String headlineParam = "headline";
        const String shortDescriptionParam = "shortDesc";
        const String buttonUrlParam = "butUrl";
        const String idParam = "id";
        const String dateParam = "pubDate";
        const String typeParam = "type";

        #endregion

        #region actions

        const String action_testCredentials = "testCreds";

        const String action_getHome = "getHome";
        const String action_setHome = "setHome";

        const String action_setNews = "setNews";

        const String action_getAllNews = "getAllNews";

        const String action_getNewsCount = "getNewsCount";

        const String action_removeNews = "removeNews";

        const String acceptedMessage = "accepted";

        #endregion

        #endregion

        #region Creds

        public static String Username;
        private static String Password;

        #endregion

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

        #region Home

        public static HomeData GetHome()
        {
            HomeData data = new HomeData();

            Webresponse response;

            NameValueCollection reqParams = new NameValueCollection();
            reqParams.Add(userParam, Username);
            reqParams.Add(passParam, Password);
            reqParams.Add(actionParam, action_getHome);

            performDefaultWebRequest(reqParams, out response);

            if (response.Successful)
            {
                try
                {
                    HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(response.Message.Substring(0, response.Message.IndexOf(",")));
                    HttpWebResponse httpWebReponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    Stream stream = httpWebReponse.GetResponseStream();

                    String description = response.Message.LastIndexOf(",") == response.Message.IndexOf(",") + 1 ? "" : response.Message.Substring(response.Message.IndexOf(",") + 1, response.Message.LastIndexOf(",") - response.Message.IndexOf(",") - 1);
                    
                    String socURL = response.Message.LastIndexOf(",") + 1 >= response.Message.Length ? "" : response.Message.Substring(response.Message.LastIndexOf(",") + 1, response.Message.Length - response.Message.LastIndexOf(",") - 8);
                    
                    String hexColor = response.Message.Substring(response.Message.Length - 7);

                    return new HomeData(Image.FromStream(stream), description, socURL, hexColor);
                }
                catch (Exception e)
                {
                    AdminForm.errorMessages.Enqueue("Sidan kunde inte laddas!"
                        + Environment.NewLine + Environment.NewLine
                        + "Felmeddelande:" + Environment.NewLine
                        + e.Message.ToString()
                        + Environment.NewLine + Environment.NewLine
                        + "Ytterligare info:"
                        + Environment.NewLine
                        + e.StackTrace.ToString());

                    throw new GeneralWebberException();
                }
            }
            else
            {
                AdminForm.errorMessages.Enqueue("Sidan kunde inte laddas!"
                    + Environment.NewLine + Environment.NewLine
                    + "Felmeddelande:" + Environment.NewLine
                    + response.Message);

                throw new GeneralWebberException();
            }

        }

        public static Webresponse SetHome(HomeData data)
        {
            Webresponse response;

            NameValueCollection reqParams = new NameValueCollection();
            reqParams.Add(userParam, Username);
            reqParams.Add(passParam, Password);
            reqParams.Add(actionParam, action_setHome);
            reqParams.Add(imageParam, imageToBase64(data.logo));
            reqParams.Add(descriptionParam, data.description);
            reqParams.Add(socURLParam, data.socialURL);
            reqParams.Add(colorParam, data.hexaColor);

            performDefaultWebRequest(reqParams, out response);

            if(!response.Successful)
            {
                AdminForm.errorMessages.Enqueue("Sparandet misslyckades! Försök igen."
                    + Environment.NewLine + Environment.NewLine
                    + "Felmeddelande:" + Environment.NewLine
                    + response.Message.ToString());

                throw new GeneralWebberException();
            }

            return response;
        }

        #endregion

        #region Create

        public static Webresponse SetNews(NewsData data)
        {
            Webresponse response;

            NameValueCollection reqParams = new NameValueCollection();
            reqParams.Add(userParam, Username);
            reqParams.Add(passParam, Password);
            reqParams.Add(actionParam, action_setNews);
            reqParams.Add(headlineParam, data.headline);
            reqParams.Add(idParam, data.id.ToString());
            reqParams.Add(shortDescriptionParam, data.shortInfo);
            reqParams.Add(descriptionParam, data.description);
            reqParams.Add(typeParam, data.type);
            reqParams.Add(buttonUrlParam, data.butURL);
            reqParams.Add(dateParam, data.pubDate);

            performDefaultWebRequest(reqParams, out response);

            if(!response.Successful)
            {
                AdminForm.errorMessages.Enqueue("Sparandet misslyckades! Försök igen."
                            + Environment.NewLine + Environment.NewLine
                            + "Felmeddelande:" + Environment.NewLine
                            + response.Message.ToString());

                throw new GeneralWebberException();
            }

            return response;
        }

        #endregion

        #region adminAll
        public static void GetAllNews()
        {
            if (requestNewsCount() == 0)
                return;
            
            Webresponse response;

            NameValueCollection reqParams = new NameValueCollection();
            reqParams.Add(userParam, Username);
            reqParams.Add(passParam, Password);
            reqParams.Add(actionParam, action_getAllNews);

            performDefaultWebRequest(reqParams, out response);

            if (!response.Successful)
            {
                AdminForm.errorMessages.Enqueue("Kunde inte hämta nyheterna från servern!"
                    + Environment.NewLine + Environment.NewLine
                    + "Felmeddelande:" + Environment.NewLine
                    + response.Message.ToString());

                throw new GeneralWebberException();
            }

            response.Message = simpleHTMLDecode(response.Message);

            try
            {
                NewsDataArray.newsDataList.Clear();
                NewsDataArray.newsDataList = new JavaScriptSerializer().Deserialize<List<NewsData>>(response.Message);

                if (NewsDataArray.newsDataList == null)
                    NewsDataArray.newsDataList = new List<NewsData>();
            }
            catch (Exception e)
            {
                AdminForm.errorMessages.Enqueue("Kunde inte hämta nyheterna från servern!"
                    + Environment.NewLine + Environment.NewLine
                    + "Felmeddelande:" + Environment.NewLine
                    + e.Message.ToString()
                    + Environment.NewLine + Environment.NewLine
                    + "Ytterligare info:"
                    + Environment.NewLine
                    + e.StackTrace.ToString());

                throw new GeneralWebberException();
            }

            if (requestNewsCount() == NewsDataArray.newsDataList.Count)
            {
                foreach (NewsData ND in NewsDataArray.newsDataList)
                {
                    new NewsItem(ND);
                }
            }
            else
            {
                AdminForm.errorMessages.Enqueue("Serverns svar stämmer inte med det rapporterade antalet nyheter."
                    + Environment.NewLine + Environment.NewLine
                    + "Försök igen eller kontakta ÅlleIT om problemet kvarstår");

                throw new GeneralWebberException();
            }

        }

        private static int requestNewsCount()
        {
            Webresponse response;

            NameValueCollection reqParams = new NameValueCollection();
            reqParams.Add(userParam, Username);
            reqParams.Add(passParam, Password);
            reqParams.Add(actionParam, action_getNewsCount);

            performDefaultWebRequest(reqParams, out response);

            int i;

            if(int.TryParse(response.Message, out i))
            {
                return i;
            }
            else
            {
                AdminForm.errorMessages.Enqueue("Serverns svar kunde inte tolkas."
                    + Environment.NewLine + Environment.NewLine
                    + "Mer info:" + Environment.NewLine
                    + response.Message);

                throw new GeneralWebberException();
            }

        }

        public static void removeNews(int id)
        {
            Webresponse response;

            NameValueCollection reqParams = new NameValueCollection();
            reqParams.Add(userParam, Username);
            reqParams.Add(passParam, Password);
            reqParams.Add(actionParam, action_removeNews);
            reqParams.Add(idParam, id.ToString());

            performDefaultWebRequest(reqParams, out response);

            if (!response.Successful)
            {
                AdminForm.errorMessages.Enqueue("Borttagandet misslyckades."
                    + Environment.NewLine + Environment.NewLine
                    + "Mer info:"
                    + Environment.NewLine
                    + response.Message);

                throw new GeneralWebberException();
            }

        }

        // TODO: Rewrite. Just a copy of GetHome as of now.
        public static HomeData GetSpecificNews()
        {
            HomeData data = new HomeData();

            Webresponse response = new Webresponse();

            NameValueCollection reqParams = new NameValueCollection();
            reqParams.Add(userParam, Username);
            reqParams.Add(passParam, Password);
            reqParams.Add(actionParam, action_getHome);

            if (response.Successful)
            {
                try
                {
                    HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(response.Message.Substring(0, response.Message.IndexOf(",")));
                    HttpWebResponse httpWebReponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    Stream stream = httpWebReponse.GetResponseStream();

                    String description = response.Message.LastIndexOf(",") == response.Message.IndexOf(",") + 1 ? "" : response.Message.Substring(response.Message.IndexOf(",") + 1, response.Message.LastIndexOf(",") - response.Message.IndexOf(",") - 1);
                    String socURL = response.Message.LastIndexOf(",") + 1 >= response.Message.Length ? "" : response.Message.Substring(response.Message.LastIndexOf(",") + 1, response.Message.Length - response.Message.LastIndexOf(",") - 8);
                    String hexColor = response.Message.Substring(response.Message.Length - 7);

                    return new HomeData(Image.FromStream(stream), description, socURL, hexColor);
                }
                catch (Exception e)
                {
                    AdminForm.errorMessages.Enqueue("Sidan kunde inte laddas!"
                        + Environment.NewLine + Environment.NewLine
                        + "Felmeddelande:" + Environment.NewLine
                        + e.Message.ToString()
                        + Environment.NewLine + Environment.NewLine
                        + "Ytterligare info:"
                        + Environment.NewLine
                        + e.StackTrace.ToString());

                    throw new GeneralWebberException();
                }
            }
            else
            {
                AdminForm.errorMessages.Enqueue("Sidan kunde inte laddas!"
                    + Environment.NewLine + Environment.NewLine
                    + "Felmeddelande:" + Environment.NewLine
                    + response.Message);

                throw new GeneralWebberException();
            }

        }

        #endregion

        public static void performDefaultWebRequest(NameValueCollection reqParams, out Webresponse response)
        {
            response = new Webresponse();

            using (WebClient WC = new WebClient())
            {
                try
                {
                    response.Message = Encoding.UTF8.GetString(WC.UploadValues(URI, reqParams));

                    if (String.IsNullOrWhiteSpace(response.Message))
                    {
                        response.Message = Error_NoResponse;
                    }

                    response.Successful = response.Message.Contains(acceptedMessage);

                    if (response.Successful)
                        response.Message = response.Message.Substring(0, response.Message.IndexOf(acceptedMessage))
                            + response.Message.Substring(response.Message.IndexOf(acceptedMessage) + acceptedMessage.Length);
                }
                catch (Exception e)
                {
                    response = new Webresponse(false, e.Message);
                }
            }
        }

        #region Utilities

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

        #region HTML/UTF8 Encoder/Decoder


        public static String simpleHTMLEncode(String str)
        {
            String split = str;
            str = "";

            String[] divider = { Environment.NewLine };

            foreach (String s in split.Split(divider, StringSplitOptions.None))
            {
                str += s + "<br>";
            }

            str = str.Substring(0, str.Length - 4);

            return str;
        }

        public static String simpleHTMLDecode(String str)
        {
            String split = str;
            str = "";

            String[] divider = { "<br>" };

            foreach (String s in split.Split(divider, StringSplitOptions.None))
            {
                str += s + Environment.NewLine;
            }

            str = str.Substring(0, str.Length - Environment.NewLine.Length);

            return str;
        }

        #endregion

        #endregion
    }

    public class GeneralWebberException : Exception
    {
        public GeneralWebberException()
        {

        }
    }
}
