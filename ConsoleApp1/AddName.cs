using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class AddName
    {
        public string MakeFullName(string firstName,string lastName)
        {
            //return firstName + lastName;
            //another way
            return $"{firstName} {lastName}";
        }
    }
}
