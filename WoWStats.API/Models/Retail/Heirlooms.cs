namespace WoWStats.API.Models.Retail.Heirlooms
{
    public class Heirlooms
    {
        public Heirloom[] heirlooms { get; set; }
    }

    public class Heirloom
    {
        public Heirloom1 heirloom { get; set; }
        public Upgrade upgrade { get; set; }
    }

    public class Heirloom1
    {
        public Key key { get; set; }
        public string name { get; set; }
        public int id { get; set; }
    }

    public class Key
    {
        public string href { get; set; }
    }

    public class Upgrade
    {
        public int level { get; set; }
    }


}
