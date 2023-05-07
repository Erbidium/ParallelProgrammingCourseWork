namespace ParallelProgrammingCourseWork;

public class ParallelForMergeSorter : ISorter
{
    private int _workersNumber;
    
    public ParallelForMergeSorter(int workersNumber)
    {
        _workersNumber = workersNumber;
    }
    
    public void Sort(int[] array)
    {
        ParallelForMergeSort(array, 0, array.Length - 1);
    }
    
    private void ParallelForMergeSort(int[] array, int leftIndex, int rightIndex)
    {
        if (leftIndex >= rightIndex) return;
        
        var middlePoint = (leftIndex + rightIndex) / 2;

        var leftIndices = new [] { leftIndex, middlePoint + 1 };
        var rightIndices = new[] { middlePoint + 1, rightIndex };

        Parallel.For(0, 2, new ParallelOptions { MaxDegreeOfParallelism = _workersNumber }, index =>
        {
            if (rightIndices[index] - leftIndices[index] > 4000)
            {
                ParallelForMergeSort(array, leftIndices[index], rightIndices[index]);
            }
            else
            {
                SequentialMergeSorter.MergeSort(array, middlePoint + 1, rightIndex);
            }
        });

        SequentialMergeSorter.Merge(array, leftIndex, middlePoint, rightIndex);
    }
}