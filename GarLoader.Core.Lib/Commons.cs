using System;
using System.Collections.Generic;
using System.Text;

namespace GarLoader.Core.Lib
{
    public class Commons
    {
        // Стырено https://stackoverflow.com/questions/393731/generic-conversion-function-doesnt-seem-to-work-with-guids и немного доработано
        public static object ChangeType(object value, Type type)
        {
            if (type == typeof(bool))
            {
                if (value.GetType() == typeof(string))
                {
                    int r;
                    if (int.TryParse((string)value, out r) == true)
                    {
                        return ChangeType(r, typeof(bool));
                    }
                }
            }

            if (value == null)
                return null;
            if (type == value.GetType())
                return value;

            if (type.IsEnum)
            {
                if (value is string)
                    return Enum.Parse(type, value as string);
                else
                    return Enum.ToObject(type, value);
            }

            if (!type.IsInterface && type.IsGenericType)
            {
                Type innerType = type.GetGenericArguments()[0];
                object innerValue = ChangeType(value, innerType);
                return Activator.CreateInstance(type, new object[] { innerValue });
            }

            if (value is string && type == typeof(Guid))
                return new Guid(value as string);
            if (value is string && type == typeof(Version))
                return new Version(value as string);
            if (!(value is IConvertible))
                return value;
            return Convert.ChangeType(value, type);
        }

    }
}
