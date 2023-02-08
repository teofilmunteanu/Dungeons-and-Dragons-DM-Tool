﻿using static Deez_Notes_Dm.Models.Creature;

namespace Deez_Notes_Dm.Json_DTOs
{
    //for: https://api.open5e.com/monsters/
    public class MonsterDTO
    {
        public string? name { get; set; }
        public string? size { get; set; }
        public string? type { get; set; }

        public string? alignment { get; set; }
        public string? armor_class { get; set; }
        public string? hit_points { get; set; }

        public string? hit_Dice { get; set; }
        public Speed? speed { get; set; }

        public string? strength { get; set; }
        public string? dexterity { get; set; }
        public string? constitution { get; set; }
        public string? intelligence { get; set; }
        public string? wisdom { get; set; }
        public string? charisma { get; set; }

        public string? strength_save { get; set; }
        public string? dexterity_save { get; set; }
        public string? constitution_save { get; set; }
        public string? intelligence_save { get; set; }
        public string? wisdom_save { get; set; }
        public string? charisma_save { get; set; }

        public Skills? skills { get; set; }

        public string? damage_vulnerabilities { get; set; }
        public string? damage_resistances { get; set; }
        public string? damage_immunities { get; set; }
        public string? condition_immunities { get; set; }

        public string? senses { get; set; }

        public string? languages { get; set; }

        public string? challenge_rating { get; set; }


        public ActionDTO[]? actions { get; set; }
        public ActionDTO[]? reactions { get; set; }


        public string? legendary_desc { get; set; }
        public ActionDTO[]? legendary_actions { get; set; }

        public ActionDTO[]? special_abilities { get; set; }

        public class Skills
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
    }
}
