using System;

namespace Ålleinfo_Admin
{
    public class Webresponse
    {
        public Boolean Successful;
        public String Message;

        public Webresponse(Boolean Successful, String Message)
        {
            this.Successful = Successful;
            this.Message = Message;
        }

        public Webresponse()
        { }
    }
}
