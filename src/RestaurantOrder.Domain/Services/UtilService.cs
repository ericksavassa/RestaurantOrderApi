using System;
namespace RestaurantOrder.Domain.Services
{
    public static class UtilService
    {
        public static string GetEnumName<T>(string value) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException("Not an enum");

            Enum.TryParse(value, out T enumClass);
            string result = enumClass.ToString();

            if (!Enum.IsDefined(typeof(T), result))
                result = "error";

            return result;
        }

        public static T GetEnumByName<T>(string value) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum || !Enum.TryParse(value, out T enumClass))
                throw new ArgumentException("Not an enum");

            return Enum.Parse<T>(value);
        }

        public static bool IsNumeric(string value)
        {
            return float.TryParse(value, out float output);
        }
    }
}
