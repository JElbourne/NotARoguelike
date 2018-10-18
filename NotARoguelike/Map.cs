using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotARoguelike
{
    class Map
    {
        private Floor[] floors;

        public Map()
        {
            CurrentFloorIndex = 0;


            floors = new Floor[FloorMaps.floors.Length];

            for (int i = 0; i < floors.Length; i++)
            {
                floors[i] = new Floor(FloorMaps.floors[i], i);
            }
        }

        public int CurrentFloorIndex { get; set; }

        public Floor CurrentFloor
        {
            get
            {
                return floors[CurrentFloorIndex];
            }
            set
            {
                for (int i = 0; i < floors.Length; i++)
                {
                    if (floors[i] == value)
                    {
                        CurrentFloorIndex = i;
                        return;
                    }
                }

                throw new Exception("Didn't find floor.");
            }
        }

        public int NumFloors
        {
            get
            {
                return floors.Length;
            }
        }

        public Floor GetFloor(int index)
        {
            if (index < 0 || index >= floors.Length)
            {
                throw new Exception();
            }

            return floors[index];
        }

    }
}
