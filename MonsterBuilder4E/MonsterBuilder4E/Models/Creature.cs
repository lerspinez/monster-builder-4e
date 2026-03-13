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


/// <summary>
/// Describes an attack power for a monster in D&D 4E. 
/// This class includes properties that define the characteristics of the attack, such as its name, keywords, action type, power type, range, target information, and the effects of hitting or missing with the attack.
/// </summary>
public class AttackPower
{
    /// <summary>
    /// The name of the power available to the monster. 
    /// This is typically a descriptive name that indicates the nature of the attack, such as "Battleaxe", "Dragon Breath", "Magic Missile", etc.
    /// </summary>
    public string Name { get; set; } = "Attack";

    /// <summary>
    /// Keywords associated with the power, such as "Weapon", "Acid", "Fire", etc.
    /// Taken from the D&D 4E Power Keywords list, these keywords can indicate the type of damage, the source of the power, or any special traits it has.
    /// </summary>
    public List<PowerKeyword> Keywords { get; set; } = new();

    /// <summary>
    /// Defines the type of action required to use the power, such as Standard Action, Move Action, Minor Action, Free Action, etc.
    /// Taken from the action types defined in D&D 4E, this property indicates how the power can be used during combat and what kind of action economy it consumes.
    /// </summary>
    public ActionType ActionType { get; set; } = ActionType.Standard;

    /// <summary>
    /// Indicates of often the monster can use this power, such as At-Will (can be used any number of times), Encounter (can be used once per encounter), Daily (can be used once per day), etc.
    /// </summary>
    public PowerType PowerType { get; set; } = PowerType.AtWill;

    /// <summary>
    /// Additional usage about how the power can be used. For example, certain encounter powers may be used twice per encounter, but only once per round.
    /// </summary>
    public string? UsageInfo { get; set; }

    /// <summary>
    /// Flavor text for the power. A narrative description of the power's effects, how it works, and any special conditions or interactions it may have. 
    /// This is where you can add thematic details to make the power more interesting and flavorful.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Indicates if the attack has any specific requirements the monster must meet to use the power, such as having a certain condition, or being in a specific environment.
    /// </summary>
    public string? Requirement { get; set; }

    /// <summary>
    /// Used only for triggered actions, this property describes the specific trigger that causes the attack to occur.
    /// For example, "The monster is hit by a melee attack", "When an enemy ends its turn adjacent to the monster", etc.
    /// </summary>
    public string? Trigger { get; set; }

    /// <summary>
    /// Defines the type of attack, as defined in D&D 4E. This can be Melee (close combat), Ranged (attacks from a distance), Area (affects an area rather than a single target), or Close (affects targets within a certain radius).
    /// </summary>
    public AttackType AttackType { get; set; } = AttackType.Melee;

    /// <summary>
    /// Range of the attack, defined in squares as per D&D 4E rules.
    /// For example, a melee attack might have a range of "1" (adjacent squares), while a ranged attack might have a range of "20/40" (20 squares normal range, 40 squares maximum range).
    /// </summary>
    public string? Range { get; set; }

    /// <summary>
    /// Details about the target of the attack, such as "one creature", "all enemies in burst 1", "one creature you can see", etc. 
    /// This should be a clear and concise description of who or what the attack can affect.
    /// </summary>
    public string? TargetInfo { get; set; }

    /// <summary>
    /// Indicates if the power can be used as a basic attack. Only melee and ranged attacks can be basic attacks, and they must not have any special requirements or conditions to be used.
    /// In D&D 4E, basic attacks are standard attacks that a monster can use without any special conditions or requirements.
    /// </summary>
    public bool IsBasicAttack { get; set; }

    /// <summary>
    /// If a specific weapon from the monster's equipment is used for the attack, this property can specify the name of that weapon.
    /// This is optional and can be left null if the attack does not rely on a specific weapon or if it's a natural attack.
    /// </summary>
    public string? Weapon { get; set; }

    /// <summary>
    /// Defines which of the monster's abilities (Strength, Dexterity, Constitution, Intelligence, Wisdom, Charisma) is used for the attack roll.
    /// </summary>
    public Ability AttackAbility { get; set; } = Ability.Strength;

    /// <summary>
    /// Defines if the attack has any modifiers for its attack roll.
    /// In general, nimble monsters might have a positive modifier to their attack rolls, while brutish monsters might have a negative modifier.
    /// </summary>
    public int AttackModifier { get; set; } = 0;

    /// <summary>
    /// Indicates the defense that the attack targets, such as Armor Class, Fortitude, Reflex, or Will.
    /// This determines which of the monster's defenses the attack roll will be made against.
    /// </summary>
    public Defense Versus { get; set; } = Defense.ArmorClass;

    /// <summary>
    /// Contains the data for the power's "Hit" effect. 
    /// The Hit property includes details about the damage dealt on a successful hit, plus additional effects.
    /// </summary>
    public AttackHit Hit { get; set; } = new();

    /// <summary>
    /// Defines the type of effect that occurs when the power misses.
    /// This can include things like "half damage", "no damage", or any specific miss effects that the power might have.
    /// </summary>
    public AttackMiss Miss { get; set; } = AttackMiss.NoDamage;

    /// <summary>
    /// Describes any additional effects the power might have, such as conditions applied to the target, ongoing damage, or other special effects.
    /// These effects happen regardless of whether the attack hits or misses, and can include things like "The target is knocked prone", "The target takes ongoing 5 fire damage", etc.
    /// </summary>
    public string? Effect { get; set; }
}

/// <summary>
/// Contains the data for the power's "Hit" effect. 
/// Includes details about the damage dealt on a successful hit, plus additional effects.
/// </summary>
public class AttackHit
{
    /// <summary>
    /// The base damage of the attack, which can be a simple number (e.g., "10"), a dice expression (e.g., "2d6 + 3"), or a combination of both (e.g., "1d8 + 5").
    /// </summary>
    public string? BaseDamage { get; set; } = string.Empty;

    /// <summary>
    /// Defines the primary ability modifier used for the attack's damage calculation. 
    /// This is typically the same ability used for the attack roll, but it can be different if the power has specific rules that allow for it.
    /// </summary>
    public Ability? AbilityModifier { get; set; }

    /// <summary>
    /// Defines additional ability modifiers that can be added to the attack's damage calculation.
    /// </summary>
    public List<Ability> SecondaryAbilityModifiers { get; set; } = new();

    /// <summary>
    /// If the power has a specific modifier to its damage, this property can specify that bonus.
    /// </summary>
    public int DamageModifier { get; set; }

    /// <summary>
    /// Defines the type of damage dealt by the attack.
    /// Damage types in D&D 4E include Acid, Cold, Fire, Force, Lightning, Necrotic, Poison, Psychic, Radiant, Thunder, and more.
    /// </summary>
    public DamageType? DamageType { get; set; }

    /// <summary>
    /// Indicates if the attack has a critical hit effect, and if so, describes what that effect is.
    /// Critical hit effects are usually additional damage dice like "+1d12 damage", or special effects that occur on a critical hit, such as "target is stunned until the end of its next turn", "target takes ongoing 10 damage", etc.
    /// </summary>
    public string? CriticalHit { get; set; }

    /// <summary>
    /// Defines any other effect that happens on a successful hit, such as conditions applied to the target, ongoing damage, or other special effects.
    /// Effects like this are formatted like "[damage], and [effect]", for example: "2d6 + 3 fire damage, and the target is knocked prone".
    /// </summary>
    public string? HitEffect { get; set; }

    public string ToText()
    {
        string damageText = string.Empty;

        if(!string.IsNullOrWhiteSpace(BaseDamage))
        {
            damageText = BaseDamage;

            if(AbilityModifier.HasValue)
                damageText += " + ";
        }

        //Add ability modifier, enhancement bonus and damage modifier.

        if (DamageType.HasValue)
            damageText += $" {DamageType.ToString()!.ToLower()}";

        damageText += $" damage";

        if (!string.IsNullOrEmpty(CriticalHit))
        {
            damageText += $", Critical Hit: {CriticalHit}";
        }

        if (!string.IsNullOrEmpty(HitEffect))
            damageText += $", and {HitEffect}";

        return damageText;
    }
}



public class CreatureTrait
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
}


