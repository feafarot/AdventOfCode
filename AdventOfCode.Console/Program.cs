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

var inputP1 = InputHelper.GetInputLines(day, 1, testRun);
var part1Result = problem.SolvePart1(inputP1);

var inputP2 = InputHelper.GetInputLines(day, 2, testRun);
var part2Result = problem.SolvePart2(inputP2);

AnsiConsole.WriteLine($"Day {day} Part 1 Result: [{part1Result}], Part 2 Result: [{part2Result}]");