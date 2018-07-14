open System
open System.Net
open System.IO
open System.Diagnostics
open System.Text.RegularExpressions

let languageArgument =
    Environment.GetCommandLineArgs()
    |> Array.skipWhile (fun arg -> arg <> "--")
    |> Array.skip 1
    |> Array.tryHead

let downloadUrl (url: string) =
    let request = WebRequest.CreateHttp(url)
    use response = request.GetResponse()
    use responseStream = response.GetResponseStream()
    use responseStreamReader = new StreamReader(responseStream)
    responseStreamReader.ReadToEnd()

let exercises language = 
    let configJsonUrl = sprintf "https://raw.githubusercontent.com/exercism/%s/master/config.json" language
    let configJsonContents = downloadUrl configJsonUrl

    Regex.Matches(configJsonContents, "\"slug\": \"(.+)\"")
    |> Seq.cast<Match>
    |> Seq.map (fun x -> x.Groups.[1].Value)
    |> Seq.toList

let downloadExercise language exercise =
    let command = "exercism"
    let arguments = sprintf "download --exercise=%s --track=%s" exercise language
    let downloadProcess = Process.Start(command, arguments)
    downloadProcess.WaitForExit()

let downloadExercises language =
    exercises language
    |> List.iter (downloadExercise language)

match languageArgument with
| Some language -> downloadExercises language
| None -> failwith "No language specified"