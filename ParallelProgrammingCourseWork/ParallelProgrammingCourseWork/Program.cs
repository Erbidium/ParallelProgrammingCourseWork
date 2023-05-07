using System.Diagnostics;
using ParallelProgrammingCourseWork;

double RunParallelAlgo()
{
    int[] array = ArrayGenerator.GenerateRandomArray(10000000);
    //Console.WriteLine("Initial array");
    //ArrayPrinter.PrintArray(array);

    var startTime = Stopwatch.GetTimestamp();

    //var sorter = new SequentialMergeSorter();
    var sorter = new ParallelInvokeMergeSorter(8);
    //var sorter = new ParallelTaskMergeSorter(8);
    sorter.Sort(array);

    var endTime = Stopwatch.GetElapsedTime(startTime);
    //Console.WriteLine(endTime.TotalSeconds);
    
    if (!ArrayValidator.ArrayIsSorted(array))
        Console.WriteLine("Array is not sorted correctly");

    return endTime.TotalSeconds;

    //Console.WriteLine("Sorted array");
    //ArrayPrinter.PrintArray(array);
}

double sum = 0;
int count = 0;
for (int i = 0; i < 6; i++)
{
    sum += RunParallelAlgo();
    count++;
}

Console.WriteLine(sum / count);

