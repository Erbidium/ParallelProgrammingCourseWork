﻿using ParallelProgrammingCourseWork.Abstractions;

namespace ParallelProgrammingCourseWork.Sorters;

public class ParallelTaskMergeSorter<T> : ParallelSorter<T> where T : IComparable<T>
{
    private readonly int _recursionDepth;

    public ParallelTaskMergeSorter(int workersNumber)
    : base(workersNumber)
    {
        _recursionDepth = (int)Math.Log2(workersNumber);
    }
    
    public override void Sort(T[] array)
    {
        ThreadPool.GetMinThreads(out _, out var IOMin);
        ThreadPool.SetMinThreads(WorkersNumber, IOMin);
        
        ThreadPool.GetMaxThreads(out _, out var IOMax);
        ThreadPool.SetMaxThreads(WorkersNumber, IOMax);

        ParallelTaskMergeSort(array, 0, array.Length - 1, 1).Wait();
    }
    
    private async Task ParallelTaskMergeSort(T[] array, int leftIndex, int rightIndex, int recursionDepth)
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
                SequentialMergeSorter<T>.MergeSort(array, leftIndex, middlePoint);
            }
        });
        
        if (recursionDepth < _recursionDepth)
        {
            await ParallelTaskMergeSort(array, middlePoint + 1, rightIndex, recursionDepth + 1);
        }
        else
        {
            SequentialMergeSorter<T>.MergeSort(array, middlePoint + 1, rightIndex);
        }

        await task;

        SequentialMergeSorter<T>.Merge(array, leftIndex, middlePoint, rightIndex);
    }
}