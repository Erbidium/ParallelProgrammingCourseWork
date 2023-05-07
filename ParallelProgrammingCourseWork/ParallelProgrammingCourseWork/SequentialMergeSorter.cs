namespace ParallelProgrammingCourseWork;

public class SequentialMergeSorter : ISorter
{
    public void Sort(int[] array)
    {
        MergeSort(array, 0, array.Length - 1);
        //ParallelTaskMergeSort(array, 0, array.Length - 1);
        //ParallelForMergeSort(array, 0, array.Length - 1);
    }
    
    private static void MergeSort(int[] array, int leftIndex, int rightIndex)
    {
        if (leftIndex >= rightIndex) return;
        
        var middlePoint = (leftIndex + rightIndex) / 2;
            
        MergeSort(array, leftIndex, middlePoint);
        MergeSort(array, middlePoint + 1, rightIndex);

        Merge(array, leftIndex, middlePoint, rightIndex);
    }
    
    private static void ParallelTaskMergeSort(int[] array, int leftIndex, int rightIndex)
    {
        if (leftIndex >= rightIndex) return;
        
        var middlePoint = (leftIndex + rightIndex) / 2;
            
        var task1 = Task.Run(() =>
        {
            if (middlePoint - leftIndex > 4000)
            {
                ParallelTaskMergeSort(array, leftIndex, middlePoint);
            }
            else
            {
                MergeSort(array, leftIndex, middlePoint);
            }
        });
        var task2 = Task.Run(() =>
        {
            if (rightIndex - middlePoint - 1 > 4000)
            {
                ParallelTaskMergeSort(array, middlePoint + 1, rightIndex);
            }
            else
            {
                MergeSort(array, middlePoint + 1, rightIndex);
            }
            
        });

        Task.WaitAll(task1, task2);

        Merge(array, leftIndex, middlePoint, rightIndex);
    }
    
    private static void ParallelForMergeSort(int[] array, int leftIndex, int rightIndex)
    {
        if (leftIndex >= rightIndex) return;
        
        var middlePoint = (leftIndex + rightIndex) / 2;

        var leftIndices = new [] { leftIndex, middlePoint + 1 };
        var rightIndices = new[] { middlePoint + 1, rightIndex };

        Parallel.For(0, 2, index =>
        {
            if (rightIndices[index] - leftIndices[index] > 4000)
            {
                ParallelForMergeSort(array, leftIndices[index], rightIndices[index]);
            }
            else
            {
                MergeSort(array, middlePoint + 1, rightIndex);
            }
        });

        Merge(array, leftIndex, middlePoint, rightIndex);
    }
    
    private static void Merge(int[] array, int leftIndex, int middlePoint, int rightIndex)
    {
        int firstSubArraySize = middlePoint - leftIndex + 1;
        int secondSubArraySize = rightIndex - middlePoint;

        var firstSubArrayTemp = new int[firstSubArraySize];
        var secondSubArrayTemp = new int[secondSubArraySize];

        Array.Copy(array, leftIndex, firstSubArrayTemp, 0, firstSubArraySize);
        Array.Copy(array, middlePoint + 1, secondSubArrayTemp, 0, secondSubArraySize);
        
        int firstSubArrayIndex = 0;
        int secondSubArrayIndex = 0;

        int mergedSubArrayIndex = leftIndex;
        while (firstSubArrayIndex < firstSubArraySize && secondSubArrayIndex < secondSubArraySize) {
            if (firstSubArrayTemp[firstSubArrayIndex] <= secondSubArrayTemp[secondSubArrayIndex]) {
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