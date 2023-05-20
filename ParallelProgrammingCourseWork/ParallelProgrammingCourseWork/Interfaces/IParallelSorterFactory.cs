namespace ParallelProgrammingCourseWork.Interfaces;

public interface IParallelSorterFactory
{
    public ISorter CreateParallelSorter(int workersNumber);
}