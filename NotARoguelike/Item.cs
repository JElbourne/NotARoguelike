using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotARoguelike
{
    class Item
    {
        public string Name { get; set; }
        public bool Static { get; set; }
        public Chixel Chixel { get; set; }
        public int Value = 0;

        public event Action<Item> OnPickup;

        public void Draw(int x, int y)
        {
            FrameBuffer.Instance.SetChixel(x, y, Chixel);
        }

        public void Pickup()
        {
            OnPickup?.Invoke(this);
        }
    }
}
