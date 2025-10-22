using System.Collections.Generic;

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

            return;
        }

        public bool Remove(string element)
        {
            int sizeOfMultisetList = MultisetList.Count;

            for (int i = 0; i < sizeOfMultisetList; i++)
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
            int sizeOfMultisetList = MultisetList.Count;
            uint count = 0;
            for (int i = 0; i < sizeOfMultisetList; i++)
            {
                if (MultisetList[i] == element)
                {
                    count++;
                }
            }
            return count;
        }

        public List<string> ToList()
        {
            MultisetList.Sort();

            return MultisetList;
        }

        public MultiSet Union(MultiSet other)
        {
            MultiSet union = new MultiSet();
            union.MultisetList = MultisetList;

            List<string> othersList = new List<string>();
            othersList = other.ToList();

            string previousString;
            string currentString;

            uint othersMultiplicity = 0;
            uint ownMultiplicity = 0;

            for (int i = 0; i < othersList.Count; i++)
            {
                if (i == 0)
                {
                    othersMultiplicity = other.GetMultiplicity(othersList[i]);
                    ownMultiplicity = GetMultiplicity(othersList[i]);

                    if (othersMultiplicity > ownMultiplicity)
                    {
                        for (int j = 0; j < othersMultiplicity - ownMultiplicity; j++)
                        {
                            union.Add(othersList[i]);
                        }
                    }
                }
                else
                {
                    previousString = othersList[i - 1];
                    currentString = othersList[i];

                    if (previousString != currentString)
                    {
                        othersMultiplicity = other.GetMultiplicity(othersList[i]);
                        ownMultiplicity = GetMultiplicity(othersList[i]);

                        if (othersMultiplicity > ownMultiplicity)
                        {
                            for (int j = 0; j < othersMultiplicity - ownMultiplicity; j++)
                            {
                                union.Add(othersList[i]);
                            }
                        }
                    }
                }
            }
            return union;
        }

        public MultiSet Intersect(MultiSet other)
        {
            MultiSet intersect = new MultiSet();

            List<string> othersList = new List<string>();
            othersList = other.ToList();

            string previousString;
            string currentString;

            uint othersMultiplicity = 0;
            uint ownMultiplicity = 0;

            uint minMultiplicity = 0;

            for (int i = 0; i < othersList.Count; i++)
            {
                if (i == 0)
                {
                    ownMultiplicity = GetMultiplicity(othersList[i]);
                    othersMultiplicity = other.GetMultiplicity(othersList[i]);

                    if (ownMultiplicity != 0 && othersMultiplicity != 0)
                    {
                        if (ownMultiplicity >= othersMultiplicity)
                        {
                            minMultiplicity = othersMultiplicity;
                        }
                        else
                        {
                            minMultiplicity = ownMultiplicity;
                        }

                        for (int j = 0; j < minMultiplicity; j++)
                        {
                            intersect.Add(othersList[i]);
                        }
                    }
                }
                else
                {
                    previousString = othersList[i - 1];
                    currentString = othersList[i];

                    if (previousString != currentString)
                    {
                        ownMultiplicity = GetMultiplicity(othersList[i]);
                        othersMultiplicity = other.GetMultiplicity(othersList[i]);

                        if (ownMultiplicity != 0 && othersMultiplicity != 0)
                        {
                            if (ownMultiplicity >= othersMultiplicity)
                            {
                                minMultiplicity = othersMultiplicity;
                            }
                            else
                            {
                                minMultiplicity = ownMultiplicity;
                            }

                            for (int j = 0; j < minMultiplicity; j++)
                            {
                                intersect.Add(othersList[i]);
                            }
                        }
                    }
                }
            }


            return intersect;
        }

        public MultiSet Subtract(MultiSet other)
        {
            MultiSet subtract = new MultiSet();
            subtract.MultisetList = MultisetList;

            List<string> othersList = new List<string>();
            othersList = other.ToList();

            for (int i = 0; i < othersList.Count; i++)
            {
                subtract.Remove(othersList[i]);
            }

            return subtract;
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

        private void LexicographicOrder(List<string> MultisetList)
        {

            return;
        }
    }
}