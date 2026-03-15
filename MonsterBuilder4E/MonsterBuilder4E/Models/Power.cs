using MonsterBuilder4E.Enums;

namespace MonsterBuilder4E.Models;

/// <summary>
/// Describes a power for a monster in D&D 4E. 
/// This class includes properties that define the characteristics of the power, such as its name, keywords, action type, power type, range, target information, and the effects of hitting or missing with the attack.
/// </summary>
public class Power
{
    /// <summary>
    /// The name of the power available to the monster. 
    /// This is typically a descriptive name that indicates the nature of the power, such as "Battleaxe", "Dragon Breath", "Magic Missile", "Cure Light Wounds", etc.
    /// </summary>
    public string Name { get; set; } = "Power";

    /// <summary>
    /// Keywords associated with the power, such as "Weapon", "Acid", "Fire", "Healing", etc.
    /// Taken from the D&D 4E Power Keywords list, these keywords can indicate the type of damage, the source of the power, or any special traits it has.
    /// </summary>
    public string Keywords { get; set; } = string.Empty;

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
    /// Indicates if the attack has any specific requirements the monster must meet to use the power, such as having a certain condition, or being in a specific environment.
    /// </summary>
    public string? Requirement { get; set; }

    /// <summary>
    /// Used only for triggered actions, this property describes the specific trigger that causes the attack to occur.
    /// For example, "The monster is hit by a melee attack", "When an enemy ends its turn adjacent to the monster", etc.
    /// </summary>
    public string? Trigger { get; set; }

    /// <summary>
    /// Indicates if the power is an attack power, which means it involves making an attack roll against a target's defense.
    /// </summary>
    public bool IsAttack { get; set; }

    /// <summary>
    /// Defines the type of attack, as defined in D&D 4E. This can be Melee (close combat), Ranged (attacks from a distance), Area (affects an area rather than a single target), or Close (affects targets within a certain radius).
    /// </summary>
    public AttackType? AttackType { get; set; }

    /// <summary>
    /// Indicates if the power can be used as a basic attack. Only melee and ranged attacks can be basic attacks, and they must not have any special requirements or conditions to be used.
    /// In D&D 4E, basic attacks are standard attacks that a monster can use without any special conditions or requirements.
    /// </summary>
    public bool IsBasicAttack { get; set; }

    /// <summary>
    /// Range of the power, defined in squares as per D&D 4E rules.
    /// For example, a melee attack might have a range of "Melee 1" (adjacent squares), while a ranged attack might have a range of "Ranged 20/40" (20 squares normal range, 40 squares maximum range).
    /// </summary>
    public string? Range { get; set; }

    /// <summary>
    /// Details about the target of the power, such as "one creature", "all enemies in burst 1", "one creature you can see", etc. 
    /// This should be a clear and concise description of who or what the attack can affect.
    /// </summary>
    public string? TargetInfo { get; set; }

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
    /// Contains the data for the power's "On Hit" effect. 
    /// The Hit property includes details about the damage dealt on a successful hit, plus additional effects.
    /// </summary>
    public AttackHit OnHit { get; set; } = new();

    /// <summary>
    /// Contains the data for the power's "On Miss" effect. 
    /// This can include things like "half damage", "no damage", or any specific miss effects that the power might have.
    /// </summary>
    public AttackMiss OnMiss { get; set; } = AttackMiss.NoDamage;

    /// <summary>
    /// Describes any effects the power has when it misses its target or targets.
    /// </summary>
    public string? MissEffect { get; set; }

    /// <summary>
    /// Describes the effect of the power, which can include conditions applied to the target, ongoing damage, forced movement, or any other special effects that occur when the power is used.
    /// For attack powers, this effect happens regardless of whether the attack hits or misses.
    /// </summary>
    public string? Effect { get; set; }

    /// <summary>
    /// Indicates the weight of the power for sorting purposes. Powers with higher sort weights will be displayed before traits with lower sort weights in the user interface.
    /// </summary>
    public int SortWeight { get; set; } = 0;

    /// <summary>
    /// Indicates if the power should be displayed in the open state on the statblock editor.
    /// </summary>
    public bool ExpandEditor { get; set; } = true;
}

/// <summary>
/// Contains the data for an attack power's "On Hit" effect. 
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
    public Ability AbilityModifier { get; set; } = Ability.None;

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
    public DamageType DamageType { get; set; } = DamageType.Untyped;

    /// <summary>
    /// Defines any other effect that happens on a successful hit, such as conditions applied to the target, ongoing damage, or other special effects.
    /// Effects like this are formatted like "[damage], and [effect]", for example: "2d6 + 3 fire damage, and the target is knocked prone".
    /// </summary>
    public string? HitEffect { get; set; }

    /// <summary>
    /// Indicates if the attack has a critical hit effect, and if so, describes what that effect is.
    /// Critical hit effects are usually additional damage dice like "+1d12 damage", or special effects that occur on a critical hit, such as "target is stunned until the end of its next turn", "target takes ongoing 10 damage", etc.
    /// </summary>
    public string? CriticalHit { get; set; }    
}
