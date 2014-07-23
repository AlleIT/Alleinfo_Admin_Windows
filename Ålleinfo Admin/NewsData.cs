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
        public int id { get; set; }
        public String headline { get; set; }
        public String shortInfo { get; set; }
        public String description { get; set; }
        public String butURL { get; set; }
        public String type { get; set; }
        public String handler { get; set; }
        public String pubDate { get; set; }

        public NewsData()
        {
            NewsDataArray.newsDataList.Add(this);
        }
    }
}
