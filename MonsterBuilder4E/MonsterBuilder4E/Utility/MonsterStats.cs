using MonsterBuilder4E.Models;

namespace MonsterBuilder4E.Utility
{
    public static class MonsterStats
    {
        // Maps each skill to its corresponding ability
        public static readonly Dictionary<Skill, string> SkillAbilities = new()
        {
            { Skill.Acrobatics, "Dexterity" },
            { Skill.Arcana, "Intelligence" },
            { Skill.Athletics, "Strength" },
            { Skill.Bluff, "Charisma" },
            { Skill.Diplomacy, "Charisma" },
            { Skill.Dungeoneering, "Wisdom" },
            { Skill.Endurance, "Constitution" },
            { Skill.Heal, "Wisdom" },
            { Skill.History, "Intelligence" },
            { Skill.Insight, "Wisdom" },
            { Skill.Intimidate, "Charisma" },
            { Skill.Nature, "Wisdom" },
            { Skill.Perception, "Wisdom" },
            { Skill.Religion, "Intelligence" },
            { Skill.Stealth, "Dexterity" },
            { Skill.Streetwise, "Charisma" },
            { Skill.Thievery, "Dexterity" }
        };

        public static int CalculateInitiative(Creature creature)
        {
            return creature.LevelBonus + creature.Dexterity.Modifier;
        }

        public static int CalculateDefense(Creature creature, string defenseType)
        {
            int baseDefense = 10 + creature.Level;

            switch (defenseType.ToLower())
            {
                case "ac":
                    return baseDefense + Math.Max(creature.Dexterity.Modifier, creature.Intelligence.Modifier);
                case "fortitude":
                    return baseDefense + Math.Max(creature.Strength.Modifier, creature.Constitution.Modifier);
                case "reflex":
                    return baseDefense + Math.Max(creature.Dexterity.Modifier, creature.Intelligence.Modifier);
                case "will":
                    return baseDefense + Math.Max(creature.Wisdom.Modifier, creature.Charisma.Modifier);
                default:
                    return baseDefense;
            }
        }

        public static int CalculateHitPoints(Creature creature)
        {
            int baseHP = GetBaseHitPointsByRole(creature);
            int constitutionBonus = creature.Constitution.Modifier * creature.Level;
            return baseHP + constitutionBonus;
        }

        private static int GetBaseHitPointsByRole(Creature creature)
        {
            if (creature.RoleModifier == RoleModifier.Minion) return 1;

            return creature.Role switch
            {
                Role.Artillery => 6 + creature.Level * 6,
                Role.Brute => 10 + creature.Level * 10,
                Role.Controller => 8 + creature.Level * 8,
                Role.Lurker => 6 + creature.Level * 6,
                Role.Skirmisher => 8 + creature.Level * 8,
                Role.Soldier => 8 + creature.Level * 8,
                _ => 8 + creature.Level * 8
            };
        }

        public static int CalculateXP(Creature creature)
        {
            int baseXP = creature.Level switch
            {
                1 => 100,
                2 => 125,
                3 => 150,
                4 => 175,
                5 => 200,
                6 => 250,
                7 => 300,
                8 => 350,
                9 => 400,
                10 => 500,
                11 => 600,
                12 => 700,
                13 => 800,
                14 => 1000,
                15 => 1200,
                16 => 1400,
                17 => 1600,
                18 => 2000,
                19 => 2400,
                20 => 2800,
                21 => 3200,
                22 => 4150,
                23 => 5100,
                24 => 6050,
                25 => 7000,
                26 => 9000,
                27 => 11000,
                28 => 13000,
                29 => 15000,
                30 => 19000,
                _ => creature.Level * 100
            };

            return creature.RoleModifier switch
            {
                RoleModifier.Minion => baseXP / 4,
                RoleModifier.Elite => baseXP * 2,
                RoleModifier.Solo => baseXP * 5,
                _ => baseXP
            };
        }

        public static List<string> CalculateSkills(Creature creature)
        {
            var skills = new List<string>();

            foreach (var skill in creature.TrainedSkills)
            {
                if (skill == Skill.None) continue;

                int abilityModifier = GetAbilityModifierForSkill(creature, skill);
                int skillBonus = creature.LevelBonus + abilityModifier + 5; // +5 training bonus in 4E

                skills.Add($"{skill} +{skillBonus}");
            }

            return skills;
        }

        private static int GetAbilityModifierForSkill(Creature creature, Skill skill)
        {
            if (!SkillAbilities.TryGetValue(skill, out string? abilityName))
                return 0;

            return abilityName switch
            {
                "Strength" => creature.Strength.Modifier,
                "Constitution" => creature.Constitution.Modifier,
                "Dexterity" => creature.Dexterity.Modifier,
                "Intelligence" => creature.Intelligence.Modifier,
                "Wisdom" => creature.Wisdom.Modifier,
                "Charisma" => creature.Charisma.Modifier,
                _ => 0
            };
        }
    }
}
