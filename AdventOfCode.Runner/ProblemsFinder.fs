module AdventOfCode.Runner.ProblemsFinder

open System
open System.Reflection
open AdventOfCode.Runner.Types

let getProblemTypes() =
    Assembly.GetExecutingAssembly().GetTypes()
    |> Array.filter (fun t -> t.IsAssignableTo(typeof<IProblem>)
                              && t.GetCustomAttributes(typeof<DayNumberAttribute>, false).Length > 0)
    |> Array.map (fun x -> (x.GetCustomAttribute<DayNumberAttribute>().Day.ToString(), fun () -> Activator.CreateInstance(x) :?> IProblem))
    |> Map.ofArray