namespace ParallelProgrammingCourseWork;

public class ParallelInvokeMergeSorter : ISorter
{
    private int _workersNumber;
    
    public ParallelInvokeMergeSorter(int workersNumber)
    {
        _workersNumber = workersNumber;
    }
    
    public void Sort(int[] array)
    {
        ParallelForMergeSort(array, 0, array.Length - 1).Wait();
    }
    
    private async Task ParallelForMergeSort(int[] array, int leftIndex, int rightIndex)
    {
        if (leftIndex >= rightIndex) return;
        
        var middlePoint = (leftIndex + rightIndex) / 2;

        var action1 = () =>
        {
            if (middlePoint - leftIndex > 4000)
            {
                ParallelForMergeSort(array, leftIndex, middlePoint);
            }
            else
            {
                SequentialMergeSorter.MergeSort(array, leftIndex, middlePoint);
            }
        };

        var action2 = () =>
        {
            if (rightIndex - middlePoint - 1 > 4000)
            {
                ParallelForMergeSort(array, middlePoint + 1, rightIndex);
            }
            else
            {
                SequentialMergeSorter.MergeSort(array, middlePoint + 1, rightIndex);
            }
        };
        
        var task = Task.Run(() => Parallel.Invoke
        (
            new ParallelOptions { MaxDegreeOfParallelism = _workersNumber},
            action1,
            action2
        ));

        await task;
        
        SequentialMergeSorter.Merge(array, leftIndex, middlePoint, rightIndex);
    }
}