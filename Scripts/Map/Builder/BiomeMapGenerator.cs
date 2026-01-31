using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiomeMapGenerator
{
    public static BiomeType[,] Generate(
        int width,
        int height,
        List<BiomeRule> rules,
        int seed
    )
    {
        System.Random prng = new System.Random(seed);

        Vector2 altitudeOffset = new Vector2(prng.Next(-100000, 100000), prng.Next(-100000, 100000));
        Vector2 temperatureOffset = new Vector2(prng.Next(-100000, 100000), prng.Next(-100000, 100000));
        Vector2 humidityOffset = new Vector2(prng.Next(-100000, 100000), prng.Next(-100000, 100000));

        NoiseMap altitude = NoiseGenerator.GeneratePerlin(width, height, 200f, altitudeOffset);
        NoiseMap temperature = NoiseGenerator.GeneratePerlin(width, height, 120f, temperatureOffset);
        NoiseMap humidity = NoiseGenerator.GeneratePerlin(width, height, 100f, humidityOffset);

        BiomeType[,] biomeMap = new BiomeType[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                biomeMap[x, y] = BiomeResolver.GetBiome(
                    altitude.values[x, y],
                    temperature.values[x, y],
                    humidity.values[x, y],
                    rules
                );
            }
        }

        return biomeMap;
    }
}
