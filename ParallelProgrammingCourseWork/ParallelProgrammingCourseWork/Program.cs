using ParallelProgrammingCourseWork.SorterBenchmark;
using ParallelProgrammingCourseWork.SorterBenchmark.Abstractions;

SorterBenchmark sorterBenchmark = new ParallelInvokeSorterBenchmark(3, 1000, 2, 4, 8);
sorterBenchmark.Run();
sorterBenchmark.Run();

