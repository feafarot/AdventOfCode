namespace AdventOfCode.Console.Infra;

public static class Extensions
{
    public static bool Any<T>(this Span<T> span, Func<T, bool> predicate)
    {
        foreach (var t in span)
        {
            if (!predicate(t))
            {
                return false;
            }
        }

        return true;
    }
}