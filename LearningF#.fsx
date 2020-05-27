/// Learning from 'Expert F#'
/// Most of these are code snippets from the book

/// Imports and module loadings
#r "packages/FSharp.Data.3.3.3/lib/net45/FSharp.Data.dll"

open System.IO
open System.Net
open FSharp.Data

/// An overview of F#
module chapter2 = 
    /// Split a string into words at spaces
    let splitAtSpaces (text: string) = 
        text.Split ' '
        |> Array.toList

    /// Split a string into list by given text delimeter
    let splitBy (text: string) (delim: string) = 
        delim.ToCharArray()
        |> text.Split
        |> Array.toList

    let tester (a:string, b:string) = a + b
    splitBy "aas ,  a., asd\nas,sd" "\n"

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

    /// last bookmark -> p15
    let test (x: float) = 43

    let two = (printfn "Hello World"; 1 + 1)
    let four = two + two

    /// Get the html contents of the URL via a web request
    let http (url: string) =
        let req = WebRequest.Create(url)
        let resp = req.GetResponse()
        let stream = resp.GetResponseStream()
        let reader = new StreamReader(stream)
        let html = reader.ReadToEnd()
        resp.Close()
        html


    type Species = HtmlProvider<"http://en.wikipedia.org/wiki/The_world's_100_most_threatened_species">

    let species = 
        [ for x in Species.GetSample().Tables.``Species list``.Rows ->
              x.Type, x.``Common name``]

    let speciesSorted = 
        species
        |> List.countBy fst
        |> List.sortByDescending snd

/// Introduction to functional programming
module chapter3 = 
    let unaryNegation = -(5.4+2.0)
    let modulusFloat = 5.4 % 2.1

    let mathTest a b  = a + a * b
    mathTest 2. 3.

    /// convert types
    int 17.8
    string 65
    double 4

    /// slicing strings
    let s = "big ol stringy boy"
    s.[4..19]

    /// booleans and conditionals
    let round2 (x, y) =
        if x >= 100 || y >= 100 then 100, 100
        elif x < 0 || y < 0 then 0, 0
        else x, y

    /// Recursive functions
    let rec factorial (n: bigint) = if n <= bigint 1 then bigint 1 else n * factorial (n - bigint 1)
    bigint 420 |> factorial

    /// List.length as a recusrive function (Slack answer

    let rec length l = 
        match l with
        | [] -> 0
        | h :: t -> 1 + length t

    /// i think referes to the binary value, please check
    let rec even n = (n = 0u) || odd(n - 1u)
    and odd n = (n <> 0u) && even(n - 1u)

    let even2 n = (n % 2u) = 0u

    /// Deconstruncting records
    /// https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/pattern-matching#identifier-patterns
    /// https://fsharpforfunandprofit.com/posts/records/#making-and-matching-records
    /// Create a type
    type Complex = { real: float; imag: float }
    /// Create an example of that type
    let cNum1 = {real = 1.0; imag = 2.0}
    /// Deconstruct the example and assign to values 
    let {real = newReal; imag = newImag } = cNum1

    