using MonsterBuilder4E.Enums;

namespace MonsterBuilder4E.Models;

/// <summary>
/// Represents the equipment carried by a D&D 4E monster or creature.
/// </summary>
public class Equipment
{
    /// <summary>
    /// The armor worn by the creature.
    /// </summary>
    public Armor? Armor { get; set; }

    /// <summary>
    /// The shield carried by the creature.
    /// </summary>
    public Shield? Shield { get; set; }

    /// <summary>
    /// The weapons wielded by the creature.
    /// </summary>
    public List<Weapon> Weapons { get; set; } = new();

    /// <summary>
    /// Other miscellaneous equipment carried by the creature (potions, tools, etc.).
    /// </summary>
    public string Other { get; set; } = string.Empty;

    /// <summary>
    /// Returns a formatted string representation of all equipment.
    /// </summary>
    public override string ToString()
    {
        var items = new List<string>();

        if (Armor != null)
            items.Add(Armor.ToString());

        if (Shield != null)
            items.Add(Shield.ToString());

        foreach (var weapon in Weapons)
            items.Add(weapon.ToString());

        if (!string.IsNullOrWhiteSpace(Other))
            items.Add(Other);

        return string.Join(", ", items);
    }
}

/// <summary>
/// Represents armor worn by a creature in D&D 4E.
/// </summary>
public class Armor
{
    /// <summary>
    /// The name or type of armor (e.g., "chainmail", "leather armor", "plate armor").
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Indicates the type of armor, which is either light or heavy.
    /// In D&D 4E, light armor allows the wearer to apply their Dex or Int modifier to AC, while heavy armor does not.
    /// </summary>
    public ArmorType Type { get; set; } = ArmorType.Light;

    /// <summary>
    /// The armor bonus to AC provided by this armor.
    /// In D&D 4E, this is typically the primary defensive benefit of wearing armor.
    /// </summary>
    public int ArmorBonus { get; set; }

    /// <summary>
    /// Any additional modifier to AC the monster gets when wearing this armor (e.g., from feats or racial features).
    /// </summary>
    public int ArmorModifier { get; set; }

    /// <summary>
    /// The armor check penalty, which applies to certain skill checks.
    /// In D&D 4E, this penalty applies to Strength-, Dexterity-, and Constitution-based skill checks.
    /// </summary>
    public int CheckPenalty { get; set; }

    /// <summary>
    /// The speed penalty imposed by wearing this armor.
    /// In D&D 4E, heavy armor can reduce movement speed.
    /// </summary>
    public int SpeedPenalty { get; set; }

    /// <summary>
    /// The minimum enhancement bonus of the armor.
    /// </summary>
    public int EnhancementBonus { get; set; }

    /// <summary>
    /// Special properties or magical effects of the armor.
    /// </summary>
    public string SpecialProperties { get; set; } = string.Empty;

    public override string ToString()
    {
        var name = Name;
        if (EnhancementBonus > 0)
            name = $"+{EnhancementBonus} {name}";
        return name;
    }
}

/// <summary>
/// Represents a shield carried by a creature in D&D 4E.
/// </summary>
public class Shield
{
    /// <summary>
    /// The name or type of shield (e.g., "light shield", "heavy shield").
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// The shield bonus to AC provided by this shield.
    /// In D&D 4E, shields provide a bonus to AC and Reflex defense.
    /// </summary>
    public int ShieldBonus { get; set; }

    /// <summary>
    /// Any additional modifier to AC and Reflex the monster gets when using the shield (e.g., from feats or racial features).
    /// </summary>
    public int ShieldModifier { get; set; }

    /// <summary>
    /// The armor check penalty from the shield.
    /// </summary>
    public int CheckPenalty { get; set; }

    /// <summary>
    /// The enhancement bonus of the shield.
    /// </summary>
    public int EnhancementBonus { get; set; }

    /// <summary>
    /// Special properties or magical effects of the shield.
    /// </summary>
    public string SpecialProperties { get; set; } = string.Empty;

    public override string ToString()
    {
        var name = Name;
        if (EnhancementBonus > 0)
            name = $"+{EnhancementBonus} {name}";
        return name;
    }
}

/// <summary>
/// Represents a weapon wielded by a creature in D&D 4E.
/// </summary>
public class Weapon
{
    /// <summary>
    /// The name of the weapon (e.g., "longsword", "greataxe", "longbow").
    /// </summary>
    public string Name { get; set; } = string.Empty;

    public WeaponType Type { get; set; } = WeaponType.Melee;

    public bool IsTwoHanded { get; set; } = false;

    public bool IsThrowable { get; set; } = false;

    /// <summary>
    /// The reach of the weapon in squares, used on melee attacks.
    /// </summary>
    public int Reach { get; set; } = 1;

    /// <summary>
    /// The range of the weapon in squares, used on ranged attacks.
    /// </summary>
    public int Range { get; set; } = 10;

    /// <summary>
    /// The long range of the weapon in squares, used on ranged attacks. 
    /// At long range, the weapon typically suffers a -2 penalty to attack rolls.
    /// </summary>
    public int LongRange { get; set; } = 20;

    /// <summary>
    /// The extra long range of the weapon in squares, used on ranged attacks. 
    /// At extra long range, the weapon typically suffers a -5 penalty to attack rolls.
    /// </summary>
    public int ExtraLongRange { get; set; } = 0;

    /// <summary>
    /// The proficiency bonus for this weapon.
    /// In D&D 4E, different weapons have different proficiency bonuses (+2 for simple, +3 for military, etc.).
    /// </summary>
    public int ProficiencyBonus { get; set; }

    /// <summary>
    /// Any additional modifier to attack rolls the monster gets when wielding this weapon (e.g., from feats or racial features).
    /// </summary>
    public int AttackModifier { get; set; }

    /// <summary>
    /// The damage dice for this weapon (e.g., "1d8", "2d6", "1d10").
    /// </summary>
    public string BaseDamage { get; set; } = string.Empty;

    /// <summary>
    /// The damage type dealt by this weapon.
    /// </summary>
    public DamageType DamageType { get; set; } = DamageType.Untyped;

    /// <summary>
    /// The enhancement bonus of the weapon.
    /// </summary>
    public int EnhancementBonus { get; set; }

    /// <summary>
    /// The weapon group (e.g., "heavy blade", "light blade", "axe", "bow").
    /// </summary>
    public string WeaponGroup { get; set; } = string.Empty;

    /// <summary>
    /// Weapon properties and keywords (e.g., "versatile", "high crit", "off-hand", "reach").
    /// </summary>
    public List<string> Properties { get; set; } = new();

    /// <summary>
    /// Special properties or magical effects of the weapon.
    /// </summary>
    public string SpecialProperties { get; set; } = string.Empty;

    /// <summary>
    /// Indicates if this is a ranged weapon.
    /// </summary>
    public bool IsRanged { get; set; }

    public override string ToString()
    {
        var name = Name;
        if (EnhancementBonus > 0)
            name = $"+{EnhancementBonus} {name}";
        return name;
    }
}
