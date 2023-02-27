using Deez_Notes_Dm.API_Managers;
using Deez_Notes_Dm.DataManagers;
using Deez_Notes_Dm.Json_DTOs;
using Deez_Notes_Dm.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Deez_Notes_Dm.Json_DTOs.MonsterDTO;
using static Deez_Notes_Dm.Models.Creature;
using static Deez_Notes_Dm.Models.Monster;

namespace Deez_Notes_Dm.Services
{
    public class MonsterServices
    {
        private static ActionStats? ToAction(ActionDTO actionDTO)
        {
            if (actionDTO == null)
            {
                return null;
            }

            return new ActionStats()
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

        //eventually take notes from somewhere else(maybe a store or smth)
        public async static Task<Monster> ToMonster(int id, string notes, MonsterDTO monsterDTO)
        {
            string race = monsterDTO.subtype != "" ? monsterDTO.type[0].ToString().ToUpper() + monsterDTO.type.Substring(1) + "(" + monsterDTO.subtype[0].ToString().ToUpper() + monsterDTO.subtype.Substring(1) + ")" :
                monsterDTO.type[0].ToString().ToUpper() + monsterDTO.type.Substring(1);

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

            SkillsStats skills = new SkillsStats()
            {
                acrobatics = monsterDTO.skills.acrobatics,
                animalHandling = monsterDTO.skills.animal_handling,
                arcana = monsterDTO.skills.arcana,
                athletics = monsterDTO.skills.athletics,
                deception = monsterDTO.skills.deception,
                history = monsterDTO.skills.history,
                insight = monsterDTO.skills.insight,
                intimidation = monsterDTO.skills.intimidation,
                investigation = monsterDTO.skills.investigation,
                medicine = monsterDTO.skills.medicine,
                nature = monsterDTO.skills.nature,
                perception = monsterDTO.skills.perception,
                performance = monsterDTO.skills.performance,
                persuasion = monsterDTO.skills.persuasion,
                religion = monsterDTO.skills.religion,
                sleightOfHand = monsterDTO.skills.sleight_of_hand,
                stealth = monsterDTO.skills.stealth,
                survival = monsterDTO.skills.survival,
            };

            List<ActionStats> reactions = new List<ActionStats>();
            if (monsterDTO.reactions != null)
            {
                reactions = monsterDTO.reactions.Select(a => ToAction(a)).ToList();
            }

            List<ActionStats> actions = new List<ActionStats>();
            if (monsterDTO.actions != null)
            {
                actions = monsterDTO.actions.Select(a => ToAction(a)).ToList();
            }

            List<ActionStats> legendaryActions = new List<ActionStats>();
            if (monsterDTO.legendary_actions != null)
            {
                legendaryActions = monsterDTO.legendary_actions.Select(a => ToAction(a)).ToList();
            }

            List<ActionStats> specialAbilities = new List<ActionStats>();
            if (monsterDTO.special_abilities != null)
            {
                specialAbilities = monsterDTO.special_abilities.Select(a => ToAction(a)).ToList();
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
                notes,
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
            List<MonsterDTO> monsterDTOs = new List<MonsterDTO>();

            monsterDTOs.AddRange(MonstersJsonManager.GetMonstersFromJson(name));

            monsterDTOs.AddRange(await MonsterAPI.GetMonstersAsync(name));

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
