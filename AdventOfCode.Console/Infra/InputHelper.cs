namespace AdventOfCode.Console.Infra;

public static class InputHelper
{
    public static IEnumerable<string> GetInputLines(byte day, byte part, bool testInput = false)
    {
        var path = $"./Inputs/d{day}p{part}{(testInput ? ".test" : "")}.txt";
        if (!File.Exists(path))
        {
            path = $"./Inputs/d{day}{(testInput ? ".test" : "")}.txt";
        }
        
        return File.ReadLines(path);
    }
}