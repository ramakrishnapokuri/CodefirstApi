using System;
using System.Collections.Generic;
using System.Linq;

namespace PrasadCodeFirst.Common
{
    public class Guard
    {
        public static void AgainstNull(object value, string name)
        {
            if (value == null)
            {
                throw new ArgumentNullException(name);
            }
        }

        internal static void AgainstNullOrEmpty(object value, string name)
        {
            if (value == null)
            {
                throw new ArgumentNullException(name);
            }
        }

        internal static bool IsEmpty(IList<string> tenants)
        {
            return tenants == null || tenants.ToList().Any();
        }
    }
}