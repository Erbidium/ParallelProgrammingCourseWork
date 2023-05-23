using ParallelProgrammingCourseWork.Abstractions;

namespace ParallelProgrammingCourseWork.Sorters;

public class SequentialMergeSorter<T> : ISorter<T> where T : IComparable<T>
{
    public void Sort(T[] array)
    {
        MergeSort(array, 0, array.Length - 1);
    }
    
    public static void MergeSort(T[] array, int leftIndex, int rightIndex)
    {
        if (leftIndex >= rightIndex) return;
        
        var middlePoint = (leftIndex + rightIndex) / 2;
            
        MergeSort(array, leftIndex, middlePoint);
        MergeSort(array, middlePoint + 1, rightIndex);

        Merge(array, leftIndex, middlePoint, rightIndex);
    }

    public static void Merge(T[] array, int leftIndex, int middlePoint, int rightIndex)
    {
        int firstSubArraySize = middlePoint - leftIndex + 1;
        int secondSubArraySize = rightIndex - middlePoint;

        var firstSubArrayTemp = new T[firstSubArraySize];
        var secondSubArrayTemp = new T[secondSubArraySize];

        Array.Copy(array, leftIndex, firstSubArrayTemp, 0, firstSubArraySize);
        Array.Copy(array, middlePoint + 1, secondSubArrayTemp, 0, secondSubArraySize);
        
        int firstSubArrayIndex = 0;
        int secondSubArrayIndex = 0;

        int mergedSubArrayIndex = leftIndex;
        while (firstSubArrayIndex < firstSubArraySize && secondSubArrayIndex < secondSubArraySize) {
            if (firstSubArrayTemp[firstSubArrayIndex].CompareTo(secondSubArrayTemp[secondSubArrayIndex]) <= 0) {
                array[mergedSubArrayIndex] = firstSubArrayTemp[firstSubArrayIndex];
                firstSubArrayIndex++;
            }
            else {
                array[mergedSubArrayIndex] = secondSubArrayTemp[secondSubArrayIndex];
                secondSubArrayIndex++;
            }
            mergedSubArrayIndex++;
        }
        
        while (firstSubArrayIndex < firstSubArraySize) {
            array[mergedSubArrayIndex] = firstSubArrayTemp[firstSubArrayIndex];
            firstSubArrayIndex++;
            mergedSubArrayIndex++;
        }
        
        while (secondSubArrayIndex < secondSubArraySize) {
            array[mergedSubArrayIndex] = secondSubArrayTemp[secondSubArrayIndex];
            secondSubArrayIndex++;
            mergedSubArrayIndex++;
        }
    }
}