// Learn more about F# at https://fsharp.org
// See the 'F# Tutorial' project for more help.

/// Initisalising random number generator
let rand = System.Random()
let randn = rand.Next()

let dimX = 100
let dimY = dimX

let startingPosition = [ rand.Next(1,100), rand.Next(1,100) ]

let stepDirection position = position + rand.Next(0,1)

let stepLength = 0

// Infinite sequence random walk
let rec endlessWalk x = 
    seq { yield x
          yield! endlessWalk (x + rand.NextDouble() - 0.5) }

let X = [| 1 .. dimX |]
let Y = [| 1 .. dimX |]


[<EntryPoint>]
let main argv =
    printfn "%A" startingPosition
    printfn "%A" (stepDirection 5)
    // testing anonymouse functions on lists
    printfn "%A" ( [1;2;3] |> List.map (fun x -> x + rand.Next(-1,1)))
    0 // return an integer exit code