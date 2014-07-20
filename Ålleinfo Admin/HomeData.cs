using System;
using System.Drawing;

namespace Ålleinfo_Admin
{
    public class HomeData
    {
        public Image logo;
        public String description;
        public String socialURL;

        public HomeData() { }

        public HomeData(Image logo, String description, String socialURL)
        {
            this.logo = logo;
            this.description = description;
            this.socialURL = socialURL;
        }
    }
}
