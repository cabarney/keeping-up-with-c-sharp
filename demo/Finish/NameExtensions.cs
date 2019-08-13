using System;

namespace Demo.Finish
{
    public static class NameExtensions
    {
        public static (string firstName, string lastName) ParseName(this string name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));

            var nameParts = name.Split(' ');
            return (nameParts[0], nameParts[1]);
        }
    }
}