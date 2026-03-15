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

    /// <summary>
    /// Special AC modifier, which is added to the creature's base Armor Class to determine its final AC value.
    /// </summary>
    public int ArmorClassModifier {  get; set; }

    /// <summary>
    /// Special Fortitude modifier, which is added to the creature's base Fortitude defense to determine its final Fortitude value.
    /// </summary>
    public int FortitudeModifier { get; set; }

    /// <summary>
    /// Special Reflex modifier, which is added to the creature's base Reflex defense to determine its final Reflex value.
    /// </summary>
    public int ReflexModifier { get; set; }

    /// <summary>
    /// Special Will modifier, which is added to the creature's base Will defense to determine its final Will value.
    /// </summary>
    public int WillModifier { get; set; }


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
    public List<Trait> Traits { get; set; } = new();

    //Actions

    //Triggered Actions

    public List<Power> Powers { get; set; } = new();

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