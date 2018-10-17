using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace NotARoguelike
{
    class PlayerCharacter : Character
    {
        public PlayerCharacter()
        {
            _instance = this;
        }

        private static PlayerCharacter _instance;

        static public PlayerCharacter Instance
        {
            get
            {
                return _instance;
            }
        }
    }
}
