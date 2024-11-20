using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;

using MyNamespace;

public class CountryData {
    public string name;
    public double lat;
    public double lon;
    public string country;
}

public class WeatherAPI : MonoBehaviour {
    public string city; 
    private double lat;
    private double lon;
    
    public string APIkey;

    public TextMeshPro messageText;
    private double temp;

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

    private IEnumerator GetWeather() {
        string url = "api.openweathermap.org/data/2.5/forecast?lat=" + lat + "&lon=" + lon + "&units=metric" + "&appid=" + APIkey;
        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success) {
            string responseText = request.downloadHandler.text;
            
            WeatherResponse data = JsonConvert.DeserializeObject<WeatherResponse>(responseText); // We receive a json format file
            WeatherEntry dataWeatherEntry = data.List[0];
            MainInfo dataMainInfo = dataWeatherEntry.Main;

            temp = dataMainInfo.Temp;
        } else {
            Debug.Log("Error: " + request.error);
        }
    }

    void Start() 
    {
        StartCoroutine(GetLatLon());
        StartCoroutine(GetWeather());
    }

    // Update is called once per frame
    void Update()
    {
        messageText.text = temp.ToString() + " Celsius\nClear!";
    }
}
