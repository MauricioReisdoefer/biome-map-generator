using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class NoiseGenerator
{
    public static NoiseMap GeneratePerlin(
        int width, int height,
        float scale,
        Vector2 offset
    )
    {
        NoiseMap map = new NoiseMap
        {
            width = width,
            height = height,
            values = new float[width, height]
        };

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                float nx = (x + offset.x) / scale;
                float ny = (y + offset.y) / scale;
                map.values[x, y] = Mathf.PerlinNoise(nx, ny);
            }
        }

        return map;
    }
}