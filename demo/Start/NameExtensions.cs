using System;

namespace Demo.Start
{
    public static class NameExtensions
    {
        public static void ParseName(this string name, out string firstName, out string lastName)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));

            var nameParts = name.Split(' ');
            firstName = nameParts[0];
            lastName = nameParts[1];
        }
    }
}