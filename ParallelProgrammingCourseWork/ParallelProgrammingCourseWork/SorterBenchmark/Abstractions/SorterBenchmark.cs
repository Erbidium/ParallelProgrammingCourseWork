using System.Diagnostics;
using ParallelProgrammingCourseWork.Abstractions;
using ParallelProgrammingCourseWork.ArrayHelpers;

namespace ParallelProgrammingCourseWork.SorterBenchmark.Abstractions;

public abstract class SorterBenchmark<TSortedType>
    where TSortedType : IComparable<TSortedType>
{
    public abstract void Run();

    protected static double Run(ISorter<TSortedType> sorter, int executionTimesCount, TSortedType[] array)
    {
        double millisecondsSum = 0;
        
        for (int i = 0; i < executionTimesCount; i++)
        {
            //test run
            var testArrayCopyToSort = array[..];
            sorter.Sort(testArrayCopyToSort);
            
            var arrayCopyToSort = array[..];
            
            var startTime = Stopwatch.GetTimestamp();
            
            sorter.Sort(arrayCopyToSort);

            var executionTime = Stopwatch.GetElapsedTime(startTime);

            millisecondsSum += executionTime.TotalMilliseconds;
    
            if (!ArrayValidator<TSortedType>.ArrayIsSorted(arrayCopyToSort))
                Console.WriteLine("Array is not sorted correctly");
            
            Console.WriteLine($"Attempt {i + 1}, time: {executionTime.TotalMilliseconds}");
            
            //Console.WriteLine("Sorted array");
            //ArrayPrinter.PrintArray(arrayCopyToSort);
        }

        return millisecondsSum / executionTimesCount;
    }
}