module ApiClient

open FSharp.Data
open Microsoft.FSharp.Control.WebExtensions

open Models

let getCoinsAsync (limit : int) (currency : CoinCurrency) =
    let route = (sprintf "https://api.coinmarketcap.com/v1/ticker/?limit=%s&convert=%s" (limit.ToString()) (currency.ToString()))
    async {
        let! raw = route |> Http.AsyncRequestString
        return raw |> Response.getDeserializedMarketCapResponse<Coin array>
    } 
   
let getCoins (limit : int) (currency : CoinCurrency) = 
    let route = (sprintf "https://api.coinmarketcap.com/v1/ticker/?limit=%s&convert=%s" (limit.ToString()) (currency.ToString()))
    let raw = route |> Http.RequestString
    let response = raw |> Response.getDeserializedMarketCapResponse<Coin array> 
    response

let getCoinAsync (limit : int) (currency : CoinCurrency) = 
     let route = (sprintf "https://api.coinmarketcap.com/v1/ticker/?limit=%s&convert=%s" (limit.ToString()) (currency.ToString()))
     async {
        let! raw = route |> Http.AsyncRequestString
        let response = raw |> Response.getDeserializedMarketCapResponse<Coin array>
        return response
     }
     
let getCoin (limit : int) (currency : CoinCurrency) = 
    let route = (sprintf "https://api.coinmarketcap.com/v1/ticker/?limit=%s&convert=%s" (limit.ToString()) (currency.ToString()))
    let response = route |> Http.RequestString
    response

let getGlobalDataAsync (currency : CoinCurrency) = 
    let route = (sprintf "https://api.coinmarketcap.com/v1/global/?%s" (currency.ToString()))
    async {
        let! response = route |> Http.AsyncRequestString
        return response
    }
    
let getGlobalData (currency : CoinCurrency) = 
    let route = (sprintf "https://api.coinmarketcap.com/v1/global/?%s" (currency.ToString()))
    let response = route |> Http.RequestString
    response