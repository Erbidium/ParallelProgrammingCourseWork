namespace ParallelProgrammingCourseWork.ArrayHelpers;

public static class ArrayGenerator
{
    public static int[] GenerateRandomArray(int size)
    {
        var array = new int[size];

        var random = new Random();
        for (var i = 0; i < array.Length; i++)
        {
            array[i] = random.Next(100);
        }

        return array;
    }
}