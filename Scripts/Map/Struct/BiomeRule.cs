using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BiomeRule
{
    public BiomeType biome;
    public Vector2 altitudeRange;
    public Vector2 temperatureRange;
    public Vector2 humidityRange;
}