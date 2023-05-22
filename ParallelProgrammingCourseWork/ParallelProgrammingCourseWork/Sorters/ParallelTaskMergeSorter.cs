using ParallelProgrammingCourseWork.Abstractions;

namespace ParallelProgrammingCourseWork.Sorters;

public class ParallelTaskMergeSorter : ParallelSorter
{
    private readonly int _recursionDepth;

    public ParallelTaskMergeSorter(int workersNumber)
    : base(workersNumber)
    {
        int left = workersNumber;
        while (left > 1)
        {
            left /= 2;
            _recursionDepth++;
        }
    }
    
    public override void Sort(int[] array)
    {
        ThreadPool.GetMinThreads(out _, out var IOMin);
        ThreadPool.SetMinThreads(WorkersNumber, IOMin);
        
        ThreadPool.GetMaxThreads(out _, out var IOMax);
        ThreadPool.SetMaxThreads(WorkersNumber, IOMax);

        ParallelTaskMergeSort(array, 0, array.Length - 1, 1).Wait();
    }
    
    private async Task ParallelTaskMergeSort(int[] array, int leftIndex, int rightIndex, int recursionDepth)
    {
        if (leftIndex >= rightIndex) return;
        
        var middlePoint = (leftIndex + rightIndex) / 2;
            
        var task = Task.Run(async () =>
        {
            if (recursionDepth < _recursionDepth)
            {
                await ParallelTaskMergeSort(array, leftIndex, middlePoint, recursionDepth + 1);
            }
            else
            {
                SequentialMergeSorter.MergeSort(array, leftIndex, middlePoint);
            }
        });
        
        if (recursionDepth < _recursionDepth)
        {
            await ParallelTaskMergeSort(array, middlePoint + 1, rightIndex, recursionDepth + 1);
        }
        else
        {
            SequentialMergeSorter.MergeSort(array, middlePoint + 1, rightIndex);
        }

        await task;

        SequentialMergeSorter.Merge(array, leftIndex, middlePoint, rightIndex);
    }
}