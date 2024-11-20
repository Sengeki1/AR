using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using Newtonsoft.Json;

using MyNamespace;
using System;

public class TimeAPI : MonoBehaviour
{
    public string city; 
    private double lat;
    private double lon;
    
    public string APIkey;

    public TextMeshPro messageText;
    private string time;

    private IEnumerator GetLatLon() {
        string url = "http://api.openweathermap.org/geo/1.0/direct?q=" + city + "&appid=" + APIkey;
        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success) {
            string responseText = request.downloadHandler.text;  
            
            CountryData[] dataDictionary = JsonConvert.DeserializeObject<CountryData[]>(responseText); // We receive a list of a json format file
            CountryData data = dataDictionary[0];
            lat = data.lat;
            lon = data.lon;
        } else {
            Debug.Log("Error: " + request.error);
        }
    }

        private IEnumerator GetTime() {
        string url = "api.openweathermap.org/data/2.5/forecast?lat=" + lat + "&lon=" + lon + "&units=metric" + "&appid=" + APIkey;
        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success) {
            string responseText = request.downloadHandler.text;
            
            CountryTime data = JsonConvert.DeserializeObject<CountryTime>(responseText); // We receive a json format file
            CountryMainInfo dataCityEntry = data.city;

            int sunrise = dataCityEntry.sunrise;
            int timezone = dataCityEntry.timezone;

            DateTime utcSunrise = DateTimeOffset.FromUnixTimeSeconds(sunrise).UtcDateTime;
            DateTime localSunrise = utcSunrise.AddSeconds(timezone).ToLocalTime();

            time = localSunrise.ToString("HH:mm:ss");
        } else {
            Debug.Log("Error: " + request.error);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetLatLon());
        StartCoroutine(GetTime());
    }

    // Update is called once per frame
    void Update()
    {
        messageText.text = time;
    }
}
