using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotARoguelike
{
    public class KeyboardHandler
    {
        public static void Update_Keyboard()
        {
            if (Console.KeyAvailable)
            {

            }

            // If there are any more keys, drain them out of the buffer
            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }
        }
    }
}
