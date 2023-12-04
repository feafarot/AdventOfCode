using AdventOfCode.Console.Infra;

namespace AdventOfCode.Console.Days;

[DayNumber(1)]
public class Day1Problem : IProblem
{
    public string SolvePart1(IEnumerable<string> input)
    {
        var resultPart1 = input.Sum(
            line =>
            {
                var span = line.AsSpan();
                var first = (Value: default(char), Found: false);
                var last = (Value: default(char), Found: false);
                for (var i = 0; i <= span.Length / 2; i++)
                {
                    var head = span[i];
                    if (char.IsDigit(head))
                    {
                        if (!first.Found)
                        {
                            first = (head, true);
                        }
                        
                        if (!last.Found)
                        {
                            last = (head, false);
                        }
                    }

                    var tail = span[span.Length - i - 1];
                    if (!char.IsDigit(tail))
                    {
                        continue;
                    }
                    if (!last.Found)
                    {
                        last = (tail, true);
                    }
                    if (!first.Found)
                    {
                        first = (tail, false);
                    }
                }

                return int.Parse($"{first.Value}{last.Value}");
            });
        return resultPart1.ToString();
    }

    public string SolvePart2(IEnumerable<string> input)
    {
        const int maxWordLength = 5;
        var words = new Dictionary<string, int>()
        {
            { "one", 1 }, {"two", 2}, {"three", 3}, { "four", 4 }, { "five", 5 }, { "six", 6 }, { "seven", 7 }, { "eight", 8 }, { "nine", 9 }
        };
        
        var resultPart2 = input.Sum(
            line =>
            {
                var span = line.AsSpan();
                int? first = null;
                int? last = null;
                for (var i = 0; i < span.Length; i++)
                {
                    var c = span[i];
                    int? d = null;
                    if (char.IsDigit(c))
                    {
                        d = int.Parse(c.ToString());
                    }
                    else
                    {
                        for (var j = 1; j + i <= span.Length && j <= maxWordLength; j++)
                        {
                            if (words.TryGetValue(span.Slice(i, j).ToString(), out var wn))
                            {
                                d = wn;
                            }
                        }
                    }

                    if (d.HasValue)
                    {
                        if (first.HasValue)
                        {
                            last = d;
                        }
                        else
                        {
                            first = d;
                            last = d;
                        }
                    }
                }

                return int.Parse($"{first ?? last}{last ?? first}");
            });
        
        return resultPart2.ToString();
    }
}