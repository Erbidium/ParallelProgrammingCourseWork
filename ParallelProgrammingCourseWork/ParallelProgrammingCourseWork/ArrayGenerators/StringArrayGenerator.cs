using ParallelProgrammingCourseWork.Abstractions;

namespace ParallelProgrammingCourseWork.ArrayGenerators;

public class StringArrayGenerator : IArrayGenerator<string>
{
    public string[] GenerateArray(int size)
    {
        var stringsArray = new string[size];
        
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        
        var stringBuffer = new char[4];
        var random = new Random();
        
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < stringBuffer.Length; j++)
            {
                stringBuffer[j] = chars[random.Next(chars.Length)];
            }

            stringsArray[i] = new string(stringBuffer);
        }

        return stringsArray;
    }
}