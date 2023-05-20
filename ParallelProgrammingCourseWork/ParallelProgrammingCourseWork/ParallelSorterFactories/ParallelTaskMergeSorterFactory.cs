using ParallelProgrammingCourseWork.Interfaces;
using ParallelProgrammingCourseWork.Sorters;

namespace ParallelProgrammingCourseWork.ParallelSorterFactories;

public class ParallelTaskMergeSorterFactory : IParallelSorterFactory
{
    public ISorter CreateParallelSorter(int workersNumber)
    {
        return new ParallelTaskMergeSorter(workersNumber);
    }
}