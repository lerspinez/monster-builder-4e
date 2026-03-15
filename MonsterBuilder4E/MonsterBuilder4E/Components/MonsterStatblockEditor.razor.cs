using MonsterBuilder4E.Enums;
using MonsterBuilder4E.Models;
using MonsterBuilder4E.Utility;

namespace MonsterBuilder4E.Components;

public partial class MonsterStatblockEditor
{
    private Creature creature = new Creature();
    private IEnumerable<Skill> selectedSkills = new HashSet<Skill>();
    private string languagesText = string.Empty;

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
        selectedSkills = creature.TrainedSkills;

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
            Versus = Defense.ArmorClass,
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
            Versus = Defense.ArmorClass,
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

        languagesText = string.Join(", ", creature.Languages);

        // Calculate initiative
        creature.Initiative = MonsterStats.CalculateInitiative(creature);
    }

    protected override void OnParametersSet()
    {
        creature.TrainedSkills = selectedSkills.ToList();
        creature.Languages = ParseCommaDelimitedList(languagesText);
        creature.Initiative = MonsterStats.CalculateInitiative(creature);
    }

    private void AddPower()
    {
        creature.Powers.Add(new Power());
    }

    private void RemovePower(Power power)
    {
        creature.Powers.Remove(power);
    }

    private void SortPowers()
    {
        CollapseAllPowers();

        var nameSorted = creature.Powers.OrderBy(p => p.Name).ToList();

        creature.Powers = SortByActionType(nameSorted);
    }

    private static List<Power> SortByActionType(List<Power> powers)
    {
        return
        [
            .. SortByPowerType([.. powers.Where(p => p.ActionType == ActionType.Standard)]),
            .. SortByPowerType([.. powers.Where(p => p.ActionType == ActionType.Move)]),
            .. SortByPowerType([.. powers.Where(p => p.ActionType == ActionType.Minor)]),
            .. SortByPowerType([.. powers.Where(p => p.ActionType == ActionType.Free)]),
            .. SortByPowerType([.. powers.Where(p => p.ActionType == ActionType.NoAction)]),
        ];
    }

    private static List<Power> SortByPowerType(List<Power> powers)
    {
        return 
        [
            .. powers.Where(p => p.PowerType == PowerType.AtWill), 
            .. powers.Where(p => p.PowerType == PowerType.Recharge), 
            .. powers.Where(p => p.PowerType == PowerType.Encounter), 
            .. powers.Where(p => p.PowerType == PowerType.Daily)
        ];
    }

    private void CollapseAllPowers()
    {
        foreach (var power in creature.Powers)
        {
            power.ExpandEditor = false;
        }
    }

    private List<string> ParseCommaDelimitedList(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return new List<string>();

        return [.. text.Split(',').Select(s => s.Trim()).Where(s => !string.IsNullOrEmpty(s))];
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
