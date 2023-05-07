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
        ThreadPool.GetMinThreads(out _, out var IOMin);
        ThreadPool.SetMinThreads(_workersNumber, IOMin);
        
        ThreadPool.GetMaxThreads(out _, out var IOMax);
        ThreadPool.SetMaxThreads(_workersNumber, IOMax);

        ParallelTaskMergeSort(array, 0, array.Length - 1).Wait();
    }
    
    private static async Task ParallelTaskMergeSort(int[] array, int leftIndex, int rightIndex)
    {
        if (leftIndex >= rightIndex) return;
        
        var middlePoint = (leftIndex + rightIndex) / 2;
            
        var task = Task.Run(async () =>
        {
            if (middlePoint - leftIndex > 4000)
            {
                await ParallelTaskMergeSort(array, leftIndex, middlePoint);
            }
            else
            {
                SequentialMergeSorter.MergeSort(array, leftIndex, middlePoint);
            }
        });
        
        if (rightIndex - middlePoint - 1 > 4000)
        {
            await ParallelTaskMergeSort(array, middlePoint + 1, rightIndex);
        }
        else
        {
            SequentialMergeSorter.MergeSort(array, middlePoint + 1, rightIndex);
        }

        await task;

        SequentialMergeSorter.Merge(array, leftIndex, middlePoint, rightIndex);
    }
}