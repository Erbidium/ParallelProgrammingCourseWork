namespace ParallelProgrammingCourseWork.ArrayHelpers;

public static class ArrayValidator<T>
    where T : IComparable<T>
{
    public static bool ArrayIsSorted(T[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            if (array[i].CompareTo(array[i + 1]) > 0)
                return false;
        }

        return true;
    }
}