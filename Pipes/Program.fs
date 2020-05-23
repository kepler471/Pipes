// Learn more about F# at https://fsharp.org
// See the 'F# Tutorial' project for more help.

let square x = x * x

let addOne x = x + 1

let isOdd x = x % 2 <> 0

let testProcess values = 
    values
    |> List.filter isOdd
    |> List.map square
    |> List.map addOne


[<EntryPoint>]
let main argv =
    printfn "%A" argv
    0 // return an integer exit code


