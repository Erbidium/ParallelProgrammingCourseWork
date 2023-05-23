using ParallelProgrammingCourseWork.Abstractions;
using ParallelProgrammingCourseWork.ArrayHelpers;

namespace ParallelProgrammingCourseWork.SorterBenchmark;

public class ParallelSorterBenchmark<TParallelSorter, TSortedType> : Abstractions.SorterBenchmark<TSortedType>
    where TParallelSorter : ParallelSorter<TSortedType>
    where TSortedType : IComparable<TSortedType>
{
    private readonly int _executionTimesCount;
    
    private readonly int _randomArraySize;

    private readonly int[] _workersNumberForTesting;

    private IArrayGenerator<TSortedType> _arrayGenerator;

    public ParallelSorterBenchmark
    (
        int executionTimesCount,
        int randomArraySize,
        IArrayGenerator<TSortedType> arrayGenerator,
        params int[] workersNumberForTesting
    )
    {
        _arrayGenerator = arrayGenerator;
        _executionTimesCount = executionTimesCount;
        _randomArraySize = randomArraySize;
        _workersNumberForTesting = workersNumberForTesting;
    }
    
    public override void Run()
    {
        var array = _arrayGenerator.GenerateArray(_randomArraySize);
        //Console.WriteLine("Initial array");
        //ArrayPrinter.PrintArray(array);
        

        foreach (var workersNumber in _workersNumberForTesting)
        {
            var sorter = (TParallelSorter)Activator.CreateInstance(typeof(TParallelSorter), workersNumber)!;

            var averageExecutionTime = Run(sorter, _executionTimesCount, array);
        
            Console.WriteLine($"Average execution time: {averageExecutionTime} with {workersNumber} workers");
        }
    }
}