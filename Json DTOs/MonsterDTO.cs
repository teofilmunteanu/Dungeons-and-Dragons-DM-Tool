using static Deez_Notes_Dm.Models.Creature;

namespace Deez_Notes_Dm.Json_DTOs
{
    //for: https://api.open5e.com/monsters/
    public class MonsterDTO
    {
        public string name { get; set; }
        public string size { get; set; }
        public string type { get; set; }
        public string subtype { get; set; }

        public string alignment { get; set; }
        public int armor_class { get; set; }
        public int hit_points { get; set; }

        public string hit_dice { get; set; }
        public Speed speed { get; set; }

        public int strength { get; set; }
        public int dexterity { get; set; }
        public int constitution { get; set; }
        public int intelligence { get; set; }
        public int wisdom { get; set; }
        public int charisma { get; set; }

        public int? strength_save { get; set; }
        public int? dexterity_save { get; set; }
        public int? constitution_save { get; set; }
        public int? intelligence_save { get; set; }
        public int? wisdom_save { get; set; }
        public int? charisma_save { get; set; }

        public SkillsDTO skills { get; set; }

        public string? damage_vulnerabilities { get; set; }
        public string? damage_resistances { get; set; }
        public string? damage_immunities { get; set; }
        public string? condition_immunities { get; set; }

        public string? senses { get; set; }

        public string languages { get; set; }

        public string challenge_rating { get; set; }


        public ActionDTO[]? actions { get; set; }
        public ActionDTO[]? reactions { get; set; }


        public string? legendary_desc { get; set; }
        public ActionDTO[]? legendary_actions { get; set; }

        public ActionDTO[]? special_abilities { get; set; }
        public string[]? spell_list { get; set; }


        public string notes { get; set; }



        public class SkillsDTO
        {
            public int? acrobatics { get; set; }
            public int? animal_handling { get; set; }
            public int? arcana { get; set; }
            public int? athletics { get; set; }
            public int? deception { get; set; }
            public int? history { get; set; }
            public int? insight { get; set; }
            public int? intimidation { get; set; }
            public int? investigation { get; set; }
            public int? medicine { get; set; }
            public int? nature { get; set; }
            public int? perception { get; set; }
            public int? performance { get; set; }
            public int? persuasion { get; set; }
            public int? religion { get; set; }
            public int? sleight_of_hand { get; set; }
            public int? stealth { get; set; }
            public int? survival { get; set; }
        }

        public class ActionDTO
        {
            public string desc { get; set; }
            public string name { get; set; }
            public int? attack_bonus { get; set; }
            public string? damage_dice { get; set; }
            public int? damage_bonus { get; set; }
        }

        public class SpellDTO
        {
            public string name { get; set; }
            public string desc { get; set; }
            public string higher_level { get; set; }
            public string range { get; set; }
            public string components { get; set; }
            public string material { get; set; }
            public string ritual { get; set; }
            public string duration { get; set; }
            public string concentration { get; set; }
            public string casting_time { get; set; }
            public string level { get; set; }
            public string school { get; set; }
            public string dnd_class { get; set; }
            public string archetype { get; set; }
            public string circles { get; set; }
        }
    }
}
