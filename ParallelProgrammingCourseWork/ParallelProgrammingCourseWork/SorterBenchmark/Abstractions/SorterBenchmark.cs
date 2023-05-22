using System.Diagnostics;
using ParallelProgrammingCourseWork.Abstractions;
using ParallelProgrammingCourseWork.ArrayHelpers;

namespace ParallelProgrammingCourseWork.SorterBenchmark.Abstractions;

public abstract class SorterBenchmark
{
    public abstract void Run();

    protected static double Run(ISorter sorter, int executionTimesCount, int[] array)
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
    
            if (!ArrayValidator.ArrayIsSorted(arrayCopyToSort))
                Console.WriteLine("Array is not sorted correctly");
            
            Console.WriteLine($"Attempt {i + 1}, time: {executionTime.TotalMilliseconds}");
            
            //Console.WriteLine("Sorted array");
            //ArrayPrinter.PrintArray(arrayCopyToSort);
        }

        return millisecondsSum / executionTimesCount;
    }
}