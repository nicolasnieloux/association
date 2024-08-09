using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace association.Model
{
    public class WeatherData
    {
        [JsonProperty("request_state")] public int RequestState { get; set; }

        [JsonProperty("request_key")] public string RequestKey { get; set; }

        [JsonProperty("message")] public string Message { get; set; }

        [JsonProperty("model_run")] public string ModelRun { get; set; }

        [JsonProperty("source")] public string Source { get; set; }
        [JsonExtensionData] public IDictionary<string, JToken> data { get; set; }
    }

    public class WeatherDetails
    {
        [JsonProperty("temperature")] public Temperature Temperature { get; set; }
        [JsonProperty("pression")] public Pression Pression { get; set; }

        [JsonProperty("pluie")] public float Pluie { get; set; }
        [JsonProperty("pluie_convective")] public float PluieConvective { get; set; }

        [JsonProperty("humidite")] public Humidite Humidite { get; set; }
        [JsonProperty("vent_moyen")] public Vent VentMoyen { get; set; }
        [JsonProperty("vent_rafales")] public Vent VentRafales { get; set; }
        [JsonProperty("vent_direction")] public Vent VentDirection { get; set; }

        [JsonProperty("iso_zero")] public int IsoZero { get; set; }

        [JsonProperty("risque_neige")] public string RisqueNeige { get; set; }

        [JsonProperty("cape")] public float Cape { get; set; }
        [JsonProperty("nebulosite")] public Nebulosite Nebulosite { get; set; }
    }

    public class Temperature
    {
        [JsonProperty("2m")] public float T2m { get; set; }

        [JsonProperty("sol")] public float Sol { get; set; }

        [JsonProperty("500hPa")] public float T500hPa { get; set; }

        [JsonProperty("850hPa")] public float T850hPa { get; set; }
    }

    public class Pression
    {
        [JsonProperty("niveau_de_la_mer")] public int NiveauDeLaMer { get; set; }
    }

    public class Humidite
    {
        [JsonProperty("2m")] public float H2m { get; set; }
    }

    public class Vent
    {
        [JsonProperty("10m")] public float V10m { get; set; }
    }

    public class Nebulosite
    {
        [JsonProperty("haute")] public int Haute { get; set; }
        [JsonProperty("moyenne")] public int Moyenne { get; set; }
        [JsonProperty("basse")] public int Basse { get; set; }
        [JsonProperty("totale")] public int Totale { get; set; }
    }
}