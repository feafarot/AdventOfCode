namespace AdventOfCode.Console.Infra;

public static class InputHelper
{
    public static IEnumerable<string> GetInputLines(byte day, bool testInput = false)
    {
        return File.ReadLines($"./Inputs/d{day}{(testInput ? ".test" : "")}.txt");
    }
}