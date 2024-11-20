using System.Collections.Generic;

namespace MyNamespace {
    public class WeatherResponse
    {
        public string Cod { get; set; }
        public int Message { get; set; }
        public int Cnt { get; set; }
        public List<WeatherEntry> List { get; set; }
    }

    public class CountryTime
    {
        public CountryMainInfo city;
    }

    public class CountryMainInfo {
        public int id { get; set; }
        public string name { get; set; }
        public CountryCoord coord { get; set; }
        public string country { get; set; }
        public int population { get; set; }
        public int timezone { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }
    }

    public class CountryCoord {
        public double lat {get; set;}
        public double lon {get;set;}
    }

    public class WeatherEntry
    {
        public long Dt { get; set; }
        public MainInfo Main { get; set; }
    }

    public class MainInfo
    {
        public double Temp { get; set; }
        public double FeelsLike { get; set; }
        public double TempMin { get; set; }
        public double TempMax { get; set; }
        public int Pressure { get; set; }
        public int SeaLevel { get; set; }
        public int GrndLevel { get; set; }
        public int Humidity { get; set; }
        public double TempKf { get; set; }
    }
}