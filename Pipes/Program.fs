// Learn more about F# at https://fsharp.org
// See the 'F# Tutorial' project for more help.

/// Initisalising random number generator
let rand = System.Random()
let randn = rand.Next()

let dimX = 10
let dimY = 10
let walkLength = 10

let startingPosition = [ rand.Next(1,dimX); rand.Next(1,dimY) ]

/// Randomly choose the change in direction in a given axis
let stepDirection position = position + rand.Next(-1,2)

/// Takes stepDirection function for single arg random step
/// and maps the function for each item in the value position.
/// This should work for integer, and list.
let stepNDims (position: 'T list) = List.map stepDirection position

/// Randomly choose the length of step
let stepLength = rand.Next(1,2)

/// Choose a random direction
// This could take 2 directions for each dim in position vector
// Could also use List.filter to drop occupied position from the options 
let chooseDir position = 
    let randMove = rand.Next(1,5)
    match randMove with
        | 1 -> "a"
        | 2 -> "b"
        | 3 -> "c"
        | 4 -> "d"
        |_ -> position

// Try with vector type?
type Vector3 = struct
    val X : float
    val Y : float
    val Z : float

    new (x,y,z) = { X = x; Y = y; Z = z }

    override v.ToString() = sprintf "[%f, %f, %f]" v.X v.Y v.Z
end

/// The following could be used to create vectors:
///     List.zip, List.iter

//open MathNet
//let vec = MathNet.Spatial.Euclidean.

/// Infinite sequence random walk
let rec endlessWalk x = 
    seq { yield x
          yield! endlessWalk (x + rand.NextDouble() - 0.5) }

/// Infinite sequence random walk, piped
let rec endlessWalkPipe x = 
    seq { yield x
          yield! 
            x + rand.NextDouble() - 0.5
            |> endlessWalkPipe }


/// Infinite sequence random walk in 2-dims
let rec endlessWalkInt [x;y] = 
    seq { yield [x;y]
          yield! endlessWalkInt [x+1;y+1] }


// The function above is very specific to a pair/list input
/// Take a generic function to operate on the next step of each recursion
let rec endlessWalkIntGen x = 
    seq { yield x
          yield! 
            x 
            |> step 
            |> endlessWalkIntGen }  


let X = [ 1 .. dimX ]
let Y = [ 1 .. dimY ]

/// Space by nested sequences
let SpaceNestedSeq = [ for x in 1 .. dimX 
    -> [for y in 1 .. dimY 
    -> [x,y]]]

// Space as a list or all coordinates


// Space by nested arrays ( [ [x1;x2;x3] ; [x1;x2;x3] ; .... )

// Space by multiplicative mapping
//let SpaceMulMap = 
//    X
//    |> List.map X*X



[<EntryPoint>]
let main argv =
    //printfn "%A" startingPosition
    printfn "%A" (stepDirection 5)
    // testing anonymouse functions on lists
    //printfn "%A" ( [1;2;3] |> List.map (fun x -> x + rand.Next(-1,1)) )
    //printfn "%A" ( [1..10] |> List.map (fun x -> [1..10]) )
    //printfn "%A" SpaceNestedSeq
    //printfn "%A" (chooseDir "Z")
    printfn "%A" (endlessWalk 5.)
    printfn "%A" (endlessWalkPipe 5.)
    printfn "%A" (endlessWalkInt [1;7])
    0 // return an integer exit code