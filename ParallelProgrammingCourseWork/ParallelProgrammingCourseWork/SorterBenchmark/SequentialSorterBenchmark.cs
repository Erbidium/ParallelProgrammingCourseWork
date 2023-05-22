using ParallelProgrammingCourseWork.ArrayHelpers;
using ParallelProgrammingCourseWork.Sorters;

namespace ParallelProgrammingCourseWork.SorterBenchmark;

public class SequentialSorterBenchmark : Abstractions.SorterBenchmark
{
    private readonly int _executionTimesCount;

    private readonly int _randomArraySize;
    
    public SequentialSorterBenchmark(int executionTimesCount, int randomArraySize)
    {
        _executionTimesCount = executionTimesCount;
        _randomArraySize = randomArraySize;
    }
    
    public override void Run()
    {
        var array = ArrayGenerator.GenerateRandomArray(_randomArraySize);
        //Console.WriteLine("Initial array");
        //ArrayPrinter.PrintArray(array);
        
        var sorter = new SequentialMergeSorter();
        var averageExecutionTime = Run(sorter, _executionTimesCount, array);
        
        Console.WriteLine($"Average execution time: {averageExecutionTime}");
    }
}