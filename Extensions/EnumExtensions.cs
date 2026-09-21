using System.Reflection;

namespace Naruto_Universe.Extensions;

public static class EnumExtensions
{
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class StringValueAttribute : Attribute
    {
        public string Value { get; }

        public StringValueAttribute(string value)
        {
            Value = value;
        }
    }
    
    public static string StringValue<T>(this T value)
        where T : Enum
    {
        var fieldName = value.ToString();
        var field = typeof(T).GetField(fieldName, BindingFlags.Public | BindingFlags.Static);
        return field?.GetCustomAttribute<StringValueAttribute>()?.Value ?? fieldName;
    }
    
    public static string GetStringValue<TEnum>(this TEnum value)
        where TEnum : Enum
    {
        var field = typeof(TEnum).GetField(value.ToString());

        var attribute = field?
            .GetCustomAttributes(typeof(StringValueAttribute), false)
            .FirstOrDefault() as StringValueAttribute;

        return attribute?.Value ?? value.ToString();
    }

    public static TEnum Parse<TEnum>(string value)
        where TEnum : struct, Enum
    {
        foreach (var field in typeof(TEnum).GetFields())
        {
            var attribute = field
                .GetCustomAttributes(typeof(StringValueAttribute), false)
                .FirstOrDefault() as StringValueAttribute;

            if (attribute?.Value.Equals(value, StringComparison.OrdinalIgnoreCase) == true)
            {
                return (TEnum)field.GetValue(null)!;
            }
        }

        throw new ArgumentException(
            $"'{value}' is not a valid {typeof(TEnum).Name} value.");
    }
}