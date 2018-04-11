module FSharpRecords

type Nested = {
    A: string
    B: string
}

type Container = {
    Key: string
    Nested1: Nested
    Nested2: Nested
}

let records = [|
    { 
        Key = "key1"
        Nested1 = { A = "n1a"; B = "n1b" }
        Nested2 = { A = "n2a"; B = "n2b" }
    }
|]
