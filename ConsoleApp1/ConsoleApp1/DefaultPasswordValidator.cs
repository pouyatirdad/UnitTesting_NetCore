using System;
using System.Linq;

namespace ConsoleApp1
{
    public class DefaultPasswordValidator : IPassword
    {
        public bool Validate(string password)
        {
            if (password.Length < 8) return false;
            if (!password.Any(x => char.IsUpper(x))) return false;

            return true;
        }
    }
}
