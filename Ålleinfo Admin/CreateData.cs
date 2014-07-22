using System;

namespace Ålleinfo_Admin
{
    public class CreateData
    {
        public int id; // Endast satt om nyheten som hanteras har ett id. Till för att avgöra om nyheten skall uppdateras eller skapas!
        public String headline;
        public String shortDesc;
        public String type;
        public String butUrl;
        public String description;
        public String date;

        public CreateData() { }

        public CreateData(String headline, String shortDesc, String type, String butUrl, String description, int id = -1, String date = "")
        {
            this.id = id;

            this.headline = headline;
            this.shortDesc = shortDesc;
            this.type = type;
            this.butUrl = butUrl;
            this.description = description;

            if (date == "")
                this.date = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + " - " + DateTime.Now.Year.ToString();
            else
                this.date = date;
        }
    }
}
