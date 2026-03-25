using System.Collections.Generic;
using System.Linq;

namespace Assignment3
{
    public static class StepMaker
    {
        public static List<int> MakeSteps(int[] steps, INoise noise)
        {
            List<int> makingSteps = new List<int>();
            makingSteps = steps.ToList();

            return makingSteps;
        }

        public static void MakeStepsRecursive(List<int> makingSteps, int p1, int p2, INoise noise, int level)
        {
            
        }
    }
}