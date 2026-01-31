using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BiomeResolver
{
    public static BiomeType GetBiome(
        float altitude,
        float temperature,
        float humidity,
        List<BiomeRule> rules
    )
    {
        foreach (var rule in rules)
        {
            if (
                altitude >= rule.altitudeRange.x && altitude <= rule.altitudeRange.y &&
                temperature >= rule.temperatureRange.x && temperature <= rule.temperatureRange.y &&
                humidity >= rule.humidityRange.x && humidity <= rule.humidityRange.y
            )
            {
                return rule.biome;
            }
        }

        return BiomeType.Forest;
    }
}
