using System;

namespace IncredibleTextAdventure.Service
{
    public static class StringExtention
    {
        public static bool EqualsIgnoreCase(this string str, string other)
        {
            if (!(ReferenceEquals(str, null) || ReferenceEquals(other, null)))
            {
                return str.Equals(other, StringComparison.OrdinalIgnoreCase);
            }

            return false;
        }
    }
}
