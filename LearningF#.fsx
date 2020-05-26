// Split a string into words at spaces
let splitAtSpaces (text: string) = 
    text.Split ' '
    |> Array.toList

let wordCount text =
    let words = splitAtSpaces text
    let numWords = words.Length
    let distinctWords = List.distinct words
    let numDups = numWords - distinctWords.Length
    (numWords, numDups)

let showWordCount text =
    let numWords, numDups = wordCount text
    printfn "--> %d words in the text" numWords
    printfn "--> %d duplicate words" numDups

/// Using explicit 'in' tokens, which are not necessary as
/// indentation rules intuitively do the same thing. The 
/// 'in's makes explicit the scope of the declared values
let wordCount2 text = 
    let words = splitAtSpaces text in
    let distinctWords = List.distinct words in
    let numWords = words.Length in
    let numDups = numWords - distinctWords.Length in
    (numWords, numDups)

wordCount2 "hello world"

/// Within function definitions you can 'outscope' by
/// declaring on the same name
let pow4plus2 n =
    let n = n * n
    let n = n * n
    let n = n + 2
    n

// now with function piping
let pow4plus3 n =
    n
    |> fun n -> n * n
    |> fun n -> n * n
    |> fun n -> n + 3

// Study Excercise:
// How could a list of results from pow4plus2 be subtracted
// from a list from pow4plus3
let result numbers = 
    let p3 = List.map pow4plus3 numbers
    let p2 = List.map pow4plus2 numbers
    // here need to subtract the lists
    p3,p2


