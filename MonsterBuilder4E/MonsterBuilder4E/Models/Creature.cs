using MonsterBuilder4E.Enums;
using MonsterBuilder4E.Utility;

namespace MonsterBuilder4E.Models
{
    public class Creature
    {
        public string Name { get; set; } = string.Empty;

        public int Level { get; set; }
        public int LevelBonus => (int)Math.Floor(Level / 2.0);

        public Role Role { get; set; }
        public RoleModifier RoleModifier { get; set; }

        public int XP => MonsterStats.CalculateXP(this);

        public Size Size { get; set; } = Size.Medium;
        public CreatureType Type { get; set; }
        public Origin Origin { get; set; }
        public string Keywords { get; set; } = string.Empty;

        public int Initiative { get; set; }
        public string Senses { get; set; } = string.Empty;

        public int HitPoints => MonsterStats.CalculateHitPoints(this);
        public int ArmorClass => MonsterStats.CalculateDefense(this, "AC");
        public int Fortitude => MonsterStats.CalculateDefense(this, "Fortitude");
        public int Reflex => MonsterStats.CalculateDefense(this, "Reflex");
        public int Will => MonsterStats.CalculateDefense(this, "Will");

        public int Speed { get; set; }
        public string SpecialMovement { get; set; } = string.Empty;

        public Ability Strength { get; set; } = new();
        public Ability Constitution { get; set; } = new();
        public Ability Dexterity { get; set; } = new();
        public Ability Intelligence { get; set; } = new();
        public Ability Wisdom { get; set; } = new();
        public Ability Charisma { get; set; } = new();

        public Alignment Alignment { get; set; } = Alignment.Unaligned;
        public string Languages { get; set; } = string.Empty;

        public List<string> ImmuneConditions { get; set; } = new();
        public List<string> Resistances { get; set; } = new();
        public List<string> Vulnerabilities { get; set; } = new();

        public List<CreatureTrait> Traits { get; set; } = new();
        public List<CreaturePower> Powers { get; set; } = new();

        public List<Skill> TrainedSkills { get; set; } = new();
        public List<string> Skills => MonsterStats.CalculateSkills(this);

        public string Equipment { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

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

    public class Ability
    {
        public int Score { get; set; } = 10;
        public int Modifier => (int)Math.Floor((Score - 10) / 2.0);
        public int CheckModifier { get; set; }
    }
}
