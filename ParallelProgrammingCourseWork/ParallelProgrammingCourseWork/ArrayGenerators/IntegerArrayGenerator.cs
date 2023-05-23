using ParallelProgrammingCourseWork.Abstractions;

namespace ParallelProgrammingCourseWork.ArrayGenerators;

public class IntegerArrayGenerator : IArrayGenerator<int>
{
    public int[] GenerateArray(int size)
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