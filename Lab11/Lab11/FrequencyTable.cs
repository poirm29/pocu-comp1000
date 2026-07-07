using System;
using System.Collections.Generic;

namespace Lab11
{
    public static class FrequencyTable
    {
        public static List<Tuple<Tuple<int, int>, int>> GetFrequencyTable(int[] data, int maxBinCount)
        {
            int minNum = data[0];
            int maxNum = data[0];

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] < minNum)
                {
                    minNum = data[i];
                }
                if (data[i] > maxNum)
                {
                    maxNum = data[i];
                }
            }

            int intervalWidth = (maxNum - minNum) / maxBinCount + 1;

            int binCount = (maxNum - minNum) / intervalWidth + 1;

            var frequencyTable = new List<Tuple<Tuple<int, int>, int>>(binCount);

            int coverage = minNum;

            for (int i = 0; i < binCount; i++)
            {
                int count = 0;

                for (int j = 0; j < data.Length; j++)
                {
                    if (data[j] >= coverage && data[j] < coverage + intervalWidth)
                    {
                        count++;
                    }
                }
                var interval = new Tuple<int, int>(coverage, coverage + intervalWidth);
                var frequency = new Tuple<Tuple<int, int>, int>(interval, count);

                coverage = coverage + intervalWidth;

                frequencyTable.Add(frequency);
            }

            return frequencyTable;
        }
    }
}