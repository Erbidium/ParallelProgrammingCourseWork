using ParallelProgrammingCourseWork.Abstractions;
using ParallelProgrammingCourseWork.Sorters;

namespace ParallelProgrammingCourseWork.SorterBenchmark;

public class SequentialSorterBenchmark<TSortedType> : Abstractions.SorterBenchmark<TSortedType>
    where TSortedType : IComparable<TSortedType>
{
    private readonly int _executionTimesCount;

    private readonly int _randomArraySize;
    
    private IArrayGenerator<TSortedType> _arrayGenerator;
    
    public SequentialSorterBenchmark(int executionTimesCount, int randomArraySize, IArrayGenerator<TSortedType> arrayGenerator)
    {
        _arrayGenerator = arrayGenerator;
        _executionTimesCount = executionTimesCount;
        _randomArraySize = randomArraySize;
    }
    
    public override void Run()
    {
        var array = _arrayGenerator.GenerateArray(_randomArraySize);
        //Console.WriteLine("Initial array");
        //ArrayPrinter.PrintArray(array);
        
        var sorter = new SequentialMergeSorter<TSortedType>();
        var averageExecutionTime = Run(sorter, _executionTimesCount, array);
        
        Console.WriteLine($"Average execution time: {averageExecutionTime}");
    }
}