using System;
using System.Collections.Generic;
using System.Text;

namespace ExamPrepII_Pr03_NetherRealms
{
    class Deamon
    {
        public Deamon(string name, double health, double damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }

        public string Name { get; set; }
        public double Health { get; set; }
        public double Damage { get; set; }
    }
}
