namespace ParallelProgrammingCourseWork;

public static class ArrayPrinter
{
    public static void PrintArray(int[] array)
    {
        foreach (var element in array)
            Console.Write($"{element} ");

        Console.WriteLine();
    }
}