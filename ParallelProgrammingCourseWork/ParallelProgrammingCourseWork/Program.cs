using ParallelProgrammingCourseWork.SorterBenchmark;

var initBenchmark = new InitBenchmark();
initBenchmark.Run();

var sorterBenchmark = new ParallelInvokeSorterBenchmark(3, 1000, 2, 4, 8);

sorterBenchmark.Run();

