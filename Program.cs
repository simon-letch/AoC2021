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

var horizontal = 0;
var depth = 0;

var day2Input = File.ReadAllLines("./Inputs/Day2.txt");
foreach (var input in day2Input)
{
    var splitInput = input.Split(' ');
    var movement = splitInput[0];
    var value = int.Parse(splitInput[1]);
    if (movement == "down")
        depth += value;
    else if (movement == "up")
        depth -= value;
    else
        horizontal += value;
}

var result = horizontal * depth;
Console.WriteLine($"Horizontal position x depth = {result}");

horizontal = 0;
depth = 0;
var aim = 0;

foreach (var input in day2Input)
{
    var splitInput = input.Split(' ');
    var movement = splitInput[0];
    var value = int.Parse(splitInput[1]);
    if (movement == "down")
        aim += value;
    else if (movement == "up")
        aim -= value;
    else
    {
        horizontal += value;
        if (aim != 0)
            depth += value * aim;
    }
}

result = horizontal * depth;
Console.WriteLine($"Horizontal position x depth (with aim) = {result}");

Console.ReadLine();