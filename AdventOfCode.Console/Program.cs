using AdventOfCode.Console.Infra;
using Spectre.Console;

var problems = ProblemsLocator.GetAllProblems();
var problemsMap = problems.ToDictionary(x => x.Day, x => x.Create);
var day = AnsiConsole.Prompt(
    new SelectionPrompt<byte>()
        .Title("Select problem day")
        .AddChoices(problemsMap.Keys.OrderDescending()));
var testRun = AnsiConsole.Prompt(
    new SelectionPrompt<bool>()
        .Title("Do you want a test run?")
        .AddChoices(false, true));

var problem = problemsMap[day]();
var input = InputHelper.GetInputLines(day, testRun).ToArray();

var part1Result = problem.SolvePart1(input);
var part2Result = problem.SolvePart2(input);
AnsiConsole.WriteLine($"Day {day} Part 1 Result: [{part1Result}], Part 2 Result: [{part2Result}]");