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
                Origin = Origin.Natural,
                Type = CreatureType.Humanoid,
                CreatureKeywords = "goblin",
                Size = Size.Small,
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
                Languages = "Common, Goblin",
                Senses = "Perception +0; low-light vision"
            };

            goblin.Initiative = MonsterStats.CalculateInitiative(goblin);

            goblin.TrainedSkills.Add(Skill.Stealth);
            goblin.Equipment = "short sword, leather armor";

            goblin.Traits.Add(new CreatureTrait
            {
                Name = "Goblin Tactics",
                Description = "The goblin gains a +2 bonus to AC while at least two allies are within 5 squares of it.",
                Type = "Passive"
            });

            goblin.Powers.Add(new CreaturePower
            {
                Name = "Short Sword",
                Usage = "At-Will",
                ActionType = ActionType.Standard,
                Keywords = "Weapon",
                Range = "Melee 1",
                Target = "One creature",
                Attack = "+6 vs. AC",
                Hit = "1d6 + 3 damage"
            });

            goblin.Powers.Add(new CreaturePower
            {
                Name = "Javelin",
                Usage = "At-Will",
                ActionType = ActionType.Standard,
                Keywords = "Weapon",
                Range = "Ranged 10/20",
                Target = "One creature",
                Attack = "+6 vs. AC",
                Hit = "1d6 + 3 damage"
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
                Origin = Origin.Natural,
                Type = CreatureType.Humanoid,
                CreatureKeywords = "orc",
                Size = Size.Medium,
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
                Languages = "Common, Giant",
                Senses = "Perception +1; low-light vision"
            };

            orc.Initiative = MonsterStats.CalculateInitiative(orc);

            orc.TrainedSkills.Add(Skill.Intimidate);
            orc.Equipment = "greataxe, hide armor";

            orc.Traits.Add(new CreatureTrait
            {
                Name = "Warrior's Surge",
                Description = "While bloodied, the orc gains a +2 bonus to attack rolls.",
                Type = "Passive"
            });

            orc.Powers.Add(new CreaturePower
            {
                Name = "Greataxe",
                Usage = "At-Will",
                ActionType = ActionType.Standard,
                Keywords = "Weapon",
                Range = "Melee 1",
                Target = "One creature",
                Attack = "+7 vs. AC",
                Hit = "1d12 + 3 damage"
            });

            orc.Powers.Add(new CreaturePower
            {
                Name = "Handaxe",
                Usage = "At-Will",
                ActionType = ActionType.Standard,
                Keywords = "Weapon",
                Range = "Melee 1 or Ranged 5/10",
                Target = "One creature",
                Attack = "+7 vs. AC",
                Hit = "1d6 + 3 damage"
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
                Origin = Origin.Natural,
                Type = CreatureType.Humanoid,
                CreatureKeywords = "giant",
                Size = Size.Large,
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
                Languages = "Giant",
                Senses = "Perception +1"
            };

            ogre.Initiative = MonsterStats.CalculateInitiative(ogre);

            ogre.Equipment = "greatclub, hide armor";

            ogre.Powers.Add(new CreaturePower
            {
                Name = "Greatclub",
                Usage = "At-Will",
                ActionType = ActionType.Standard,
                Keywords = "Weapon",
                Range = "Reach 2",
                Target = "One creature",
                Attack = "+8 vs. AC",
                Hit = "2d6 + 4 damage, and the ogre pushes the target 1 square"
            });

            ogre.Powers.Add(new CreaturePower
            {
                Name = "Sweeping Club",
                Usage = "Recharge 5-6",
                ActionType = ActionType.Standard,
                Keywords = "Weapon",
                Range = "Close blast 2",
                Target = "Creatures in blast",
                Attack = "+6 vs. AC",
                Hit = "1d6 + 4 damage, and the ogre pushes the target 1 square"
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
                Origin = Origin.Natural,
                Type = CreatureType.Beast,
                CreatureKeywords = "reptile",
                Size = Size.Large,
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
                Languages = "",
                Senses = "Perception +8; low-light vision"
            };

            drake.Initiative = MonsterStats.CalculateInitiative(drake);

            drake.TrainedSkills.Add(Skill.Athletics);
            drake.Resistances.Add("fire 5");

            drake.Traits.Add(new CreatureTrait
            {
                Name = "Threatening Reach",
                Description = "The drake can make opportunity attacks against all enemies within 2 squares of it.",
                Type = "Passive"
            });

            drake.Powers.Add(new CreaturePower
            {
                Name = "Bite",
                Usage = "At-Will",
                ActionType = ActionType.Standard,
                Keywords = "",
                Range = "Reach 2",
                Target = "One creature",
                Attack = "+9 vs. AC",
                Hit = "1d10 + 4 damage, and the target is marked until the end of the drake's next turn"
            });

            drake.Powers.Add(new CreaturePower
            {
                Name = "Snapping Jaws",
                Usage = "At-Will",
                ActionType = ActionType.ImmediateInterrupt,
                Keywords = "",
                Range = "Reach 2",
                Target = "One marked enemy that shifts",
                Attack = "+9 vs. AC",
                Hit = "1d10 + 4 damage, and the target's movement ends"
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
                Origin = Origin.Natural,
                Type = CreatureType.Humanoid,
                CreatureKeywords = "giant",
                Size = Size.Large,
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
                Languages = "Giant",
                Senses = "Perception +2; darkvision"
            };

            troll.Initiative = MonsterStats.CalculateInitiative(troll);

            troll.Vulnerabilities.Add("fire 5");
            troll.Vulnerabilities.Add("acid 5");

            troll.Traits.Add(new CreatureTrait
            {
                Name = "Regeneration 5",
                Description = "The troll regains 5 hit points whenever it starts its turn and has at least 1 hit point. If the troll takes acid or fire damage, regeneration does not function on its next turn.",
                Type = "Passive"
            });

            troll.Traits.Add(new CreatureTrait
            {
                Name = "Troll Healing",
                Description = "Whenever an ally within 5 squares of the troll uses second wind, the troll regains 5 hit points.",
                Type = "Passive"
            });

            troll.Powers.Add(new CreaturePower
            {
                Name = "Claw",
                Usage = "At-Will",
                ActionType = ActionType.Standard,
                Keywords = "",
                Range = "Reach 2",
                Target = "One creature",
                Attack = "+10 vs. AC",
                Hit = "2d6 + 5 damage"
            });

            troll.Powers.Add(new CreaturePower
            {
                Name = "Frenzy",
                Usage = "At-Will",
                ActionType = ActionType.Standard,
                Keywords = "",
                Range = "Reach 2",
                Target = "One creature",
                Attack = "+8 vs. AC",
                Hit = "2d6 + 5 damage",
                Effect = "The troll makes a secondary attack against the same target. Secondary Attack: +8 vs. AC; 1d6 + 5 damage."
            });

            troll.Powers.Add(new CreaturePower
            {
                Name = "Vicious Rend",
                Usage = "Encounter",
                ActionType = ActionType.Standard,
                Keywords = "",
                Range = "Reach 2",
                Target = "One creature",
                Attack = "+10 vs. AC",
                Hit = "3d6 + 5 damage, and ongoing 5 damage (save ends)"
            });

            return troll;
        }
    }
}
