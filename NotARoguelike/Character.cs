 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotARoguelike
{
    class Character
    {
        public int X { get; protected set; }
        public int Y { get; protected set; }
        public int Cooldown { get; set; }
        private Floor _Floor;
        public Floor Floor
        {
            get
            {
                return _Floor;
            }
            set
            {
                if (value != _Floor)
                {
                    if (_Floor != null)
                    {
                        _Floor.RemoveCharacter(this);
                    }

                    _Floor = value;
                    _Floor.AddCharacter(this);
                }
            }
        }
        public Chixel Chixel { get; set; }
        private Tile _Tile;
        public Tile Tile
        {
            get
            {
                return _Tile;
            }
            set
            {
                if (_Tile != null && _Tile.Character == this)
                    _Tile.Character = null;

                _Tile = value;

                if (_Tile != null)
                {
                    this.X = _Tile.X;
                    this.Y = _Tile.Y;
                    this.Floor = _Tile.Floor;
                    _Tile.Character = this;
                }
            }
        }

        public Character(Tile tile, Floor floor, Chixel chixel)
        {

        }

        virtual public void Update()
        {
            if (Cooldown > 0)
                Cooldown--;
        }

        public bool MoveBy(int dX, int dY)
        {
            return MoveTo(X + dX, Y + dY);
        }

        virtual public bool MoveTo(int newX, int newY)
        {
            // Check bounds
            if (newX < 0 || newX >= this.Floor.Width || newY < 0 || newY >= this.Floor.Height)
            {
                // Don't allow this move.
                return false;
            }

            if (newX == X && newY == Y)
            {
                // No move requested.
                return true;
            }

            Tile newTile = this.Floor.GetTile(newX, newY);

            // Is there an enemy standing in our target tile?
            if (newTile.Character != null)
            {

                if (newTile.Character != null)
                {
                    // Character is still there. Abort move,
                    // but tell the character to stop trying.
                    return true;
                }
            }
            // If so, we should try to melee attack it.
            // If that kills it, then we can move in.

            if (newTile.IsWalkable() == false)
            {
                // Not walkable.
                if (this == PlayerCharacter.Instance)
                {
                    if (newTile.TileType == TileType.DOOR_LOCKED)
                    {
                        Game.Instance.Messages.Message("This door is locked.");
                    }
                    else
                    {
                        Game.Instance.Messages.Message("**thud**");
                    }
                }
                return false;
            }

            if (newTile.TileType == TileType.DOOR_CLOSED)
            {
                if (OpenDoor(newTile) == false)
                {
                    // failed to open door
                    return false;
                }

                if (this == Game.Instance.PlayerCharacter)
                {
                    Game.Instance.Messages.Message("You open a door.");
                }
                else
                {
                    Game.Instance.Messages.Message("A door opens.");
                }
            }

            X = newX;
            Y = newY;
            Tile = Floor.GetTile(X, Y);
            return true;
        }

        bool OpenDoor(Tile tile)
        {
            if (tile.TileType != TileType.DOOR_CLOSED)
            {
                throw new Exception();
            }

            tile.TileType = TileType.DOOR_OPENED;
            return true;
        }
    }
}
