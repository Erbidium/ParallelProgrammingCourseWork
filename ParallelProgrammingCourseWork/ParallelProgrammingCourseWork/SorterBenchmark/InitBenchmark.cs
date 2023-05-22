using ParallelProgrammingCourseWork.ArrayHelpers;
using ParallelProgrammingCourseWork.Sorters;

namespace ParallelProgrammingCourseWork.SorterBenchmark;

public class InitBenchmark : Abstractions.SorterBenchmark
{
    public override void Run()
    {
        var array = ArrayGenerator.GenerateRandomArray(1000);
        
        var invokeSorter = new ParallelInvokeMergeSorter(8);
        var taskSorter = new ParallelTaskMergeSorter(8);

        invokeSorter.Sort(array);
        taskSorter.Sort(array);
    }
}