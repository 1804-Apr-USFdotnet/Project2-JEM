using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace FTV.BL
{
    public static class Sorting
    {
        public static List<T> SortAscending<T>(List<T> list, string propertyName)
        {
            PropertyDescriptor prop = TypeDescriptor.GetProperties(typeof(T)).Find(propertyName, true);
            return list.OrderBy(x => prop.GetValue(x)).ToList();
        }

        public static List<T> SortDescending<T>(List<T> list, string propertyName)
        {
            PropertyDescriptor prop = TypeDescriptor.GetProperties(typeof(T)).Find(propertyName,true);
            return list.OrderByDescending(x => prop.GetValue(x)).ToList();
        }

        public static List<T> Top<T>(List<T> list, int count)
        {
            return list.Take(count).ToList();
        }
    }
}
