// See https://aka.ms/new-console-template for more information
using ConsoleApp;

Console.WriteLine("Hello, World!");

int[] nums = [2, 7, 11, 15];
int target = 266;
int[]? re = TwoSum.FindTwoSum(nums,target);
if (re == null)
    Console.WriteLine("Resultado nulo");
else
    Console.WriteLine($"Resultado: {string.Join(',',re)}");