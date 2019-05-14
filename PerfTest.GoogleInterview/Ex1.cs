namespace PerfTest.GoogleInterview
{
    public class Ex1
    {
        public static bool Solve(int[] data, int sum)
        {
            var low = 0;
            var hi = data.Length - 1;

            while (low < hi)
            {
                var s = data[low] + data[hi];

                if (s == sum)
                {
                    return true;
                }

                if (s < sum)
                {
                    low++;
                }

                if (s > sum)
                {
                    hi--;
                }
            }

            return false;
        }
    }
}
