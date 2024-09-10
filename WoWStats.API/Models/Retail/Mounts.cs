namespace WoWStats.API.Models.Retail
{
    public class Mounts
    {
        public Mount[] mounts { get; set; }
    }

    public class Mount
    {
        public Mount1 mount { get; set; }
        public bool is_favorite { get; set; }
    }

    public class Mount1
    {
        public Key key { get; set; }
        public string name { get; set; }
        public int id { get; set; }
    }

}
