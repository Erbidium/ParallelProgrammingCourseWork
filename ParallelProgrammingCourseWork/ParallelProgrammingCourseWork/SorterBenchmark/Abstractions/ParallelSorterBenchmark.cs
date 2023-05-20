using ParallelProgrammingCourseWork.ArrayHelpers;
using ParallelProgrammingCourseWork.Interfaces;

namespace ParallelProgrammingCourseWork.SorterBenchmark.Abstractions;

public abstract class ParallelSorterBenchmark : Abstractions.SorterBenchmark
{
    private readonly int _executionTimesCount;
    
    private readonly int _randomArraySize;

    private readonly int[] _workersNumberForTesting;

    protected abstract IParallelSorterFactory ParallelSorterFactory { get; }

    protected ParallelSorterBenchmark
    (
        int executionTimesCount,
        int randomArraySize,
        params int[] workersNumberForTesting
    )
    {
        _executionTimesCount = executionTimesCount;
        _randomArraySize = randomArraySize;
        _workersNumberForTesting = workersNumberForTesting;
    }
    
    public override void Run()
    {
        var array = ArrayGenerator.GenerateRandomArray(_randomArraySize);
        Console.WriteLine("Initial array");
        ArrayPrinter.PrintArray(array);
        

        foreach (var workersNumber in _workersNumberForTesting)
        {
            var sorter = ParallelSorterFactory.CreateParallelSorter(workersNumber);
            Run(sorter, _executionTimesCount, array);
        }
    }
}