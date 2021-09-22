using System;
using System.Linq;

namespace UrnaEletronica.Application.Extensions
{
    public static class IsAllNullOrInvalidExtension
    {
        public static bool IsAllNullOrInvalid(this object obj)
        {
            var properties = obj.GetType().GetProperties()
                .Where(p => p.Name != "Page" && p.Name != "TotalPages" && p.Name != "Skip" 
                    && p.Name != "Take" && p.Name != "OrderBy" && p.Name != "Include");

            if (obj == null || properties.Count() == 0)
                return true;

            bool result = false;

            foreach (var prop in properties)
            {
                dynamic value;

                if (prop.PropertyType == typeof(string))
                {
                    value = (string)prop.GetValue(obj);
                    result = (string.IsNullOrEmpty(value) ? true : false 
                        || string.IsNullOrWhiteSpace(value) ? true : false);
                }

                if (prop.PropertyType == typeof(int?))
                {
                    value = (int?)prop.GetValue(obj);
                    result = (value <= 0 ? true : false || value == null ? true : false);
                }

                if (prop.PropertyType == typeof(DateTime?))
                {
                    value = (DateTime?)prop.GetValue(obj);
                    result = (value == new DateTime() ? true : false || value == null ? true : false);
                }

                if (result == false)
                {
                    break;
                }
            }

            return result;
        }
    }
}
