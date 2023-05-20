using ParallelProgrammingCourseWork.Interfaces;
using ParallelProgrammingCourseWork.ParallelSorterFactories;
using ParallelProgrammingCourseWork.SorterBenchmark.Abstractions;

namespace ParallelProgrammingCourseWork.SorterBenchmark;

public class ParallelInvokeSorterBenchmark : ParallelSorterBenchmark
{
    public ParallelInvokeSorterBenchmark(int executionTimesCount, int randomArraySize, params int[] workersNumberForTesting) : base(executionTimesCount, randomArraySize, workersNumberForTesting)
    {
    }

    protected override IParallelSorterFactory ParallelSorterFactory => new ParallelInvokeMergeSorterFactory();
}