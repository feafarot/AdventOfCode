using System.Text.RegularExpressions;
using AdventOfCode.Console.Infra;
using Spectre.Console;

namespace AdventOfCode.Console.Days;

[DayNumber(2)]
public class Day2Problem : IProblem
{
    public string SolvePart1(IEnumerable<string> input)
    {
        var maxColors = new Dictionary<string, int>() { { "red", 12 }, { "green", 13 }, { "blue", 14 } };
        var res = input.Sum(
            line =>
            {
                var rootParts = line.Split(":");
                var gameId = int.Parse(rootParts[0].AsSpan()[5..]);
                var possibleGame = rootParts[1].Split(";").All(
                    turn =>
                    {
                        var reveals = turn.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        for (var i = 0; i < reveals.Length; i+=2)
                        {
                            var amount = int.Parse(reveals[i]);
                            var color = reveals[i + 1];
                            if (maxColors[color] < amount)
                            {
                                return false;
                            }
                        }

                        return true;
                    });
                return possibleGame ? gameId : 0;
            });
        return res.ToString();
    }
    
    // public string SolvePart1_Perf(IEnumerable<string> input)
    // {
    //     var maxColors = new Dictionary<string, int>() { { "red", 12 }, { "green", 13 }, { "blue", 14 } };
    //     var res = input.Sum(
    //         line =>
    //         {
    //             var lineSpan = line.AsSpan();
    //             var idEnd = lineSpan.IndexOf(':');
    //             var gameId = int.Parse(lineSpan[5..idEnd]);
    //             lineSpan = lineSpan[(idEnd + 1)..];
    //             var turnsSpans = new Span<Range>();
    //             _ = lineSpan.Split(turnsSpans, ";");
    //             Span<Range> revealsSpans = stackalloc Range[6];
    //             foreach (var turn in turnsSpans)
    //             {
    //                 var turnSpan = lineSpan[turn.Start..(turn.End.Value + 1)];
    //                 var reveals = turnSpan.SplitAny(revealsSpans, ", ", StringSplitOptions.RemoveEmptyEntries);
    //                 for (var i = 0; i < reveals; i += 2)
    //                 {
    //                     var ar = revealsSpans[i];
    //                     var cr = revealsSpans[i + 1];
    //                     var amount = int.Parse(turnSpan[ar]);
    //                     if ((turnSpan[cr] is "red" && amount > maxRed)
    //                         || (turnSpan[cr] is "blue" && amount > maxBlue)
    //                         || (turnSpan[cr] is "green" && amount > maxGreen))
    //                     {
    //                         return 0;
    //                     }
    //                 }
    //             }
    //             
    //             return gameId;
    //         });
    //     return res.ToString();
    // }

    public string SolvePart2(IEnumerable<string> input)
    {
        var res = input.Sum(
            line =>
            {
                var rootParts = line.Split(":");
                int maxGreen = 1, maxBlue = 1, maxRed = 1;
                foreach (var turn in rootParts[1].Split(";"))
                {
                    
                    var reveals = turn.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    for (var i = 0; i < reveals.Length; i += 2)
                    {
                        var amount = int.Parse(reveals[i]);
                        var color = reveals[i + 1];
                        switch (color)
                        {
                            case "green" when amount > maxGreen:
                                maxGreen = amount;
                                break;
                            case "blue" when amount > maxBlue:
                                maxBlue = amount;
                                break;
                            case "red" when amount > maxRed:
                                maxRed = amount;
                                break;
                        } 
                    }
                }

                var gamePower = maxGreen * maxBlue * maxRed;
                return gamePower;
            });
        return res.ToString();
    }
}