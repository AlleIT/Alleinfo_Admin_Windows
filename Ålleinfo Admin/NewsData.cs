using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ålleinfo_Admin
{
    public static class NewsDataArray
    {
        public static List<NewsData> newsDataList = new List<NewsData>();
    }

    public class NewsData
    {
        public int? id { get; set; }
        public String headline { get; set; }
        public String shortInfo { get; set; }
        public String description { get; set; }
        public String butURL { get; set; }
        public String type { get; set; }
        public String handler { get; set; }
        public String pubDate { get; set; }

        public void changeData(String headline, String shortDesc, String type, String butUrl, String description)
        {
            if (id == null)
                id = -1;

            this.headline = headline;
            this.shortInfo = shortDesc;
            this.type = type;
            this.butURL = butUrl;
            this.description = description;

            if (String.IsNullOrWhiteSpace(this.pubDate))
                this.pubDate = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + " - " + DateTime.Now.Year.ToString();
        }
    }
}
