namespace ParallelProgrammingCourseWork.Abstractions;

public interface IArrayGenerator<out T> where T : IComparable<T>
{
    T[] GenerateArray(int size);
}