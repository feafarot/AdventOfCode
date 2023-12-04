namespace AdventOfCode.Console.Infra;

public interface IProblem
{
    string SolvePart1(IEnumerable<string> input);
    string SolvePart2(IEnumerable<string> input);
}

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
internal sealed class DayNumberAttribute(byte day) : Attribute
{
    public byte Day { get; set; } = day;
}