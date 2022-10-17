using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoApp.Model
{

    public class Rootobject
    {
        public List<Asset> assets { get; set; }
        public List<Market> markets { get; set; }
        public List<Exchange> exchanges { get; set; }
        public string next { get; set; }
    }

    public class Asset
    {
        public Quote quote { get; set; }
        public string asset_id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string website { get; set; }
        public string ethereum_contract_address { get; set; }
        public string pegged { get; set; }
        public float price { get; set; }
        public float volume_24h { get; set; }
        public float change_1h { get; set; }
        public float change_24h { get; set; }
        public float change_7d { get; set; }
        public float total_supply { get; set; }
        public float circulating_supply { get; set; }
        public long max_supply { get; set; }
        public float market_cap { get; set; }
        public float fully_diluted_market_cap { get; set; }
        public string status { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }

    public class Market
    {
        public Quote quote { get; set; }
        public string exchange_id { get; set; }
        public string symbol { get; set; }
        public string base_asset { get; set; }
        public string quote_asset { get; set; }
        public float price_unconverted { get; set; }
        public float price { get; set; }
        public float change_24h { get; set; }
        public float spread { get; set; }
        public float volume_24h { get; set; }
        public string status { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }

    public class Exchange
    {
        public Quote quote { get; set; }
        public string exchange_id { get; set; }
        public string name { get; set; }
        public string website { get; set; }
        public float volume_24h { get; set; }
    }
    public class Quote
    {
        public USD USD { get; set; }
        public NZD NZD { get; set; }
        public CAD CAD { get; set; }
        public JPY JPY { get; set; }
        public EUR EUR { get; set; }
        public GBP GBP { get; set; }
        public AUD AUD { get; set; }
    }

    public class USD
    {
        public float price { get; set; }
        public float volume_24h { get; set; }
        public float market_cap { get; set; }
        public float fully_diluted_market_cap { get; set; }
    }

    public class NZD
    {
        public float price { get; set; }
        public float volume_24h { get; set; }
        public float market_cap { get; set; }
        public float fully_diluted_market_cap { get; set; }
    }

    public class CAD
    {
        public float price { get; set; }
        public float volume_24h { get; set; }
        public float market_cap { get; set; }
        public float fully_diluted_market_cap { get; set; }
    }

    public class JPY
    {
        public float price { get; set; }
        public float volume_24h { get; set; }
        public float market_cap { get; set; }
        public float fully_diluted_market_cap { get; set; }
    }

    public class EUR
    {
        public float price { get; set; }
        public float volume_24h { get; set; }
        public float market_cap { get; set; }
        public float fully_diluted_market_cap { get; set; }
    }

    public class GBP
    {
        public float price { get; set; }
        public float volume_24h { get; set; }
        public float market_cap { get; set; }
        public float fully_diluted_market_cap { get; set; }
    }

    public class AUD
    {
        public float price { get; set; }
        public float volume_24h { get; set; }
        public float market_cap { get; set; }
        public float fully_diluted_market_cap { get; set; }
    }

}
