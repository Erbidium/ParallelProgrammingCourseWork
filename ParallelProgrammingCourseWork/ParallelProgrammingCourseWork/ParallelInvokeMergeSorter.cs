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
        ParallelForMergeSort(array, 0, array.Length - 1);
    }
    
    private void ParallelForMergeSort(int[] array, int leftIndex, int rightIndex)
    {
        if (leftIndex >= rightIndex) return;
        
        var middlePoint = (leftIndex + rightIndex) / 2;

        void Action1()
        {
            if (middlePoint - leftIndex > 4000)
            {
                ParallelForMergeSort(array, leftIndex, middlePoint);
            }
            else
            {
                SequentialMergeSorter.MergeSort(array, leftIndex, middlePoint);
            }
        }

        void Action2()
        {
            if (rightIndex - middlePoint - 1 > 4000)
            {
                ParallelForMergeSort(array, middlePoint + 1, rightIndex);
            }
            else
            {
                SequentialMergeSorter.MergeSort(array, middlePoint + 1, rightIndex);
            }
        }

        Parallel.Invoke
        (
            new ParallelOptions { MaxDegreeOfParallelism = _workersNumber },
            Action1,
            Action2
        );

        SequentialMergeSorter.Merge(array, leftIndex, middlePoint, rightIndex);
    }
}