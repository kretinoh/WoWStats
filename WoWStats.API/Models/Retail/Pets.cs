namespace WoWStats.API.Models.Retail.Pets
{
    public class Pets
    {

        public Pet[] pets { get; set; }
        public int unlocked_battle_pet_slots { get; set; }
    }

    public class Pet
    {
        public Species species { get; set; }
        public int level { get; set; }
        public Quality quality { get; set; }
        public Stats stats { get; set; }
        public Creature_Display creature_display { get; set; }
        public int id { get; set; }
    }

    public class Species
    {
        public Key key { get; set; }
        public string name { get; set; }
        public int id { get; set; }
    }

    public class Key
    {
        public string href { get; set; }
    }

    public class Quality
    {
        public string type { get; set; }
        public string name { get; set; }
    }

    public class Stats
    {
        public int breed_id { get; set; }
        public int health { get; set; }
        public int power { get; set; }
        public int speed { get; set; }
    }

    public class Creature_Display
    {
        public Key1 key { get; set; }
        public int id { get; set; }
    }

    public class Key1
    {
        public string href { get; set; }
    }

}
