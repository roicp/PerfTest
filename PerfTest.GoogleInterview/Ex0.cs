namespace PerfTest.GoogleInterview
{
    public class Ex0
    {
        public static bool Solve(int[] data, int sum)
        {
            for (var i = 0; i < data.Length; i++)
            {
                for (var j = i + 1; j < data.Length; j++)
                {
                    var s = data[i] + data[j];

                    if (s == sum)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
