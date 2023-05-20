using System.Diagnostics;
using ParallelProgrammingCourseWork.ArrayHelpers;
using ParallelProgrammingCourseWork.Interfaces;

namespace ParallelProgrammingCourseWork.SorterBenchmark.Abstractions;

public abstract class SorterBenchmark
{
    public abstract void Run();

    protected static void Run(ISorter sorter, int executionTimesCount, int[] array)
    {
        for (int i = 0; i < executionTimesCount; i++)
        {
            var startTime = Stopwatch.GetTimestamp();
            
            sorter.Sort(array);

            var endTime = Stopwatch.GetElapsedTime(startTime);
            Console.WriteLine(endTime.TotalSeconds);
    
            if (!ArrayValidator.ArrayIsSorted(array))
                Console.WriteLine("Array is not sorted correctly");
            
            Console.WriteLine(endTime.TotalMilliseconds);
        }

        //Console.WriteLine("Sorted array");
        //ArrayPrinter.PrintArray(array);
    }
}