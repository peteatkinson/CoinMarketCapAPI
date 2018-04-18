module Response

open System.Net
open System.Threading.Tasks
open System.Transactions
open Newtonsoft.Json

type CoinMarketCapResponseContent<'T> = 
    | Content of 'T
    | Error of string
    | Empty

type ResponseStatus = 
    | Completed
    | ErrorMessage of string
    | Timedout
    | Aborted
    | None

type CoinMarketCapResponse<'T> = {
     StatusCode : HttpStatusCode
     StatusDescription : string
     ResponseStatus : string
     ContentRaw : string
     Content : CoinMarketCapResponseContent<'T> 
}

let internal deserializeResponseContent (r : CoinMarketCapResponse<'T>) = 
    match r.StatusCode with 
     | HttpStatusCode.OK | HttpStatusCode.Created ->
            { r with Content = Content(JsonConvert.DeserializeObject<'T>(r.ContentRaw)) }
     | HttpStatusCode.Unauthorized ->
            { r with Content = Error(JsonConvert.DeserializeObject<string>(r.ContentRaw)) }
     | _ -> { r with ResponseStatus = ""  }

let internal serializeToJson body = 
   body |> JsonConvert.SerializeObject

let private convertResponse<'T> (rawContent : string) = 
    let response = { StatusCode = HttpStatusCode.OK 
                     StatusDescription = ""
                     ResponseStatus = ""
                     ContentRaw = rawContent
                     Content = CoinMarketCapResponseContent<'T>.Empty }
    response

[<RequiresExplicitTypeArguments>] 
let getDeserializedMarketCapResponse<'T> (rawContent : string) = 
    rawContent |> convertResponse<'T> |> deserializeResponseContent
   