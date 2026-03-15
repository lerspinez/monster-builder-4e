using MonsterBuilder4E.Enums;
using MonsterBuilder4E.Models;

namespace MonsterBuilder4E.Utility
{
    public static class MonsterStats
    {
        // Maps each skill to its corresponding ability
        public static readonly Dictionary<Skill, Ability> SkillAbilities = new()
        {
            { Skill.Acrobatics, Ability.Dexterity },
            { Skill.Arcana, Ability.Intelligence },
            { Skill.Athletics, Ability.Strength },
            { Skill.Bluff, Ability.Charisma },
            { Skill.Diplomacy, Ability.Charisma },
            { Skill.Dungeoneering, Ability.Wisdom },
            { Skill.Endurance, Ability.Constitution },
            { Skill.Heal, Ability.Wisdom },
            { Skill.History, Ability.Intelligence },
            { Skill.Insight, Ability.Wisdom },
            { Skill.Intimidate, Ability.Charisma },
            { Skill.Nature, Ability.Wisdom },
            { Skill.Perception, Ability.Wisdom },
            { Skill.Religion, Ability.Intelligence },
            { Skill.Stealth, Ability.Dexterity },
            { Skill.Streetwise, Ability.Charisma },
            { Skill.Thievery, Ability.Dexterity }
        };

        public static int CalculateInitiative(Creature creature)
        {
            return creature.LevelBonus + creature.Abilities.Dexterity.Modifier;
        }

        public static int CalculateDefense(Creature creature, Defense defense)
        {
            int baseDefense = 10 + creature.LevelBonus + creature.EnhancementBonus;

            switch (defense)
            {
                case Defense.ArmorClass:
                    return baseDefense + Math.Max(creature.Abilities.Dexterity.Modifier, creature.Abilities.Intelligence.Modifier)
                        + creature.ArmorClassModifier;
                case Defense.Fortitude:
                    return baseDefense + Math.Max(creature.Abilities.Strength.Modifier, creature.Abilities.Constitution.Modifier)
                        + creature.FortitudeModifier;
                case Defense.Reflex:
                    return baseDefense + Math.Max(creature.Abilities.Dexterity.Modifier, creature.Abilities.Intelligence.Modifier)
                        + creature.ReflexModifier;
                case Defense.Will:
                    return baseDefense + Math.Max(creature.Abilities.Wisdom.Modifier, creature.Abilities.Charisma.Modifier)
                        + creature.WillModifier;
                default:
                    throw new NotImplementedException("Unsupported defense.");
            }
        }

        public static int CalculateHitPoints(Creature creature)
        {
            int baseHP = GetBaseHitPointsByRole(creature);
            int constitutionScore = creature.Abilities.Constitution.Score;
            return baseHP + constitutionScore;
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
                int abilityCheckModifier = GetAbilityCheckModifier(creature, GetSkillAbility(skill));
                int skillModifier = abilityCheckModifier + 5;

                skills.Add($"{skill} +{skillModifier}");
            }

            return skills;
        }

        private static Ability GetSkillAbility(Skill skill)
        {
            SkillAbilities.TryGetValue(skill, out Ability ability);
            return ability;
        }

        public static int GetAbilityCheckModifier(Creature creature, Ability ability)
        {
            return creature.LevelBonus + creature.Abilities.GetModifier(ability);
        }

        public static AbilityCheckModifiers GetAbilityCheckModifiers(Creature creature)
        {
            return new AbilityCheckModifiers
            {
                Strength = GetAbilityCheckModifier(creature, Ability.Strength),
                Constitution = GetAbilityCheckModifier(creature, Ability.Constitution),
                Dexterity = GetAbilityCheckModifier(creature, Ability.Dexterity),
                Intelligence = GetAbilityCheckModifier(creature, Ability.Intelligence),
                Wisdom = GetAbilityCheckModifier(creature, Ability.Wisdom),
                Charisma = GetAbilityCheckModifier(creature, Ability.Charisma)
            };
        }

        public static int GetAttackPowerModifier(Creature creature, Ability ability, int externalModifier = 0)
        {
            return GetAbilityCheckModifier(creature, ability) + creature.EnhancementBonus + externalModifier;
        }

        public static string GetAttackHitTextblock(Creature creature, AttackHit attackHit, bool includeCrit = false)
        {
            string hitTextblock = string.Empty;

            //Attack damage.

            string attackDamage = string.Empty;

            if (!string.IsNullOrWhiteSpace(attackHit.BaseDamage))
                attackDamage = attackHit.BaseDamage;

            //Try parse base damage and if number add to modifiers.

            int damageModifier = GetAttackPowerModifier(creature, attackHit.AbilityModifier, attackHit.DamageModifier);

            if (attackHit.SecondaryAbilityModifiers.Count != 0)
            {
                foreach (var ability in attackHit.SecondaryAbilityModifiers)
                {
                    damageModifier += creature.Abilities.GetModifier(ability);
                }
            }

            if (damageModifier != 0)
                attackDamage += damageModifier > 0 ? $"+{damageModifier}" : damageModifier.ToString();

            //If 0 damage and no base damage, then it's just a hit with no damage, so don't add anything to the textblock.

            var damageType = attackHit.DamageType != DamageType.Untyped 
                ? $"{Formatter.Enum(attackHit.DamageType.ToString(), true)} damage" : "damage";

            if (string.IsNullOrWhiteSpace(attackDamage))
                hitTextblock = "No damage";
            else
                hitTextblock += $"{attackDamage} {damageType}";

            //Damage annotation.

            string damageAnnotation = string.Empty;

            if (!string.IsNullOrWhiteSpace(attackHit.CriticalHit))
                damageAnnotation += $"Crit: {attackHit.CriticalHit}";

            if(damageAnnotation != string.Empty)
                hitTextblock += $" ({damageAnnotation})";

            //Additional on-hit effects.

            if (!string.IsNullOrEmpty(attackHit.HitEffect))
                hitTextblock += $", and {attackHit.HitEffect}";

            return hitTextblock;
        }
    }
}
