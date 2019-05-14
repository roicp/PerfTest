using System;
using System.Diagnostics;
using PerfTest.GoogleInterview;
using PerfTest.ValidaCpf;
using PerftTest.MiddlewarePipeline;

namespace PerfTest.App
{
    public class Program
    {
        static void Main(string[] args)
        {
            var sw = new Stopwatch();
            var before2 = GC.CollectionCount(2);
            var before1 = GC.CollectionCount(1);
            var before0 = GC.CollectionCount(0);
            Func<string, bool> sut = Version1.ValidarCPF;

            sw.Start();

            for (var i = 0; i < 1000000; i++)
            {
                if (!sut("771.189.500-33"))
                {
                    throw new Exception("Error!");
                }

                if (sut("771.189.500-34"))
                {
                    throw new Exception("Error!");
                }
            }

            sw.Stop();

            Console.WriteLine($"Tempo total: {sw.ElapsedMilliseconds} ms");
            Console.WriteLine($"GC Gen #2  : {GC.CollectionCount(2) - before2}");
            Console.WriteLine($"GC Gen #1  : {GC.CollectionCount(1) - before1}");
            Console.WriteLine($"GC Gen #0  : {GC.CollectionCount(0) - before0}");
            Console.WriteLine("Done!");
        }

        public static void CallGoogleInterview()
        {
            var case1 = new[] { 1, 2, 3, 9 };
            var case2 = new[] { 1, 2, 4, 4 };

            var sum = 8;

            var result0Case1 = Ex0.Solve(case1, sum);
            var result0Case2 = Ex0.Solve(case2, sum);

            var result1Case1 = Ex1.Solve(case1, sum);
            var result1Case2 = Ex1.Solve(case2, sum);

            var result2case1 = Ex2.Solve(case1, sum);
            var result2case2 = Ex2.Solve(case2, sum);
        }

        public static void CallPipeline()
        {
            var pipeline = new Pipeline(
                new LoggingMiddleware(),
                new LoggingMiddleware(),
                new TransactionMiddleware(),
                new CommandHandleMiddleware());

            pipeline.Handle(new CadastrarUsuario { Nome = "Israel" });
        }
    }
}
