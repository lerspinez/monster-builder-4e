using MonsterBuilder4E.Enums;
using MonsterBuilder4E.Utility;

namespace MonsterBuilder4E.Models;

public class Creature
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;


    public int Level { get; set; }
    public int LevelBonus => (int)Math.Floor(Level / 2.0);


    public Role Role { get; set; }
    public RoleModifier RoleModifier { get; set; }


    public int XP => MonsterStats.CalculateXP(this);


    public CreatureSize Size { get; set; } = CreatureSize.Medium;
    public CreatureOrigin Origin { get; set; }
    public CreatureType Type { get; set; }
    public string CreatureKeywords { get; set; } = string.Empty;
    public string Race { get; set; } = string.Empty;

    public AbilityScores Abilities { get; set; } = new();

    public int Initiative { get; set; } //GetInitiative method in MonsterStats
    public string Senses { get; set; } = string.Empty; //GetSenses method in MonsterStats


    public int HitPoints => MonsterStats.CalculateHitPoints(this);


    public List<string> ImmuneConditions { get; set; } = new();
    public List<string> Resistances { get; set; } = new();
    public List<string> Vulnerabilities { get; set; } = new();


    //Defenses
    public int ArmorClass => MonsterStats.CalculateDefense(this, Defense.ArmorClass);
    public int Fortitude => MonsterStats.CalculateDefense(this, Defense.Fortitude);
    public int Reflex => MonsterStats.CalculateDefense(this, Defense.Reflex);
    public int Will => MonsterStats.CalculateDefense(this, Defense.Will);


    //Savings Throws

    //Action Points


    public int Speed { get; set; }
    public string SpecialMovement { get; set; } = string.Empty;


    public List<CreatureTrait> Traits { get; set; } = new();

    //Actions

    //Triggered Actions

    public List<CreaturePower> Powers { get; set; } = new();


    public List<Skill> TrainedSkills { get; set; } = new();
    public List<string> Skills => MonsterStats.CalculateSkills(this);
    public AbilityCheckModifiers AbilityCheckModifiers => MonsterStats.GetAbilityCheckModifiers(this);


    public Alignment Alignment { get; set; } = Alignment.Unaligned;
    public string Languages { get; set; } = string.Empty;
    public string Equipment { get; set; } = string.Empty;


    public int EnhancementBonus { get; set; } = 0;
}

public class CreaturePower
{
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string Usage { get; set; } = string.Empty;
    public ActionType ActionType { get; set; }
    public string Range { get; set; } = string.Empty;
    public string Attack { get; set; } = string.Empty;
    public string Target { get; set; } = string.Empty;
    public string Hit { get; set; } = string.Empty;
    public string Miss { get; set; } = string.Empty;
    public string Effect { get; set; } = string.Empty;
    public string Trigger { get; set; } = string.Empty;
    public string Keywords { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}

public class CreatureTrait
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
}


