namespace ParallelProgrammingCourseWork.Abstractions;

public abstract class ParallelSorter<T> : ISorter<T> where T : IComparable<T>
{
    protected readonly int WorkersNumber;

    protected ParallelSorter(int workersNumber)
    {
        WorkersNumber = workersNumber;
    }
        
    
    public abstract void Sort(T[] array);

}