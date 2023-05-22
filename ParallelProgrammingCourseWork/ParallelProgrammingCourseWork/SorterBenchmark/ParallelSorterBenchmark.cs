using ParallelProgrammingCourseWork.Abstractions;
using ParallelProgrammingCourseWork.ArrayHelpers;

namespace ParallelProgrammingCourseWork.SorterBenchmark;

public class ParallelSorterBenchmark<T> : Abstractions.SorterBenchmark where T : ParallelSorter
{
    private readonly int _executionTimesCount;
    
    private readonly int _randomArraySize;

    private readonly int[] _workersNumberForTesting;

    public ParallelSorterBenchmark
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
        //Console.WriteLine("Initial array");
        //ArrayPrinter.PrintArray(array);
        

        foreach (var workersNumber in _workersNumberForTesting)
        {
            var sorter = (T)Activator.CreateInstance(typeof(T), workersNumber)!;

            var averageExecutionTime = Run(sorter, _executionTimesCount, array);
        
            Console.WriteLine($"Average execution time: {averageExecutionTime} with {workersNumber} workers");
        }
    }
}