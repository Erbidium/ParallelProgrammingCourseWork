namespace ParallelProgrammingCourseWork;

public class ParallelTaskMergeSorter : ISorter
{
    private int _workersNumber;

    public ParallelTaskMergeSorter(int workersNumber)
    {
        _workersNumber = workersNumber;
    }
    
    public void Sort(int[] array)
    {
        ThreadPool.SetMinThreads(_workersNumber, 0);
        ThreadPool.SetMaxThreads(_workersNumber, 0);
        
        ParallelTaskMergeSort(array, 0, array.Length - 1);
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
                SequentialMergeSorter.MergeSort(array, leftIndex, middlePoint);
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
                SequentialMergeSorter.MergeSort(array, middlePoint + 1, rightIndex);
            }
            
        });

        Task.WaitAll(task1, task2);

        SequentialMergeSorter.Merge(array, leftIndex, middlePoint, rightIndex);
    }
}