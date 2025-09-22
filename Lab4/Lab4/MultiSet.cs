using System.Collections.Generic;
using System.Dynamic;

namespace Lab4
{
    public sealed class MultiSet
    {
        public List<string> MultisetList { get; private set; }
        
        public MultiSet ()
        {
            List<string> multisetList = new List<string>();
            MultisetList = multisetList;
        }
        public void Add(string element)
        {
            MultisetList.Add(element);
            // ToDo 만약 정렬이 필요하다면 정렬함수 만들어서 호출
        }

        public bool Remove(string element)
        {
            int sizeOfMultisetList = MultisetList.Count;

            for (int i = 0; i < sizeOfMultisetList - 1; i++)
            {
                if (MultisetList[i] == element)
                {
                    MultisetList.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public uint GetMultiplicity(string element)
        {
            return 0;
        }

        public List<string> ToList()
        {
            return MultisetList;
        }

        public MultiSet Union(MultiSet other)
        {
            return null;
        }

        public MultiSet Intersect(MultiSet other)
        {
            return null;
        }

        public MultiSet Subtract(MultiSet other)
        {
            return null;
        }

        public List<MultiSet> FindPowerSet()
        {
            return null;
        }

        public bool IsSubsetOf(MultiSet other)
        {
            return false;
        }

        public bool IsSupersetOf(MultiSet other)
        {
            return false;
        }
    }
}