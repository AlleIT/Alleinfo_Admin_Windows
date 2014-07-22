using System;
using System.Drawing;

namespace Ålleinfo_Admin
{
    public class HomeData
    {
        public Image logo;
        public String description;
        public String socialURL;
        public String hexaColor;

        public HomeData() { }

        public HomeData(Image logo, String description, String socialURL, String hexaColor)
        {
            this.logo = logo;
            this.description = description;
            this.socialURL = socialURL;
            this.hexaColor = hexaColor;
        }
    }
}
