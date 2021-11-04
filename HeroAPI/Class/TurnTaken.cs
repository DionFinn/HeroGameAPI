using System;
using System.Collections.Generic;

namespace HeroGameAPI
{
    public class TurnTaken
    {
        public int TurnNo { get; set; }
        public int HeroID { get; set; }
        public int VillianID  { get; set; } 
        public int GameID { get; set; }
        public int DamageDelt { get; set; }
    }
}