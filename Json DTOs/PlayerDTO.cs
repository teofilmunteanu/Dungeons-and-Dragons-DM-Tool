using System.Collections.Generic;

namespace Deez_Notes_Dm.Json_DTOs
{
    public class PlayerDTO : CreatureDTO
    {
        public int XP { get; set; }
        public int totalLevel { get; set; }
        public SortedDictionary<string, int> levelByClass { get; set; }

        public int HitDice { get; set; }

        public int PassiveInsight { get; set; }
        public int PassivePerception { get; set; }
        public int PassiveInvestigation { get; set; }
    }
}
