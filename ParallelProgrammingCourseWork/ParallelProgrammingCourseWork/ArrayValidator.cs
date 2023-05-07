namespace ParallelProgrammingCourseWork;

public static class ArrayValidator
{
    public static bool ArrayIsSorted(int[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            if (array[i] > array[i + 1])
                return false;
        }

        return true;
    }
}