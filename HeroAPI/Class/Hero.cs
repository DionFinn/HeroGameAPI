using System;
using System.Collections.Generic;

namespace HeroGameAPI
{
    public class Hero 
    {
        public int HeroID { get; set; }
        public string  HeroName { get; set; }
        public int MinDice { get; set; }
        public int MaxDice { get; set; }
        public int Uses { get; set; }

    }
}