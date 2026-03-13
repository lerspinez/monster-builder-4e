using MonsterBuilder4E.Enums;

namespace MonsterBuilder4E.Models;

public class AbilityScores
{
    public AbilityScore Strength { get; set; } = new();
    public AbilityScore Constitution { get; set; } = new();
    public AbilityScore Dexterity { get; set; } = new();
    public AbilityScore Intelligence { get; set; } = new();
    public AbilityScore Wisdom { get; set; } = new();
    public AbilityScore Charisma { get; set; } = new();

    public int GetScore(Ability ability)
    {
        return ability switch
        {
            Ability.Strength => Strength.Score,
            Ability.Constitution => Constitution.Score,
            Ability.Dexterity => Dexterity.Score,
            Ability.Intelligence => Intelligence.Score,
            Ability.Wisdom => Wisdom.Score,
            Ability.Charisma => Charisma.Score,
            _ => 0
        };
    }

    public int GetModifier(Ability ability)
    {
        return ability switch
        {
            Ability.Strength => Strength.Modifier,
            Ability.Constitution => Constitution.Modifier,
            Ability.Dexterity => Dexterity.Modifier,
            Ability.Intelligence => Intelligence.Modifier,
            Ability.Wisdom => Wisdom.Modifier,
            Ability.Charisma => Charisma.Modifier,
            _ => 0
        };
    }
}

public class AbilityScore
{
    public int Score { get; set; } = 10;
    public int Modifier => (int)Math.Floor((Score - 10) / 2.0);

    public AbilityScore(int score = 10)
    {
        Score = score;
    }
}

public class AbilityCheckModifiers
{
    public int Strength { get; set; }
    public int Constitution { get; set; }
    public int Dexterity { get; set; }
    public int Intelligence { get; set; }
    public int Wisdom { get; set; }
    public int Charisma { get; set; }
}