module Models 

open Newtonsoft.Json

type Coin = {
    Id : string
    Name : string
    Symbol : string
    Rank : int

    [<field: JsonProperty(PropertyName="price_btc", Required=Required.AllowNull)>]
    PriceInBtc : double

    [<field: JsonProperty(PropertyName="percent_change_1h", Required=Required.AllowNull)>]
    HourlyChange : double

    [<field: JsonProperty(PropertyName="percent_change_24h", Required=Required.AllowNull)>]
    DailyChange : double

    [<field: JsonProperty(PropertyName="percent_change_7d", Required=Required.AllowNull)>]
    WeeklyChange : double

    [<field: JsonProperty(PropertyName="last_updated")>]
    LastUpdatedUnixTime : double
}

type GlobalData = {
    [<JsonProperty(PropertyName="total_market_cap_usd")>]
    MarketCapUSD : double

    [<JsonProperty(PropertyName="total_24h_volume_usd")>]
    VolumeDailyUSD : double

    [<JsonProperty(PropertyName="bitcoin_percentage_of_market_cap")>]
    BitcoinPercentageMarketCap : double

    [<JsonProperty(PropertyName="active_currencies")>]
    ActiveCurrencies : int 

    [<JsonProperty(PropertyName="active_assets")>]
    ActiveAssets : int

    [<JsonProperty(PropertyName="active_markets")>]
    ActiveMarkets : int
}

type CoinCurrency = USD | AUD | BRL | CAD |CHF | CNY | EUR | GBP | HKD | IDR | INR | JPY | KRW | MXN | RUB