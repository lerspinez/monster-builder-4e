using MonsterBuilder4E.Enums;
using MonsterBuilder4E.Models;

namespace MonsterBuilder4E.Utility
{
    public static class PregenMonsters
    {
        public static Creature GetRandomMonster()
        {
            var random = new Random();
            int choice = random.Next(1, 6);

            return choice switch
            {
                1 => CreateLevel1Goblin(),
                2 => CreateLevel2Orc(),
                3 => CreateLevel3Ogre(),
                4 => CreateLevel4Drake(),
                5 => CreateLevel5Troll(),
                _ => CreateLevel1Goblin()
            };
        }

        public static Creature CreateLevel1Goblin()
        {
            var goblin = new Creature
            {
                Name = "Goblin Warrior",
                Level = 1,
                Role = Role.Skirmisher,
                RoleModifier = RoleModifier.None,
                Origin = CreatureOrigin.Natural,
                Type = CreatureType.Humanoid,
                CreatureKeywords = "goblin",
                Size = CreatureSize.Small,
                Abilities = new AbilityScores
                {
                    Strength = new AbilityScore { Score = 13 },
                    Constitution = new AbilityScore { Score = 12 },
                    Dexterity = new AbilityScore { Score = 17 },
                    Intelligence = new AbilityScore { Score = 8 },
                    Wisdom = new AbilityScore { Score = 10 },
                    Charisma = new AbilityScore { Score = 8 }
                },
                Speed = 6,
                Alignment = Alignment.Evil,
                Languages = new List<string> { "Common", "Goblin" },
                Senses = "Perception +0; low-light vision"
            };

            goblin.Initiative = MonsterStats.CalculateInitiative(goblin);

            goblin.TrainedSkills.Add(Skill.Stealth);
            goblin.Equipment = new List<string> { "short sword", "leather armor" };

            goblin.Traits.Add(new Trait
            {
                Name = "Goblin Tactics",
                Effect = "The goblin gains a +2 bonus to AC while at least two allies are within 5 squares of it."
            });

            goblin.Powers.Add(new Power
            {
                Name = "Short Sword",
                PowerType = PowerType.AtWill,
                ActionType = ActionType.Standard,
                Keywords = "weapon",
                IsAttack = true,
                Range = "Melee 1",
                TargetInfo = "One creature",
                TargetDefense = Defense.ArmorClass,
                AttackAbility = Ability.Strength,
                OnHit = new AttackHit { BaseDamage = "1d6 + 3" }
            });

            goblin.Powers.Add(new Power
            {
                Name = "Javelin",
                PowerType = PowerType.AtWill,
                ActionType = ActionType.Standard,
                Keywords = "weapon",
                IsAttack = true,
                Range = "Ranged 10/20",
                TargetInfo = "One creature",
                TargetDefense = Defense.ArmorClass,
                AttackAbility = Ability.Dexterity,
                OnHit = new AttackHit { BaseDamage = "1d6 + 3" }
            });

            return goblin;
        }

        public static Creature CreateLevel2Orc()
        {
            var orc = new Creature
            {
                Name = "Orc Raider",
                Level = 2,
                Role = Role.Brute,
                RoleModifier = RoleModifier.None,
                Origin = CreatureOrigin.Natural,
                Type = CreatureType.Humanoid,
                CreatureKeywords = "orc",
                Size = CreatureSize.Medium,
                Abilities = new AbilityScores
                {
                    Strength = new AbilityScore { Score = 16 },
                    Constitution = new AbilityScore { Score = 14 },
                    Dexterity = new AbilityScore { Score = 12 },
                    Intelligence = new AbilityScore { Score = 8 },
                    Wisdom = new AbilityScore { Score = 11 },
                    Charisma = new AbilityScore { Score = 10 }
                },
                Speed = 6,
                Alignment = Alignment.ChaoticEvil,
                Languages = new List<string> { "Common", "Giant" },
                Senses = "Perception +1; low-light vision"
            };

            orc.Initiative = MonsterStats.CalculateInitiative(orc);

            orc.TrainedSkills.Add(Skill.Intimidate);
            orc.Equipment = new List<string> { "greataxe", "hide armor" };

            orc.Traits.Add(new Trait
            {
                Name = "Warrior's Surge",
                Effect = "While bloodied, the orc gains a +2 bonus to attack rolls."
            });

            orc.Powers.Add(new Power
            {
                Name = "Greataxe",
                PowerType = PowerType.AtWill,
                ActionType = ActionType.Standard,
                Keywords = "weapon",
                IsAttack = true,
                Range = "Melee 1",
                TargetInfo = "One creature",
                TargetDefense = Defense.ArmorClass,
                AttackAbility = Ability.Strength,
                OnHit = new AttackHit { BaseDamage = "1d12 + 3" }
            });

            orc.Powers.Add(new Power
            {
                Name = "Handaxe",
                PowerType = PowerType.AtWill,
                ActionType = ActionType.Standard,
                Keywords = "weapon",
                IsAttack = true,
                Range = "Melee 1 or Ranged 5/10",
                TargetInfo = "One creature",
                TargetDefense = Defense.ArmorClass,
                AttackAbility = Ability.Strength,
                OnHit = new AttackHit { BaseDamage = "1d6 + 3" }
            });

            return orc;
        }

        public static Creature CreateLevel3Ogre()
        {
            var ogre = new Creature
            {
                Name = "Ogre Savage",
                Level = 3,
                Role = Role.Brute,
                RoleModifier = RoleModifier.None,
                Origin = CreatureOrigin.Natural,
                Type = CreatureType.Humanoid,
                CreatureKeywords = "giant",
                Size = CreatureSize.Large,
                Abilities = new AbilityScores
                {
                    Strength = new AbilityScore { Score = 19 },
                    Constitution = new AbilityScore { Score = 16 },
                    Dexterity = new AbilityScore { Score = 10 },
                    Intelligence = new AbilityScore { Score = 6 },
                    Wisdom = new AbilityScore { Score = 11 },
                    Charisma = new AbilityScore { Score = 6 }
                },
                Speed = 8,
                Alignment = Alignment.ChaoticEvil,
                Languages = new List<string> { "Giant" },
                Senses = "Perception +1"
            };

            ogre.Initiative = MonsterStats.CalculateInitiative(ogre);

            ogre.Equipment = new List<string> { "greatclub", "hide armor" };

            ogre.Powers.Add(new Power
            {
                Name = "Greatclub",
                PowerType = PowerType.AtWill,
                ActionType = ActionType.Standard,
                Keywords = "weapon",
                IsAttack = true,
                Range = "Reach 2",
                TargetInfo = "One creature",
                TargetDefense = Defense.ArmorClass,
                AttackAbility = Ability.Strength,
                OnHit = new AttackHit { BaseDamage = "2d6 + 4", HitEffect = "the ogre pushes the target 1 square" }
            });

            ogre.Powers.Add(new Power
            {
                Name = "Sweeping Club",
                PowerType = PowerType.Encounter,
                UsageInfo = "Recharge 5-6",
                ActionType = ActionType.Standard,
                Keywords = "weapon",
                IsAttack = true,
                Range = "Close blast 2",
                TargetInfo = "Creatures in blast",
                TargetDefense = Defense.ArmorClass,
                AttackAbility = Ability.Strength,
                OnHit = new AttackHit { BaseDamage = "1d6 + 4", HitEffect = "the ogre pushes the target 1 square" }
            });

            return ogre;
        }

        public static Creature CreateLevel4Drake()
        {
            var drake = new Creature
            {
                Name = "Guard Drake",
                Level = 4,
                Role = Role.Soldier,
                RoleModifier = RoleModifier.None,
                Origin = CreatureOrigin.Natural,
                Type = CreatureType.Beast,
                CreatureKeywords = "reptile",
                Size = CreatureSize.Large,
                Abilities = new AbilityScores
                {
                    Strength = new AbilityScore { Score = 18 },
                    Constitution = new AbilityScore { Score = 16 },
                    Dexterity = new AbilityScore { Score = 14 },
                    Intelligence = new AbilityScore { Score = 2 },
                    Wisdom = new AbilityScore { Score = 12 },
                    Charisma = new AbilityScore { Score = 10 }
                },
                Speed = 7,
                Alignment = Alignment.Unaligned,
                Languages = new List<string>(),
                Senses = "Perception +8; low-light vision"
            };

            drake.Initiative = MonsterStats.CalculateInitiative(drake);

            drake.TrainedSkills.Add(Skill.Athletics);

            drake.Traits.Add(new Trait
            {
                Name = "Threatening Reach",
                Effect = "The drake can make opportunity attacks against all enemies within 2 squares of it."
            });

            drake.Powers.Add(new Power
            {
                Name = "Bite",
                PowerType = PowerType.AtWill,
                ActionType = ActionType.Standard,
                Keywords = "",
                IsAttack = true,
                Range = "Reach 2",
                TargetInfo = "One creature",
                TargetDefense = Defense.ArmorClass,
                AttackAbility = Ability.Strength,
                OnHit = new AttackHit { BaseDamage = "1d10 + 4", HitEffect = "the target is marked until the end of the drake's next turn" }
            });

            drake.Powers.Add(new Power
            {
                Name = "Snapping Jaws",
                PowerType = PowerType.AtWill,
                ActionType = ActionType.ImmediateInterrupt,
                Keywords = "",
                IsAttack = true,
                Range = "Reach 2",
                TargetInfo = "One marked enemy that shifts",
                Trigger = "An enemy marked by the drake shifts",
                TargetDefense = Defense.ArmorClass,
                AttackAbility = Ability.Strength,
                OnHit = new AttackHit { BaseDamage = "1d10 + 4", HitEffect = "the target's movement ends" }
            });

            return drake;
        }

        public static Creature CreateLevel5Troll()
        {
            var troll = new Creature
            {
                Name = "Cave Troll",
                Level = 5,
                Role = Role.Brute,
                RoleModifier = RoleModifier.None,
                Origin = CreatureOrigin.Natural,
                Type = CreatureType.Humanoid,
                CreatureKeywords = "giant",
                Size = CreatureSize.Large,
                Abilities = new AbilityScores
                {
                    Strength = new AbilityScore { Score = 20 },
                    Constitution = new AbilityScore { Score = 18 },
                    Dexterity = new AbilityScore { Score = 12 },
                    Intelligence = new AbilityScore { Score = 6 },
                    Wisdom = new AbilityScore { Score = 12 },
                    Charisma = new AbilityScore { Score = 6 }
                },
                Speed = 8,
                Alignment = Alignment.ChaoticEvil,
                Languages = new List<string> { "Giant" },
                Senses = "Perception +2; darkvision"
            };

            troll.Initiative = MonsterStats.CalculateInitiative(troll);

            troll.Traits.Add(new Trait
            {
                Name = "Regeneration 5",
                Effect = "The troll regains 5 hit points whenever it starts its turn and has at least 1 hit point. If the troll takes acid or fire damage, regeneration does not function on its next turn."
            });

            troll.Traits.Add(new Trait
            {
                Name = "Troll Healing",
                Effect = "Whenever an ally within 5 squares of the troll uses second wind, the troll regains 5 hit points."
            });

            troll.Powers.Add(new Power
            {
                Name = "Claw",
                PowerType = PowerType.AtWill,
                ActionType = ActionType.Standard,
                Keywords = "",
                IsAttack = true,
                Range = "Reach 2",
                TargetInfo = "One creature",
                TargetDefense = Defense.ArmorClass,
                AttackAbility = Ability.Strength,
                OnHit = new AttackHit { BaseDamage = "2d6 + 5" }
            });

            troll.Powers.Add(new Power
            {
                Name = "Frenzy",
                PowerType = PowerType.AtWill,
                ActionType = ActionType.Standard,
                Keywords = "",
                IsAttack = true,
                Range = "Reach 2",
                TargetInfo = "One creature",
                TargetDefense = Defense.ArmorClass,
                AttackAbility = Ability.Strength,
                OnHit = new AttackHit { BaseDamage = "2d6 + 5" },
                Effect = "The troll makes a secondary attack against the same target. Secondary Attack: +8 vs. AC; 1d6 + 5 damage."
            });

            troll.Powers.Add(new Power
            {
                Name = "Vicious Rend",
                PowerType = PowerType.Encounter,
                ActionType = ActionType.Standard,
                Keywords = "",
                IsAttack = true,
                Range = "Reach 2",
                TargetInfo = "One creature",
                TargetDefense = Defense.ArmorClass,
                AttackAbility = Ability.Strength,
                OnHit = new AttackHit { BaseDamage = "3d6 + 5", HitEffect = "ongoing 5 damage (save ends)" }
            });

            return troll;
        }
    }
}
