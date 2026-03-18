using System.Text.RegularExpressions;
using static MudBlazor.Colors;

namespace MonsterBuilder4E.Utility;

public static class Formatter
{
    public static string Enum(string enumName, bool toLower = false)
    {
        enumName = Regex.Replace(enumName, "([a-z])([A-Z,0-9])", "$1 $2");

        if(toLower )
            enumName = enumName.ToLower();

        return enumName;
    }

    public static string Modifier(int value)
    {
        return value > 0 ? $"+{value}" : value.ToString();
    }
}
