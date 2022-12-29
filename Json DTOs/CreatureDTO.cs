using static Deez_Notes_Dm.Models.Creature;

namespace Deez_Notes_Dm.Json_DTOs
{
    public class CreatureDTO
    {
        public int ID { get; set; }

        public string Name { get; set; }
        public string Race { get; set; }

        public int MaxHP { get; set; }
        public int HP { get; set; }
        public int AC { get; set; }

        public Speed Speeds { get; set; }

        public Stats BaseStats { get; set; }
    }
}
