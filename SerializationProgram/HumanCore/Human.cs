using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanCore
{
    public abstract class Human
    {
        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public int Age { get; private set; }

        public bool IsAlive { get; private set; } = true;

        public abstract string Speak();

        public Human()
        {

        }

        public Human(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public void Die()
        {
            IsAlive = false;
        }

    }
}
