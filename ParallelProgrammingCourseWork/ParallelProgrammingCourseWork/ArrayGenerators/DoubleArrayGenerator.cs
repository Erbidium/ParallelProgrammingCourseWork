using ParallelProgrammingCourseWork.Abstractions;

namespace ParallelProgrammingCourseWork.ArrayGenerators;

public class DoubleArrayGenerator : IArrayGenerator<double>
{
    public double[] GenerateArray(int size)
    {
        var array = new double[size];

        var random = new Random();
        for (var i = 0; i < array.Length; i++)
        {
            array[i] = random.NextDouble();
        }

        return array;
    }
}