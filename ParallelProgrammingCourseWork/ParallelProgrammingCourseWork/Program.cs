using ParallelProgrammingCourseWork;

int[] array = ArrayGenerator.GenerateRandomArray(100);

Console.WriteLine("Initial array");
ArrayPrinter.PrintArray(array);


var sorter = new SequentialMergeSorter();
sorter.Sort(array);

Console.WriteLine("Sorted array");
ArrayPrinter.PrintArray(array);