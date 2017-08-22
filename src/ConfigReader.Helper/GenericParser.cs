using System;
using System.Globalization;

namespace ConfigReader.Helper
{
    public static class GenericParser
    {
        public static T Parse<T>(string value)
        {
            return (T) Convert.ChangeType(value, typeof(T), CultureInfo.InvariantCulture);
        }
    }
}