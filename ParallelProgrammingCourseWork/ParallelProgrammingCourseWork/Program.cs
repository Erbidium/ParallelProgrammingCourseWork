﻿using System.Diagnostics;
using ParallelProgrammingCourseWork;

int[] array = ArrayGenerator.GenerateRandomArray(100000);

//Console.WriteLine("Initial array");
//ArrayPrinter.PrintArray(array);

var startTime = Stopwatch.GetTimestamp();

//var sorter = new SequentialMergeSorter();
//var sorter = new ParallelForMergeSorter();
var sorter = new ParallelTaskMergeSorter();
sorter.Sort(array);

var endTime = Stopwatch.GetElapsedTime(startTime);
Console.WriteLine(endTime.TotalSeconds);

//Console.WriteLine("Sorted array");
//ArrayPrinter.PrintArray(array);