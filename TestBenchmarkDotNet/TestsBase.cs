using System.Linq;
using BenchmarkDotNet.Attributes;

namespace TestBenchmarkDotNet
{
    public abstract class TestsBase
    {
        protected int[] source;
        
        [Params(10)]
        public int Count { get; set; }
        
        [GlobalSetup]
        public void GlobalSetup()
            => source = Enumerable.Range(0, Count).ToArray();
    }
}