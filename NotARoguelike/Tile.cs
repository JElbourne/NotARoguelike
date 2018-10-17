using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotARoguelike
{
    public enum TileType { FLOOR, WALL, DOOR_CLOSED, DOOR_OPENED, UPSTAIR, DOWNSTAIR, DEBRIS, DOOR_LOCKED }

    class Tile
    {
        const string TILE_GLYPHS = @" #+-<>x+";

        public int X { get; protected set; }
        public int Y { get; protected set; }
        public Floor Floor { get; protected set; }
        public Chixel Chixel { get; protected set; }
        public Character Character { get; set; }
        public Item Item { get; set; }
        public bool WasSeen { get; set; }

        private TileType _TileType;

        public Tile(int x, int y, Floor floor, char textChar)
        {

            this.X = x;
            this.Y = y;
            this.Floor = floor;
            Item item;

            switch (textChar)
            {
                case ' ':
                    break;
                case '#':
                    TileType = TileType.WALL;
                    break;
                case '@':
                    // Spawn a character (only if one doesn't exist)
                    Game.Instance.Messages.DebugMessage("Character spawned!");

                    if (Game.Instance.PlayerCharacter != null)
                    {
                        throw new Exception("Already have a player character!");
                    }
                    Game.Instance.PlayerCharacter = new PlayerCharacter(this, this.Floor, new Chixel('@', ConsoleColor.DarkYellow));
                    break;
                default:
                    break;
            }
        }

        public TileType TileType
        {
            get
            {
                return _TileType;
            }
            set
            {
                _TileType = value;
                Chixel = new Chixel(TILE_GLYPHS[(int)_TileType]);
                if (_TileType == TileType.DOOR_LOCKED)
                {
                    Chixel.ForegroundColor = ConsoleColor.Red;
                }
            }
        }
    }
}