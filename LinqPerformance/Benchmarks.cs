using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqPerformance
{
    [SimpleJob(RuntimeMoniker.Net60)]
    [SimpleJob(RuntimeMoniker.Net70)]
    [MemoryDiagnoser(false)]
    public class Benchmarks
    {
        [Params(100)]
        public int Size { get; set; }
        private IEnumerable<int> _items { get; set; }

        [GlobalSetup]
        public void Setup()
        {
            _items = Enumerable.Range(0, 100).ToArray();
        }

        [Benchmark]
        public int Min() => _items.Min();

        [Benchmark]
        public int Max() => _items.Max();

        [Benchmark]
        public double Average() => _items.Average();

        [Benchmark]
        public int Sum() => _items.Sum();
    }
}
