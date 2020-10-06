﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanCore
{
    class Suicidal : Human
    {
        public Guid Id { get; private set; }
        public int DepressionPercent { get; private set; }
        public Suicidal(string firstName, string lastName, int age, bool isInGame)
         : base(firstName, lastName, age)
        {
            Id = Guid.NewGuid();
            DepressionPercent = 90;
            Speak();
        }
        public override string Speak()
        {
            DepressionPercent = 100;

            Die();

            return "May I die?";
        }
    }
}
