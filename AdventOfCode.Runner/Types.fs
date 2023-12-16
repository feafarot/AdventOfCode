module AdventOfCode.Runner.Types

open System

type IProblem =
    abstract SolvePart1: input: string seq -> string
    abstract SolvePart2: input: string seq -> string

[<AttributeUsage(AttributeTargets.Class, AllowMultiple = false)>]
type DayNumberAttribute(day: int) =
    inherit Attribute()
    member this.Day = day