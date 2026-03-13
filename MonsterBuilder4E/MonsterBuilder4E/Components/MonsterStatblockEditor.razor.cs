using MonsterBuilder4E.Enums;
using MonsterBuilder4E.Models;
using MonsterBuilder4E.Utility;

namespace MonsterBuilder4E.Components;

public partial class MonsterStatblockEditor
{
    bool _basicStatsExpanded = true;
    bool _abilityScoresExpanded = true;
    bool _creatureVitalsExpanded = true;
    bool _combatStatsExpanded = false;
    bool _otherStatsExpanded = false;

    private void ExpandCollapseBasicStats()
    {
        _basicStatsExpanded = !_basicStatsExpanded;
    }

    private void ExpandCollapseAbilityScores()
    {
        _abilityScoresExpanded = !_abilityScoresExpanded;
    }

    private void ExpandCollapseCreatureVitals()
    {
        _creatureVitalsExpanded = !_creatureVitalsExpanded;
    }

    private void ExpandCollapseCombatStats()
    {
        _combatStatsExpanded = !_combatStatsExpanded;
    }

    private void ExpandCollapseOtherStats()
    {
        _otherStatsExpanded = !_otherStatsExpanded;
    }

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

    private void AddPower()
    {
        creature.Powers.Add(new CreaturePower());
    }

    private void RemovePower(CreaturePower power)
    {
        creature.Powers.Remove(power);
    }

    private List<string> ParseCommaDelimitedList(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return new List<string>();

        return text.Split(',')
            .Select(s => s.Trim())
            .Where(s => !string.IsNullOrEmpty(s))
            .ToList();
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
