﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace FTV.BL
{
    public static class Search
    {
        public static IEnumerable<T> WhereAtLeastOneProperty<T, PropertyType>(this IEnumerable<T> source, Predicate<PropertyType> predicate)
        {
            var properties = typeof(T).GetProperties().Where(prop => prop.CanRead && prop.PropertyType == typeof(PropertyType)).ToArray();
            return source.Where(item => properties.Any(prop => PropertySatisfiesPredicate<T, PropertyType>(predicate, item, prop)));
        }

        private static bool PropertySatisfiesPredicate<T, PropertyType>(Predicate<PropertyType> predicate, T item, System.Reflection.PropertyInfo prop)
        {
            try
            {
                return predicate((PropertyType)prop.GetValue(item));
            }
            catch
            {
                return false;
            }
        }
    }
}
