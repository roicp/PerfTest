using System.Collections.Generic;

namespace PerfTest.GoogleInterview
{
    public class Ex2
    {
        public static bool Solve(int[] data, int sum)
        {
            var complements = new HashSet<int>();

            foreach (var value in data)
            {
                if (complements.Contains(value))
                {
                    return true;
                }

                var comp = sum - value;
                complements.Add(comp);
            }

            return false;
        }
    }
}
