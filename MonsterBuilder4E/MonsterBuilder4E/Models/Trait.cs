namespace MonsterBuilder4E.Models;

/// <summary>
/// Represents a special ability or characteristic that can be assigned to a creature, such as an aura, regeneration, or camouflage effect.
/// </summary>
/// <remarks>
/// A trait may define effects that influence the creature itself or other creatures within a specified
/// range. Traits with the IsAura property set to <see langword="true"/> affect all creatures within the specified
/// AuraRange. The Effect property describes the specific impact or rule associated with the trait.
/// </remarks>
public class Trait
{
    /// <summary>
    /// Name of the trait, such as "Regeneration", "Camouflage", "Aura of Fear", etc.
    /// </summary>
    public string Name { get; set; } = "Trait";

    /// <summary>
    /// Indicates if the trait is an aura, which means it affects all creatures within a certain range around the monster.
    /// </summary>
    public bool IsAura { get; set; }

    /// <summary>
    /// Indicates the range of the aura in squares, if the trait is an aura. For example, an "Aura of Fear" might have a range of 2 squares, meaning it affects all creatures within 2 squares of the monster.
    /// </summary>
    public int AuraRange { get; set; } = 1;

    /// <summary>
    /// Effect of the trait, which can include things like "The monster regenerates 5 hit points at the start of its turn", "The monster is invisible when in natural terrain", "Enemies that end their turn adjacent to the monster take 5 damage", etc.
    /// </summary>
    public string? Effect { get; set; }

    /// <summary>
    /// Indicates the weight of the trait for sorting purposes. Traits with higher sort weights will be displayed before traits with lower sort weights in the user interface.
    /// </summary>
    public int SortWeight { get; set; } = 0;

    /// <summary>
    /// Indicates if the trait should be displayed in the open state on the statblock editor.
    /// </summary>
    public bool ExpandEditor { get; set; } = true;
}
