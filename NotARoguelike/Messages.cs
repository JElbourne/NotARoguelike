using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotARoguelike
{
    class Messages
    {
        private List<string> messageLog;

        public Messages()
        {
            messageLog = new List<string>();
        }

        void PrintMessages()
        {
            int numLines = messageLog.Count;
            if (numLines > 3)
            {
                numLines = 3;
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;

            for (int i = 0; i < numLines; i++)
            {
                Console.SetCursorPosition(0, Console.WindowHeight - 1 - i);
                //Include after Framebuffer setup
                //Console.Write(messageLog[messageLog.Count - 1 - i].PadRight(FrameBuffer.Instance.Width - statAreaWidth - 1));
            }
        }

        public void Message(string m)
        {
            string[] ms = m.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string m2 in ms)
                messageLog.Add(m2);
        }

        //public void DebugMessage(string m)
        //{
        //    // check debug flag
        //    if (false)
        //    {
        //        Message("[DEBUG] " + m);
        //    }
        //}

    }
}
