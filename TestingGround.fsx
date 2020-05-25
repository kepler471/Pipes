/// Testing ground for learning F#


let intList = [1;2;3;4;5;6;7]

let squareIt (n: int) = n * n

let squareAll = List.map squareIt intList

let x = [for i in 1..10 -> [for j in 1..10 -> (i,j)]]


