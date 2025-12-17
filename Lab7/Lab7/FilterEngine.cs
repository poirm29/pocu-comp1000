using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    public static class FilterEngine
    {
        public static List<Frame> FilterFrames(List<Frame> frames, EFeatureFlags features)
        {
            List<Frame> filteredFramesList = new List<Frame>();
            
            foreach (var frame in frames)
            {
                if ((frame.Features & features) != 0)
                {
                    filteredFramesList.Add(frame);
                }
            }

            return filteredFramesList;
        }

        public static List<Frame> FilterOutFrames(List<Frame> frames, EFeatureFlags features)
        {
            List<Frame> filteredOutFramesList = new List<Frame>();

            foreach (var frame in frames)
            {
                if ((frame.Features & features) == 0)
                {
                    filteredOutFramesList.Add(frame);
                }
            }

            return filteredOutFramesList;
        }

        public static List<Frame> Intersect(List<Frame> frames1, List<Frame> frames2)
        {
            List<Frame> intersectionList = new List<Frame>();
            foreach (var frameIn1 in frames1)
            {
                foreach (var frameIn2 in frames2)
                {
                    if (frameIn1 == frameIn2)
                    {
                        intersectionList.Add(frameIn2);
                        break;
                    }
                }
            }

            return intersectionList;
        }
    }
}