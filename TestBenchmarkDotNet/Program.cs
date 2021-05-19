using System;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

namespace TestBenchmarkDotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = DefaultConfig.Instance
                .AddDiagnoser(MemoryDiagnoser.Default)
                .AddJob(Job.Default
                    .WithRuntime(CoreRuntime.Core50)
                    .WithId(".NET 5")
                );
                // .AddJob(Job.Default
                //     .WithRuntime(CoreRuntime.Core60)
                //     .WithEnvironmentVariables(
                //         new EnvironmentVariable("COMPlus_ReadyToRun", "0"),
                //         new EnvironmentVariable("COMPlus_TC_QuickJitForLoops", "1"),
                //         new EnvironmentVariable("COMPlus_TieredPGO", "1"))
                //     .WithId(".NET 6")
                // );
            
            Console.WriteLine("Executed tests:");
            foreach (var summary in BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args, config))
                Console.WriteLine(summary.Title);
        }
    }
}