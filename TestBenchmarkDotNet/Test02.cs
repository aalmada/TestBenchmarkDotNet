using System.Linq;
using BenchmarkDotNet.Attributes;

namespace TestBenchmarkDotNet
{
    public class Test02 : TestsBase
    {
        [Benchmark(Baseline = true)]
        public int BaselineTest()
            => source.Sum();

        [Benchmark]
        public int AnotherTest()
            => source.Sum();
    }
}