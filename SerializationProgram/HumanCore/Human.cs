using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SerializationCore;

namespace HumanCore
{
    public abstract class Human
    {
        [MyIgnoreAttribute]
        public string FirstName { get; private set; }

        [MyIgnoreAttribute]
        public string LastName { get; private set; }

        [MyIgnoreAttribute]
        public int Age { get; private set; }

        [MyIgnoreAttribute]
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
