using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanCore
{
    [Serializable]
    public class Suicidal : Human
    {
        [MyIgnoreAttribute]
        public Guid Id { get; private set; }
        [MyIgnoreAttribute]
        public int DepressionPercent { get; private set; }
        public Suicidal(string firstName, string lastName, int age, int depressionPercent)
         : base(firstName, lastName, age)
        {
            Id = Guid.NewGuid();
            DepressionPercent = depressionPercent;

            if (DepressionPercent >= 90)
            {
                Speak();
            }
        }
        public override string Speak()
        {
            DepressionPercent = 100;

            Die();

            return "May I die?";
        }
    }
}
