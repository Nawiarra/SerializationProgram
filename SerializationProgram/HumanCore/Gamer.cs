using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanCore
{
    [Serializable]
    public class Gamer : Human
    {
        public Guid Id { get; private set; }
        public bool IsInGame { get; private set; }

        public Gamer(string firstName, string lastName, int age, bool isInGame)
            : base(firstName, lastName, age)
        {
            Id = Guid.NewGuid();
            this.IsInGame = isInGame;
        }
         public Gamer(Guid id, bool isInGame)
        {
            Id = id;
            IsInGame = isInGame;
        }
        public override string Speak()
        {
            return "Let's play";
        }
    }
}
