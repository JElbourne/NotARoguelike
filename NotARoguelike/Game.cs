using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotARoguelike
{
    public enum InputMode { Normal, Inventory, Help, LogView }

    class Game
    {
        public PlayerCharacter PlayerCharacter { get; set; }
        public Map Map { get; protected set; }

        private readonly FrameBuffer frameBuffer;
        public Rect LevelRenderArea;
        public Messages Messages;
        public Random Random;
        public InputMode InputMode = InputMode.Normal;

        public bool Restart = false;
        public bool ClearRequested = false;

        public int SleepFor { get; set; }
        private readonly int statAreaWidth = 16;

        #region bookkeeping
        private bool exit = false;
        private bool doTick = false;
        #endregion

        public Game()
        {
            _instance = this;

            Random = new Random();
            Messages = new Messages();

            frameBuffer = new FrameBuffer(0, 0, Console.WindowWidth, Console.WindowHeight - 1);
            LevelRenderArea = new Rect(0, 0, 80 - statAreaWidth, 24 - 3);

            Map = new Map();
        }

        static private Game _instance;

        static public Game Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Game();
                }

                return _instance;
            }
        }

        public void DoTick()
        {
            doTick = true;
        }

        public void ExitGame()
        {
            exit = true;
        }

        public bool Update()
        {
            if (ClearRequested)
            {
                ClearRequested = false;
                FrameBuffer.Instance.Clear();
            }

            KeyboardHandler.Update_Keyboard();

            Map.CurrentFloor.Update(doTick);
            doTick = false;

            return true;
        }
    }
}
