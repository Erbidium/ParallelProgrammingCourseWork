using ParallelProgrammingCourseWork.ArrayGenerators;
using ParallelProgrammingCourseWork.SorterBenchmark;
using ParallelProgrammingCourseWork.Sorters;

var sequentialMergeSorterBenchmark = new SequentialSorterBenchmark<int>(3, 50_000, new IntegerArrayGenerator());
sequentialMergeSorterBenchmark.Run();


var parallelInvokeSorterBenchmark = new ParallelSorterBenchmark<ParallelInvokeMergeSorter<int>, int>
(3, 50_000,  new IntegerArrayGenerator(), 2, 4, 8);

parallelInvokeSorterBenchmark.Run();

var parallelTaskSorterBenchmark = new ParallelSorterBenchmark<ParallelTaskMergeSorter<int>, int>
(3, 50_000, new IntegerArrayGenerator(), 2, 4, 8);

parallelTaskSorterBenchmark.Run();

