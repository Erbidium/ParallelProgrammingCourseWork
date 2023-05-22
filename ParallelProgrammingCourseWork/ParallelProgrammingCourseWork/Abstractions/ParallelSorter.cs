namespace ParallelProgrammingCourseWork.Abstractions;

public abstract class ParallelSorter : ISorter
{
    protected readonly int WorkersNumber;

    protected ParallelSorter(int workersNumber)
    {
        WorkersNumber = workersNumber;
    }
        
    
    public abstract void Sort(int[] array);

}