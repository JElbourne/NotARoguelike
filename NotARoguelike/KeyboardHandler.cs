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
                ConsoleKeyInfo cki = Console.ReadKey(true);

                Update_Keyboard_Normal(cki);
            }

            // If there are any more keys, drain them out of the buffer
            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }
        }

        public static void Update_Keyboard_Normal(ConsoleKeyInfo cki)
        {
            if (cki.Key == ConsoleKey.RightArrow || cki.Key == ConsoleKey.NumPad6)
            {
                PlayerCharacter.Instance.QueueMoveBy(1, 0);
                Game.Instance.DoTick();
            }
            else if (cki.Key == ConsoleKey.LeftArrow || cki.Key == ConsoleKey.NumPad4)
            {
                PlayerCharacter.Instance.QueueMoveBy(-1, 0);
                Game.Instance.DoTick();
            }
            else if (cki.Key == ConsoleKey.UpArrow || cki.Key == ConsoleKey.NumPad8)
            {
                PlayerCharacter.Instance.QueueMoveBy(0, -1);
                Game.Instance.DoTick();
            }
            else if (cki.Key == ConsoleKey.DownArrow || cki.Key == ConsoleKey.NumPad2)
            {
                PlayerCharacter.Instance.QueueMoveBy(0, 1);
                Game.Instance.DoTick();
            }
            else if (cki.Key == ConsoleKey.NumPad7 || cki.Key == ConsoleKey.Home)
            {
                PlayerCharacter.Instance.QueueMoveBy(-1, -1);
                Game.Instance.DoTick();
            }
            else if (cki.Key == ConsoleKey.NumPad9 || cki.Key == ConsoleKey.PageUp)
            {
                PlayerCharacter.Instance.QueueMoveBy(1, -1);
                Game.Instance.DoTick();
            }
            else if (cki.Key == ConsoleKey.NumPad3 || cki.Key == ConsoleKey.PageDown)
            {
                PlayerCharacter.Instance.QueueMoveBy(1, 1);
                Game.Instance.DoTick();
            }
            else if (cki.Key == ConsoleKey.NumPad1 || cki.Key == ConsoleKey.End)
            {
                PlayerCharacter.Instance.QueueMoveBy(-1, 1);
                Game.Instance.DoTick();
            }
            else if (cki.Key == ConsoleKey.NumPad5 || cki.KeyChar == '5')
            {
                // Do nothing
                Game.Instance.DoTick();
            }
        }
    }
}
