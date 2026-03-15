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
        creature.Name = "Hobgoblin Soldier";
        creature.Level = 4;
        creature.Role = Role.Soldier;
        creature.Size = CreatureSize.Medium;
        creature.Origin = CreatureOrigin.Natural;
        creature.Type = CreatureType.Humanoid;
        creature.CreatureKeywords = "goblinoid";
        creature.Abilities.Strength.Score = 18;
        creature.Abilities.Dexterity.Score = 14;
        creature.Abilities.Constitution.Score = 16;
        creature.Abilities.Intelligence.Score = 10;
        creature.Abilities.Wisdom.Score = 12;
        creature.Abilities.Charisma.Score = 11;
        creature.Speed = 6;
        creature.Alignment = Alignment.Evil;
        creature.Languages = new List<string> { "Common", "Goblin" };
        creature.Senses = "Perception +3; low-light vision";

        creature.TrainedSkills = new List<Skill> { Skill.Athletics, Skill.Intimidate };

        creature.Equipment = new List<string> { "longsword", "chainmail", "heavy shield", "crossbow" };

        // Add Phalanx Soldier trait (aura)
        creature.Traits.Add(new Trait
        {
            Name = "Phalanx Soldier",
            IsAura = true,
            AuraRange = 1,
            Effect = "The hobgoblin gains a +2 bonus to AC while at least two hobgoblin allies are within the aura."
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
            TargetInfo = "One creature",
            TargetDefense = Defense.ArmorClass,
            AttackAbility = Ability.Strength,
            OnHit = new AttackHit
            {
                BaseDamage = "1d8 + 5",
                HitEffect = "the target is marked until the end of the hobgoblin's next turn"
            }
        });

        // Add Crossbow Volley power (encounter ranged attack)
        creature.Powers.Add(new Power
        {
            Name = "Crossbow Volley",
            PowerType = PowerType.Encounter,
            ActionType = ActionType.Standard,
            Keywords = "weapon",
            IsAttack = true,
            AttackType = Enums.AttackType.Ranged,
            Range = "Ranged 15/30",
            TargetInfo = "One creature",
            TargetDefense = Defense.ArmorClass,
            AttackAbility = Ability.Dexterity,
            OnHit = new AttackHit
            {
                BaseDamage = "2d8 + 4"
            }
        });

        // Add Soldier's Retaliation (triggered action)
        creature.Powers.Add(new Power
        {
            Name = "Soldier's Retaliation",
            PowerType = PowerType.AtWill,
            ActionType = ActionType.ImmediateInterrupt,
            IsAttack = false,
            Trigger = "An enemy marked by the hobgoblin makes an attack that doesn't include the hobgoblin as a target",
            Effect = "The hobgoblin uses longsword on the triggering enemy."
        });

        // Calculate initiative
        creature.Initiative = MonsterStats.CalculateInitiative(creature);
    }

    private string FormatModifier(int value)
    {
        return value >= 0 ? $"+{value}" : value.ToString();
    }

    private string GetPowerIcon(PowerType powerType)
    {
        return powerType switch
        {
            PowerType.AtWill => "⚔",
            PowerType.Encounter => "⬢",
            PowerType.Daily => "◉",
            _ => "○"
        };
    }

    private string FormatAttack(Power power)
    {
        int attackBonus = creature.LevelBonus + creature.Abilities.GetModifier(power.AttackAbility) + power.AttackModifier;
        return FormatModifier(attackBonus);
    }
}
