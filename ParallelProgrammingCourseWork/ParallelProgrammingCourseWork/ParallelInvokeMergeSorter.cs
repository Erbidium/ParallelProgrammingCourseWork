namespace ParallelProgrammingCourseWork;

public class ParallelInvokeMergeSorter : ISorter
{
    private int _workersNumber;
    
    private int _recursionDepth;
    
    public ParallelInvokeMergeSorter(int workersNumber)
    {
        _workersNumber = workersNumber;
        int left = workersNumber;
        while (left > 1)
        {
            left /= 2;
            _recursionDepth++;
        }
    }
    
    public void Sort(int[] array)
    {
        ParallelForMergeSort(array, 0, array.Length - 1, 1);
    }
    
    private void ParallelForMergeSort(int[] array, int leftIndex, int rightIndex, int recursionDepth)
    {
        if (leftIndex >= rightIndex) return;
        
        var middlePoint = (leftIndex + rightIndex) / 2;

        void Action1()
        {
            if (recursionDepth < _recursionDepth)
            {
                ParallelForMergeSort(array, leftIndex, middlePoint, recursionDepth + 1);
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
                ParallelForMergeSort(array, middlePoint + 1, rightIndex, recursionDepth + 1);
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