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

    private void AddTrait()
    {
        creature.Traits.Add(new CreatureTrait());
    }

    private void RemoveTrait(CreatureTrait trait)
    {
        creature.Traits.Remove(trait);
    }

    private void SortTraits()
    {
        CollapseAllTraits();

        creature.Traits = [.. creature.Traits.OrderByDescending(t => t.IsAura).ThenBy(t => t.Name)];
    }

    private void CollapseAllTraits()
    {
        foreach (var trait in creature.Traits)
        {
            trait.ExpandEditor = false;
        }
    }

    private void AddPower()
    {
        creature.Powers.Add(new CreaturePower());
    }

    private void RemovePower(CreaturePower power)
    {
        creature.Powers.Remove(power);
    }

    private void SortPowers()
    {
        CollapseAllPowers();

        var nameSorted = creature.Powers.OrderBy(p => p.Name).ToList();

        creature.Powers = SortByActionType(nameSorted);
    }

    private static List<CreaturePower> SortByActionType(List<CreaturePower> powers)
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

    private static List<CreaturePower> SortByPowerType(List<CreaturePower> powers)
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

    private string FormatAttack(CreaturePower power)
    {
        int attackBonus = creature.LevelBonus + creature.Abilities.GetModifier(power.AttackAbility) + power.AttackModifier;
        return FormatModifier(attackBonus);
    }
}
