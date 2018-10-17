using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NotARoguelike
{
    class Program
    {
        class MainClass
        {
            public static void Main(string[] args)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                while (RunGame())
                {

                }

                Console.ResetColor();
                Console.Clear();
            }

            static bool RunGame()
            {
                Console.CursorVisible = false;

                Game game = new Game();

                //Intro intro = new Intro();
                //intro.Play();

                while (game.Update())
                {
                    // Tiny nap to stop the CPU from melting.
                    Thread.Sleep(10);
                }

                return game.Restart;
            }
        }
    }
}
