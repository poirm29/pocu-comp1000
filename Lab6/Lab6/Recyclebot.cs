using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    internal class Recyclebot
    {
        public List<Item> RecycleItems { get; }
        public List<Item> NonRecycleItems { get; }

        public Recyclebot()
        {
            RecycleItems = new List<Item>();
            NonRecycleItems = new List<Item>();
        }

        public void Add(Item item)
        {
            if (item.Type == EType.Paper || item.Type == EType.Furniture || item.Type == EType.Electronics)
            {
                if (item.Weight < 2 || item.Weight >= 5)
                {
                    NonRecycleItems.Add(item);
                }
            }
            else
            {
                RecycleItems.Add(item);
            }
        }

        public List<Item> Dump()
        {
            List<Item> DumpItems = new List<Item>();
            foreach (var item in NonRecycleItems)
            {
                if (!((item.Volume == 10 || item.Volume == 11 || item.Volume == 15) && item.IsToxicWaste == false))
                {
                    if (!(item.Type == EType.Furniture || item.Type == EType.Electronics))
                    {

                    }
                }
                else
                {
                    DumpItems.Add(item);
                }
            }

            return DumpItems;
        }
    }
}
