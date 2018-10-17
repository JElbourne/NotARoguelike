using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotARoguelike
{
    class Intro
    {
        public Intro()
        {

        }

        public void AnyKey()
        {
            // Drain key presses
            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }

            Console.WriteLine("[Press Any Key to Continue]");
            Console.ReadKey(true);
            Console.Clear();
        }

        public void Play()
        {
            Console.Clear();

            AnyKey();
        }
    }
}
