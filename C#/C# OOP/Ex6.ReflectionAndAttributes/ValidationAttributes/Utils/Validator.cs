using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ValidationAttributes.Attributes;

namespace ValidationAttributes.Utils
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            Type objType = obj.GetType();

            PropertyInfo[] properties = objType
                .GetProperties()
                .Where(p => p.CustomAttributes
                    .Any(ca => typeof(MyValidationAttribute)
                        .IsAssignableFrom(ca.AttributeType)))
                .ToArray();

            foreach (PropertyInfo propertyInfo in properties)
            {
                IEnumerable<MyValidationAttribute> attributes = propertyInfo
                    .GetCustomAttributes()
                    .Where(ca => typeof(MyValidationAttribute)
                        .IsAssignableFrom(ca.GetType()))
                    .Cast<MyValidationAttribute>();


                foreach (MyValidationAttribute attr in attributes)
                {
                    if (!attr.IsValid(propertyInfo.GetValue(obj)))
                    {
                        return false;
                    }   
                }
            }

            return true;
        }
    }
}
