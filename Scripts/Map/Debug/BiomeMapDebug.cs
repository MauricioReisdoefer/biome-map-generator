using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiomeMapDebug : MonoBehaviour
{
    public int width = 100;
    public int height = 100;
    public int seed = 42;

    List<BiomeRule> biomeRules = new List<BiomeRule>
{
    new BiomeRule
{
    biome = BiomeType.Ocean,
    altitudeRange = new Vector2(0.00f, 0.30f),
    temperatureRange = new Vector2(0.00f, 1.00f),
    humidityRange = new Vector2(0.00f, 1.00f),
    weight = 1.4f
},

new BiomeRule
{
    biome = BiomeType.Beach,
    altitudeRange = new Vector2(0.30f, 0.36f),
    temperatureRange = new Vector2(0.30f, 0.80f),
    humidityRange = new Vector2(0.20f, 0.80f),
    weight = 0.6f
},

new BiomeRule
{
    biome = BiomeType.Mountain,
    altitudeRange = new Vector2(0.75f, 1.00f),
    temperatureRange = new Vector2(0.00f, 1.00f),
    humidityRange = new Vector2(0.00f, 1.00f),
    weight = 1.3f
},

new BiomeRule
{
    biome = BiomeType.Snow,
    altitudeRange = new Vector2(0.65f, 1.00f),
    temperatureRange = new Vector2(0.00f, 0.25f),
    humidityRange = new Vector2(0.30f, 1.00f),
    weight = 1.2f
},

new BiomeRule
{
    biome = BiomeType.Tundra,
    altitudeRange = new Vector2(0.36f, 0.65f),
    temperatureRange = new Vector2(0.00f, 0.30f),
    humidityRange = new Vector2(0.00f, 0.40f),
    weight = 0.9f
},

new BiomeRule
{
    biome = BiomeType.Desert,
    altitudeRange = new Vector2(0.36f, 0.65f),
    temperatureRange = new Vector2(0.70f, 1.00f),
    humidityRange = new Vector2(0.00f, 0.30f),
    weight = 1.1f
},

new BiomeRule
{
    biome = BiomeType.RedForest,
    altitudeRange = new Vector2(0.36f, 0.70f),
    temperatureRange = new Vector2(0.45f, 0.75f),
    humidityRange = new Vector2(0.35f, 0.55f),
    weight = 0.75f
},

new BiomeRule
{
    biome = BiomeType.Birch,
    altitudeRange = new Vector2(0.36f, 0.65f),
    temperatureRange = new Vector2(0.30f, 0.55f),
    humidityRange = new Vector2(0.40f, 0.65f),
    weight = 0.85f
},

new BiomeRule
{
    biome = BiomeType.Forest,
    altitudeRange = new Vector2(0.36f, 0.70f),
    temperatureRange = new Vector2(0.35f, 0.65f),
    humidityRange = new Vector2(0.45f, 0.75f),
    weight = 1.0f
}

};


    private BiomeType[,] biomeMap;

    void OnValidate()
    {
        Generate();
    }

    void Generate()
    {
        biomeMap = BiomeMapGenerator.Generate(
            width,
            height,
            biomeRules,
            seed
        );
    }

    void OnDrawGizmos()
    {
        if (biomeMap == null) return;

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Gizmos.color = GetBiomeColor(biomeMap[x, y]);
                Gizmos.DrawCube(
                    new Vector3(x, y, 0),
                    Vector3.one
                );
            }
        }
    }

    Color GetBiomeColor(BiomeType biome)
    {
        switch (biome)
        {
            case BiomeType.Ocean:
                return new Color(0.1f, 0.35f, 0.8f);        // azul mais forte

            case BiomeType.Beach:
                return new Color(0.95f, 0.85f, 0.55f);      // areia mais quente

            case BiomeType.Desert:
                return new Color(0.95f, 0.75f, 0.2f);       // amarelo menos estourado

            case BiomeType.Birch:
                return new Color(0.7f, 0.9f, 0.6f);         // verde claro bem distinto

            case BiomeType.Forest:
                return new Color(0.1f, 0.55f, 0.15f);       // verde escuro mais profundo

            case BiomeType.RedForest:
                return new Color(0.75f, 0.3f, 0.3f);        // vermelho quente (primavera/outono)

            case BiomeType.Snow:
                return new Color(0.95f, 0.95f, 0.95f);      // branco visível no fundo

            case BiomeType.Tundra:
                return new Color(0.6f, 0.8f, 0.9f);         // azul frio mais contrastante

            case BiomeType.Mountain:
                return new Color(0.5f, 0.5f, 0.5f);         // cinza médio (não “sumir”)

            default:
                return Color.magenta;

        }
    }
}
