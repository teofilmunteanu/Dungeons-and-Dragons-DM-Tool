using Deez_Notes_Dm.API_Managers;
using Deez_Notes_Dm.DataManagers;
using Deez_Notes_Dm.Json_DTOs;
using Deez_Notes_Dm.Models;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using static Deez_Notes_Dm.Json_DTOs.MonsterDTO;
using static Deez_Notes_Dm.Models.Creature;
using static Deez_Notes_Dm.Models.Monster;

namespace Deez_Notes_Dm.Services
{
    public class MonsterServices
    {
        private static Action? ToAction(ActionDTO actionDTO)
        {
            if (actionDTO == null)
            {
                return null;
            }

            return new Action()
            {
                description = actionDTO.desc,
                name = actionDTO.name,
                attackBonus = actionDTO.attack_bonus,
                damageDice = actionDTO.damage_dice,
                damageBonus = actionDTO.damage_bonus
            };
        }

        private async static Task<Spell>? ToSpell(string spellAPI_Path)
        {
            if (spellAPI_Path == null)
            {
                return null;
            }

            SpellDTO spellDTO = await MonsterAPI.GetSpellAsync(spellAPI_Path);

            return new Spell()
            {
                name = spellDTO.name,
                desc = spellDTO.desc,
                higherLevel = spellDTO.higher_level,
                range = spellDTO.range,
                components = spellDTO.components,
                material = spellDTO.material,
                ritual = spellDTO.ritual,
                duration = spellDTO.duration,
                concentration = spellDTO.concentration,
                castingTime = spellDTO.casting_time,
                level = spellDTO.level,
                school = spellDTO.school,
                dndClass = spellDTO.dnd_class,
                archetype = spellDTO.archetype,
                circles = spellDTO.circles
            };
        }

        public async static Task<Monster> ToMonster(int id, MonsterDTO monsterDTO)
        {
            string race = monsterDTO.subtype != "" ? monsterDTO.type + " - " + monsterDTO.subtype : monsterDTO.type;

            Stats stats = new Stats()
            {
                STR = monsterDTO.strength,
                DEX = monsterDTO.dexterity,
                CON = monsterDTO.constitution,
                INT = monsterDTO.intelligence,
                WIS = monsterDTO.wisdom,
                CHA = monsterDTO.charisma
            };

            SavingStats savingThrows = new SavingStats()
            {
                STR = monsterDTO.strength_save,
                DEX = monsterDTO.dexterity_save,
                CON = monsterDTO.constitution_save,
                INT = monsterDTO.intelligence_save,
                WIS = monsterDTO.wisdom_save,
                CHA = monsterDTO.charisma_save
            };

            string skills = "";
            PropertyInfo[] skillsProps = monsterDTO.skills.GetType().GetProperties();
            foreach (PropertyInfo p in skillsProps)
            {
                if (p.GetValue(monsterDTO.skills) != null)
                {
                    skills += p.Name + "+" + (int)p.GetValue(monsterDTO.skills) + " ";
                }
            }

            List<Action> reactions = new List<Action>();
            if (monsterDTO.reactions != null)
            {
                reactions = monsterDTO.reactions.Select(a => ToAction(a)).ToList<Action>();
            }

            List<Action> actions = new List<Action>();
            if (monsterDTO.actions != null)
            {
                actions = monsterDTO.actions.Select(a => ToAction(a)).ToList<Action>();
            }

            List<Action> legendaryActions = new List<Action>();
            if (monsterDTO.legendary_actions != null)
            {
                legendaryActions = monsterDTO.legendary_actions.Select(a => ToAction(a)).ToList<Action>();
            }

            List<Action> specialAbilities = new List<Action>();
            if (monsterDTO.special_abilities != null)
            {
                specialAbilities = monsterDTO.special_abilities.Select(a => ToAction(a)).ToList<Action>();
            }

            List<Spell> spells = new List<Spell>();
            if (monsterDTO.spell_list != null)
            {
                foreach (string spellPath in monsterDTO.spell_list)
                {
                    Spell spellDTO = await ToSpell(spellPath);
                    spells.Add(spellDTO);
                }
            }

            return new Monster(
                id,
                monsterDTO.name,
                race,
                monsterDTO.hit_points,
                monsterDTO.armor_class,
                monsterDTO.speed,
                stats,
                monsterDTO.size,
                monsterDTO.alignment,
                monsterDTO.hit_dice,
                savingThrows,
                skills,
                monsterDTO.damage_vulnerabilities,
                monsterDTO.damage_resistances,
                monsterDTO.damage_immunities,
                monsterDTO.condition_immunities,
                monsterDTO.senses,
                monsterDTO.languages,
                monsterDTO.challenge_rating,
                XPbyCR[monsterDTO.challenge_rating],
                actions,
                reactions,
                monsterDTO.legendary_desc,
                legendaryActions,
                specialAbilities,
                spells
            );
        }

        public static async Task<List<MonsterDTO>> GetMonstersData(string name)
        {
            List<MonsterDTO> monsterDTOs;

            monsterDTOs = MonstersJsonManager.GetMonstersFromJson(name);

            if (monsterDTOs == null || monsterDTOs.Count == 0)
            {
                monsterDTOs = await MonsterAPI.GetMonstersAsync(name);
            }

            return monsterDTOs;
        }

        public static async Task<MonsterDTO> GetSingleMonsterData(string name)
        {
            MonsterDTO monsterDTO = new MonsterDTO();

            monsterDTO = MonstersJsonManager.GetSingleMonsterFromJson(name);

            if (monsterDTO == null)
            {
                monsterDTO = await MonsterAPI.GetSingleMonsterAsync(name);
            }

            return monsterDTO;
        }
    }
}
