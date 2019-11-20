using System;

namespace Demo.Finish
{
    public static class NameExtensions
    {
        public static (string firstName, string lastName) ParseName(this string name)
        {
            var nameParts = name?.Split(' ') ?? throw new ArgumentNullException(nameof(name));
            return (nameParts[0], nameParts[1]);
        }
    }
}