using ParallelProgrammingCourseWork;

int[] array = { 9, 8, 5, 1, 2, 3, 1 ,56, 8, 90 };

Console.WriteLine("Initial array");
ArrayPrinter.PrintArray(array);


var sorter = new SequentialMergeSorter();
sorter.Sort(array);

Console.WriteLine("Sorted array");
ArrayPrinter.PrintArray(array);