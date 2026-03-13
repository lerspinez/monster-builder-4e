using MonsterBuilder4E.Enums;
using MonsterBuilder4E.Utility;

namespace MonsterBuilder4E.Models;

public class Creature
{
    /// <summary>
    /// The name of the creature, such as "Goblin", "Orc", "Dragon", etc.
    /// This is a required property that identifies the creature and is used for display purposes in the application.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Short description of the creature, which can include its appearance, behavior, or any notable characteristics.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Level of the monster, which is a key factor in determining its overall power and challenge rating in D&D 4E.
    /// </summary>
    public int Level { get; set; }

    /// <summary>
    /// This is the base bonus that the creature receives to its attack rolls, damage rolls, and skill checks based on its level.
    /// </summary>
    public int LevelBonus => (int)Math.Floor(Level / 2.0);

    /// <summary>
    /// Combat role of the creature, which defines its general function in combat and helps determine its stats and abilities.
    /// In D&D 4E, common roles include Brute (high damage, low defenses), Controller (manipulates the battlefield), Lurker (high damage against isolated targets), Skirmisher (mobile and versatile), Soldier (balanced offense and defense), and Artillery (ranged damage dealer).
    /// </summary>
    public Role Role { get; set; }

    /// <summary>
    /// Indicates if the creature is a minion, elite or solo monster.
    /// Minions are apecial type of monster in D&D 4E that has only 1 hit point and is designed to be easily defeated.
    /// Elite monsters are more powerful than normal monsters and often have additional abilities or higher stats.
    /// Solo monsters are the most powerful type of monster, often designed to be a significant challenge for an entire party of adventurers.
    /// </summary>
    public RoleModifier RoleModifier { get; set; }

    /// <summary>
    /// Indicates if the creature is a leader.
    /// In D&D 4E, leaders are monsters that have special abilities that can benefit their allies, such as granting extra actions, providing bonuses to attacks or defenses, or allowing allies to make additional attacks.
    /// </summary>
    public bool IsLeader { get; set; }

    /// <summary>
    /// Defines the  experience points awarded for defeating this monster.
    /// </summary>
    public int XP => MonsterStats.CalculateXP(this);

    /// <summary>
    /// Size of the creature, which can be Tiny, Small, Medium, Large, Huge, or Gargantuan.
    /// </summary>
    public CreatureSize Size { get; set; } = CreatureSize.Medium;

    /// <summary>
    /// Origin of the creature, as defined in D&D 4E. 
    /// This can include categories like Natural, Elemental, Fey, Shadow, and more.
    /// </summary>
    public CreatureOrigin Origin { get; set; }

    /// <summary>
    /// The creature's type, as defined in D&D 4E. 
    /// Creature types include Humanoid, Beast, Dragon, Animate, etc.
    /// </summary>
    public CreatureType Type { get; set; }

    /// <summary>
    /// Any keywords associated with the creature, from the D&D 4E list.
    /// Possible keywords include "giant", "undead", "earth", "fire", etc.
    /// </summary>
    public string CreatureKeywords { get; set; } = string.Empty;

    /// <summary>
    /// If the creature is from a playable race, it is noted here. 
    /// This is optional and can be left blank for monsters that are not from a playable race.
    /// </summary>
    public string Race { get; set; } = string.Empty;

    /// <summary>
    /// The creature's ability scores, which include Strength, Dexterity, Constitution, Intelligence, Wisdom, and Charisma.
    /// </summary>
    public AbilityScores Abilities { get; set; } = new();

    /// <summary>
    /// Indicates the creature's initiative modifier, which is calculated based on its level and Dexterity modifier.
    /// </summary>
    public int Initiative { get; set; } //GetInitiative method in MonsterStats

    /// <summary>
    /// Defines the creature's special senses under the D&D 4E rules, such as Darkvision, Tremorsense, Blindsight, etc.
    /// </summary>
    public string Senses { get; set; } = string.Empty; //GetSenses method in MonsterStats

    /// <summary>
    /// Indicates the creature's maximum hit points, which are calculated based on its level, role, and Constitution score according to D&D 4E rules.
    /// </summary>
    public int HitPoints => MonsterStats.CalculateHitPoints(this);

    /// <summary>
    /// Gets the hit point threshold at which the character is considered bloodied.
    /// </summary>
    /// <remarks>
    /// This value is calculated as half of the character's current hit points, rounded down. The
    /// bloodied threshold is commonly used in game mechanics to indicate when a character is at risk or may trigger
    /// special abilities.
    /// </remarks>
    public int Bloodied => (int)Math.Floor(HitPoints / 2.0);

    /// <summary>
    /// Defines the creature's immunities, according to D&D 4E rules.
    /// </summary>
    public List<string> ImmuneConditions { get; set; } = new();

    /// <summary>
    /// Defines the creature's damage resistances according to D&D 4E rules.
    /// </summary>
    public List<string> Resistances { get; set; } = new();

    /// <summary>
    /// Defines the creature's vulnerabilities according to D&D 4E rules.
    /// </summary>
    public List<string> Vulnerabilities { get; set; } = new();


    //Defenses

    /// <summary>
    /// The creature's Armor Class defense (AC), which is calculated based on its level, equipped armor, Dex/Int modifier, and any other relevant factors according to D&D 4E rules.
    /// Most melee and ranged attacks made with weapons target the creature's Armor Class.
    /// </summary>
    public int ArmorClass => MonsterStats.CalculateDefense(this, Defense.ArmorClass);

    /// <summary>
    /// The creature's Fortitude defense, which is used to resist effects that target physical toughness, such as poison, disease, and forced movement.
    /// </summary>
    public int Fortitude => MonsterStats.CalculateDefense(this, Defense.Fortitude);

    /// <summary>
    /// The creature's Reflex defense, which is used to resist effects that target agility and quickness, such as area attacks, traps, and certain spells.
    /// </summary>
    public int Reflex => MonsterStats.CalculateDefense(this, Defense.Reflex);

    /// <summary>
    /// The creature's Will defense, which is used to resist effects that target mental fortitude and resolve, such as charm, fear, and psychic damage.
    /// </summary>
    public int Will => MonsterStats.CalculateDefense(this, Defense.Will);


    //Savings Throws

    //Action Points

    /// <summary>
    /// The creature's land speed, which is the number of squares it can move on its turn in combat according to D&D 4E rules.
    /// </summary>
    public int Speed { get; set; }

    /// <summary>
    /// Special movement types the creature has, such as flying, swimming, climbing, teleportation, etc.
    /// These movement modes use the D&D 4E rules.
    /// </summary>
    public string SpecialMovement { get; set; } = string.Empty;

    /// <summary>
    /// Traits are special abilities or characteristics that the creature has, which can include things like aura effects, regeneration, camouflage, etc.
    /// A creature's traits don't usually require an action to use, and they often provide passive benefits or special interactions in combat.
    /// </summary>
    public List<CreatureTrait> Traits { get; set; } = new();

    //Actions

    //Triggered Actions

    public List<CreaturePower> Powers { get; set; } = new();

    /// <summary>
    /// Lists the skills in which the creature is trained, which means it gets a +5 bonus on checks with those skills, per D&D 4E rules.
    /// </summary>
    public List<Skill> TrainedSkills { get; set; } = new();

    /// <summary>
    /// Enumerates the creature's skills and their corresponding modifiers, which are calculated based on the creature's ability scores, level bonus, and training in those skills according to D&D 4E rules.
    /// In general, only trained skills and skills with racial bonuses will be listed here, with other skills being handled using the creature's ability check modifiers.
    /// </summary>
    public List<string> Skills => MonsterStats.CalculateSkills(this);

    /// <summary>
    /// Enumerates the creature's ability check modifiers, which are calculated based on the creature's ability scores and level bonus according to D&D 4E rules.
    /// Untrained skills are usually handled using these ability check modifiers, while trained skills are calculated separately with the training bonus added in.
    /// </summary>
    public AbilityCheckModifiers AbilityCheckModifiers => MonsterStats.GetAbilityCheckModifiers(this);

    /// <summary>
    /// The creature's alignment, which is a combination of its moral and ethical outlook.
    /// D&D 4E has five alignments: Unaligned, Good, Lawful Good, Evil and Chaotic Evil.
    /// Unaligned is used for creatures that don't have a clear moral or ethical stance, such as animals, constructs, and certain monsters.
    /// </summary>
    public Alignment Alignment { get; set; } = Alignment.Unaligned;

    /// <summary>
    /// Languages spoken, or at least understood, by the creature.
    /// </summary>
    public List<string> Languages { get; set; } = new();

    /// <summary>
    /// Defines the items carried by the creature, including weapons, armor, and other equipment.
    /// </summary>
    public List<string> Equipment { get; set; } = new();

    /// <summary>
    /// A creature's enhancement bonus is added to their attack rolls, damage rolls, and to their defenses.
    /// </summary>
    public int EnhancementBonus { get; set; } = 0;
}

public class CreaturePowerOld
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
public class CreaturePower
{
    /// <summary>
    /// The name of the power available to the monster. 
    /// This is typically a descriptive name that indicates the nature of the attack, such as "Battleaxe", "Dragon Breath", "Magic Missile", etc.
    /// </summary>
    public string Name { get; set; } = "Power";

    /// <summary>
    /// Keywords associated with the power, such as "Weapon", "Acid", "Fire", "Healing", etc.
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
    /// Describes the effect of the power, which can include conditions applied to the target, ongoing damage, forced movement, or any other special effects that occur when the power is used.
    /// For attack powers, this effect happens regardless of whether the attack hits or misses.
    /// </summary>
    public string? Effect { get; set; }
}

/// <summary>
/// Contains the data for an attack power's "Hit" effect. 
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


/// <summary>
/// Represents a special ability or characteristic that can be assigned to a creature, such as an aura, regeneration, or camouflage effect.
/// </summary>
/// <remarks>
/// A trait may define effects that influence the creature itself or other creatures within a specified
/// range. Traits with the IsAura property set to <see langword="true"/> affect all creatures within the specified
/// AuraRange. The Effect property describes the specific impact or rule associated with the trait.
/// </remarks>
public class CreatureTrait
{
    /// <summary>
    /// Name of the trait, such as "Regeneration", "Camouflage", "Aura of Fear", etc.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Indicates if the trait is an aura, which means it affects all creatures within a certain range around the monster.
    /// </summary>
    public bool IsAura { get; set; }

    /// <summary>
    /// Indicates the range of the aura in squares, if the trait is an aura. For example, an "Aura of Fear" might have a range of 2 squares, meaning it affects all creatures within 2 squares of the monster.
    /// </summary>
    public int AuraRange { get; set; }

    /// <summary>
    /// Effect of the trait, which can include things like "The monster regenerates 5 hit points at the start of its turn", "The monster is invisible when in natural terrain", "Enemies that end their turn adjacent to the monster take 5 damage", etc.
    /// </summary>
    public string? Effect { get; set; }
}


