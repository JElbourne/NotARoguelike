using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace NotARoguelike
{
    class PlayerCharacter : Character
    {
        public const int DefaultVisionRadius = 2;

        private int target_dX;
        private int target_dY;
        public Item[] Items { get; set; }
        public int Money { get; set; }
        private int _VisionRadius;
        public int VisionRadius
        {
            get
            {
                return _VisionRadius;
            }

            set
            {
                _VisionRadius = value;
                UpdateVision();
            }
        }

        private static PlayerCharacter _instance;

        static public PlayerCharacter Instance
        {
            get
            {
                return _instance;
            }
        }

        public PlayerCharacter(Tile tile, Floor floor, Chixel chixel) : base(tile, floor, chixel)
        {
            _instance = this;
            VisionRadius = DefaultVisionRadius;
        }

        public override void Update()
        {
            base.Update();

            if (target_dX != X || target_dY != Y)
            {
                MoveBy(target_dX, target_dY);
            }

            target_dX = target_dY = 0;
        }

        public void QueueMoveBy(int dX, int dY)
        {
            target_dX = dX;
            target_dY = dY;
        }

        public override bool MoveTo(int newX, int newY)
        {
            Tile t = Floor.GetTile(newX, newY);

            if (base.MoveTo(newX, newY) == false)
            {
                // Didn't actually move.
                return false;
            }

            // Are we on an item?
            Item item = Tile.Item;
            if (item != null && item.Static == false)
            {
                AddItem(item);
            }

            UpdateVision();

            return true;
        }

        public void UpdateVision()
        {
            // Set all tiles within our vision radius to WasSeen=true
            for (int x = -(VisionRadius); x <= VisionRadius; x++)
            {
                for (int y = -VisionRadius; y <= VisionRadius; y++)
                {
                    // Manhattan distance
                    //int d = Math.Abs(x) + Math.Abs(y);
                    int d = Utility.CircleDistance(0, 0, x, y);
                    if (d <= VisionRadius)
                    {
                        Tile t = Floor.GetTile(X + x, Y + y);
                        if (t != null)
                        {
                            t.WasSeen = true;
                            Floor.RedrawTileAt(X + x, Y + y);
                        }
                    }
                }
            }

        }

        public void AddItem(Item item)
        {
            // Pick it up!
            Tile.Item = null;

            Console.Beep();

            if (item.Value > 0)
            {
                // random amount of monies
                int m = Game.Instance.Random.Next(item.Value / 2, item.Value);

                m = (int)((double)m * Math.Pow(1.25, Game.Instance.Map.CurrentFloorIndex));

                this.Money += m;
                Game.Instance.Messages.Message(string.Format("Picked up {0} units of metal scraps.", m));
                return;
            }

            // Find first empty inventory slot
            for (int i = 0; i < Items.Length; i++)
            {
                if (Items[i] == null)
                {
                    Items[i] = item;
                    item.Pickup();
                    Game.Instance.Messages.Message(string.Format("Picked up: [{0}] {1}", (char)((int)'a' + i), item.Name));
                    return;
                }
            }

            Game.Instance.Messages.Message(string.Format("Can't pick up {0}. Inventory is full!", item.Name));
            Tile.Item = item;
        }

        public void RemoveItem(int i)
        {
            Items[i] = null;
            return;
        }

        public void RemoveItem(Item item)
        {
            for (int i = 0; i < Items.Length; i++)
            {
                if (Items[i] == item)
                {
                    RemoveItem(i);
                    return;
                }
            }
        }
    }
}
