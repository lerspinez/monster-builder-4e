using MonsterBuilder4E.Enums;
using MonsterBuilder4E.Models;
using MonsterBuilder4E.Utility;

namespace MonsterBuilder4E.Pages;

public partial class Edit
{
    private Creature creature = new Creature();

    protected override void OnInitialized()
    {
        // Initialize with default hobgoblin soldier data for demonstration
        creature.Name = "Redscale Fang";
        creature.Level = 4;
        creature.Role = Role.Soldier;
        creature.Size = CreatureSize.Medium;
        creature.Origin = CreatureOrigin.Natural;
        creature.Type = CreatureType.Humanoid;
        creature.CreatureKeywords = "dragonborn";
        creature.Abilities.Strength.Score = 16;
        creature.Abilities.Dexterity.Score = 14;
        creature.Abilities.Constitution.Score = 14;
        creature.Abilities.Intelligence.Score = 10;
        creature.Abilities.Wisdom.Score = 14;
        creature.Abilities.Charisma.Score = 12;
        creature.Speed = 6;
        creature.Alignment = Alignment.Unaligned;
        creature.Languages = new List<string> { "Draconic" };
        creature.Senses = "Darkvision";

        creature.ArmorClassModifier = 3 + 1;
        creature.FortitudeModifier = 2;
        creature.ReflexModifier = 1;

        creature.TrainedSkills = new List<Skill> { Skill.Athletics, Skill.Endurance, Skill.Intimidate };

        creature.Equipment = new List<string> { "hide armor", "longsword", "buckler", "pistol" };

        // Add Defender trait
        creature.Traits.Add(new Trait
        {
            Name = "Defender",
            IsAura = false,
            AuraRange = 1,
            Effect = "The redscale can mark any creature they attack in melee."
        });

        // Add Dragonborn Fury trait
        creature.Traits.Add(new Trait
        {
            Name = "Dragonborn Fury",
            IsAura = false,
            AuraRange = 1,
            Effect = "Gains +1 on attacks while bloodied."
        });

        // Add Longsword power (at-will melee attack)
        creature.Powers.Add(new Power
        {
            Name = "Longsword",
            PowerType = PowerType.AtWill,
            ActionType = ActionType.Standard,
            Keywords = "weapon",
            IsAttack = true,
            AttackType = Enums.AttackType.Melee,
            Range = "Melee 1",
            TargetDefense = Defense.ArmorClass,
            AttackAbility = Ability.Strength,
            AttackModifier = 3,
            OnHit = new AttackHit
            {
                BaseDamage = "1d8",
                AbilityModifier = Ability.Strength
            },
            Effect = "The redscale can shift 1 square after the attack."
        });

        // Add Pistol power (encounter ranged attack)
        creature.Powers.Add(new Power
        {
            Name = "Pistol",
            PowerType = PowerType.Encounter,
            ActionType = ActionType.Standard,
            Keywords = "weapon",
            IsAttack = true,
            AttackType = Enums.AttackType.Ranged,
            Range = "Ranged 3/7/15",
            TargetDefense = Defense.Reflex,
            AttackAbility = Ability.Dexterity,
            OnHit = new AttackHit
            {
                BaseDamage = "2d10",
                AbilityModifier = Ability.Dexterity,
                CriticalHit = "+1d10 damage"
            }
        });

        // Add Fire Breath power (encounter close attack)
        creature.Powers.Add(new Power
        {
            Name = "Fire Breath",
            PowerType = PowerType.Encounter,
            ActionType = ActionType.Standard,
            Keywords = "weapon",
            IsAttack = true,
            AttackType = Enums.AttackType.Ranged,
            Range = "Close blast 1",
            TargetDefense = Defense.Reflex,
            AttackAbility = Ability.Strength,
            AttackModifier = 2,
            OnHit = new AttackHit
            {
                BaseDamage = "2d4",
                AbilityModifier = Ability.Strength,
                DamageType = DamageType.Fire
            }
        });

        // Add Take Aim power (at-will move)
        creature.Powers.Add(new Power
        {
            Name = "Take Aim",
            PowerType = PowerType.AtWill,
            ActionType = ActionType.Move,
            IsAttack = false,
            Effect = "The redscale gains +4 bonus its next Pistol attack made this turn."
        });

        // Add Soldier's Retaliation (triggered action)
        //creature.Powers.Add(new Power
        //{
        //    Name = "Soldier's Retaliation",
        //    PowerType = PowerType.AtWill,
        //    ActionType = ActionType.ImmediateInterrupt,
        //    IsAttack = false,
        //    Trigger = "An enemy marked by the hobgoblin makes an attack that doesn't include the hobgoblin as a target",
        //    Effect = "The hobgoblin uses longsword on the triggering enemy."
        //});
    }
}
