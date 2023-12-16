module AdventOfCode.Runner.InputHelper

open System.IO

let getInput day part testRun =
    let testSuffix = if testRun then ".test" else ""
    let inputLocation = $"./Inputs/d{day}p{part}{testSuffix}.txt"
    if File.Exists inputLocation then
        File.ReadLines inputLocation
    else
        File.ReadLines $"./Inputs/d{day}{testSuffix}.txt"