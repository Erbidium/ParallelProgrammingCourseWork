using ParallelProgrammingCourseWork.SorterBenchmark;
using ParallelProgrammingCourseWork.Sorters;

//var sequentialMergeSorterBenchmark = new SequentialSorterBenchmark(3, 10000);
//sequentialMergeSorterBenchmark.Run();


var parallelInvokeSorterBenchmark = new ParallelSorterBenchmark<ParallelInvokeMergeSorter>(3, 1000000, 2, 4, 8);
parallelInvokeSorterBenchmark.Run();

var parallelTaskSorterBenchmark = new ParallelSorterBenchmark<ParallelTaskMergeSorter>(3, 1000000, 2, 4, 8);
parallelTaskSorterBenchmark.Run();

