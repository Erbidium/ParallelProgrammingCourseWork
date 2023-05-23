namespace ParallelProgrammingCourseWork.Abstractions;

public interface ISorter<in T> where T : IComparable<T>
{
    void Sort(T[] array);
}