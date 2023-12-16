open AdventOfCode.Runner
open AdventOfCode.Runner.ProblemsFinder
open SpectreCoff

let typesMap = getProblemTypes()
let days = typesMap |> Map.keys |> Seq.map (_.ToString()) |> Seq.toList

let day = Prompt.chooseFrom days "Select problem day"
let testRun =
    match Prompt.chooseFrom ["Yes"; "No"] "Do you want to run test input" with
    | "Yes" -> true
    | "No" | _ -> false
    
let problem = typesMap[day]()

let inputP1 = InputHelper.getInput day 1 testRun
let resultP1 = problem.SolvePart1 inputP1

let inputP2 = InputHelper.getInput day 2 testRun
let resultP2 = problem.SolvePart2 inputP2

printfn $"Day {day} Part 1 Result: [{resultP1}], Part 2 Result: [{resultP2}]"