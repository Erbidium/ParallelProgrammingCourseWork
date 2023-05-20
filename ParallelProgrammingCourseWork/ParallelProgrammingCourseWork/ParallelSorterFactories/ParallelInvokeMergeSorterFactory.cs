using ParallelProgrammingCourseWork.Interfaces;
using ParallelProgrammingCourseWork.Sorters;

namespace ParallelProgrammingCourseWork.ParallelSorterFactories;

public class ParallelInvokeMergeSorterFactory : IParallelSorterFactory
{
    public ISorter CreateParallelSorter(int workersNumber)
    {
        return new ParallelInvokeMergeSorter(workersNumber);
    }
}