using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class AddName
    {
        public string NickName { get; set; } //this is must be null always if i call it
        public string MakeFullName(string firstName,string lastName)
        {
            //return firstName + lastName;
            //another way
            return $"{firstName} {lastName}";
        }
    }
}
