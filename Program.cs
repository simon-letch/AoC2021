//https://adventofcode.com/2021

var day1Input = File.ReadAllLines("./Inputs/Day1.txt");

int? previous = null;
var increments = 0;
foreach (var input in day1Input)
{
    if (previous == null)
    {
        previous = int.Parse(input);
        continue;
    }

    var current = int.Parse(input);
    if (current > previous)
        increments++;

    previous = current;
}

Console.WriteLine($"How many measurements are larger than the previous: {increments}");

var slidingWindow = new List<int>();
for (var i = 0; i < day1Input.Length; i++)
{
    var firstMeasurement = int.Parse(day1Input[i]);
    var secondMeasurement = (i + 1) < day1Input.Length ? int.Parse(day1Input[i + 1]) : 0;
    var thirdMeasurement = (i + 2) < day1Input.Length ? int.Parse(day1Input[i + 2]) : 0;
    slidingWindow.Add(firstMeasurement + secondMeasurement + thirdMeasurement);
}

previous = null;
increments = 0;

foreach (var input in slidingWindow)
{
    if (previous == null)
    {
        previous = input;
        continue;
    }

    if (input > previous)
        increments++;

    previous = input;
}

Console.WriteLine($"How many sliding window measurements are larger than the previous: {increments}");

Console.ReadLine();