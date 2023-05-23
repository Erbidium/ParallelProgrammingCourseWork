using ParallelProgrammingCourseWork.Abstractions;

namespace ParallelProgrammingCourseWork.Sorters;

public class ParallelInvokeMergeSorter<T> : ParallelSorter<T> where T : IComparable<T>
{
    private int _recursionDepth;
    
    public ParallelInvokeMergeSorter(int workersNumber) 
        : base(workersNumber)
    {
        _recursionDepth = (int)Math.Log2(workersNumber);
    }
    
    public override void Sort(T[] array)
    {
        ParallelInvokeMergeSort(array, 0, array.Length - 1, 1);
    }
    
    private void ParallelInvokeMergeSort(T[] array, int leftIndex, int rightIndex, int recursionDepth)
    {
        if (leftIndex >= rightIndex) return;
        
        var middlePoint = (leftIndex + rightIndex) / 2;

        void Action1()
        {
            if (recursionDepth < _recursionDepth)
            {
                ParallelInvokeMergeSort(array, leftIndex, middlePoint, recursionDepth + 1);
            }
            else
            {
                SequentialMergeSorter<T>.MergeSort(array, leftIndex, middlePoint);
            }
        }

        void Action2()
        {
            if (rightIndex - middlePoint - 1 > 4000)
            {
                ParallelInvokeMergeSort(array, middlePoint + 1, rightIndex, recursionDepth + 1);
            }
            else
            {
                SequentialMergeSorter<T>.MergeSort(array, middlePoint + 1, rightIndex);
            }
        }

        Parallel.Invoke
        (
            new ParallelOptions { MaxDegreeOfParallelism = WorkersNumber },
            Action1,
            Action2
        );

        SequentialMergeSorter<T>.Merge(array, leftIndex, middlePoint, rightIndex);
    }
}