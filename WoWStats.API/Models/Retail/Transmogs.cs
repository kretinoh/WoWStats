namespace WoWStats.API.Models.Retail.Transmogs
{
    public class Transmogs
    {
        public Appearance_Sets[] appearance_sets { get; set; }
        public Slot[] slots { get; set; }
    }


    public class Appearance_Sets
    {
        public Key key { get; set; }
        public string name { get; set; }
        public int id { get; set; }
    }

    public class Key
    {
        public string href { get; set; }
    }

    public class Slot
    {
        public Slot1 slot { get; set; }
        public Appearance[] appearances { get; set; }
    }

    public class Slot1
    {
        public string type { get; set; }
        public string name { get; set; }
    }

    public class Appearance
    {
        public Key1 key { get; set; }
        public int id { get; set; }
    }

    public class Key1
    {
        public string href { get; set; }
    }

}
