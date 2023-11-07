using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WeatherProfile
{
    public TimeOfDay timeOfDay;
    public Precipitation precipitation;
    public Wind wind;
    // Add more settings as needed

    // Constructor to set default weather
    public WeatherProfile()
    {
        timeOfDay = TimeOfDay.Day;
        precipitation = Precipitation.Clear;
        wind = Wind.Calm;
        // Set other defaults
    }
}