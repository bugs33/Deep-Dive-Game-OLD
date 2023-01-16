using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class perlinTerrainGeneration : MonoBehaviour
{
    public int width = 256;
    public int height = 256;

    public int maxDepth = 50;

    public float depth = 20;
    
    public float scale = 20;

    public float depth2 = 5;
    public float scale2 = 5;
    // Start is called before the first frame update
    void Start()
    {
        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData = GenerateTerrainData(terrain.terrainData);
    }

    TerrainData GenerateTerrainData(TerrainData terrainData) {
        terrainData.heightmapResolution = width + 1;
        terrainData.size = new Vector3(width, maxDepth, height);

        terrainData.SetHeights(0,0, GenerateHeights());
        return terrainData;
    }

    float[,] GenerateHeights() {
        float[,] heights = new float[width, height];
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                heights[x, y] = CalculateNoise(x,y);
            }
        }
        return heights;
    }

    float CalculateNoise (int x, int y) {
        float xCoord = (float)x / width * scale;
        float yCoord = (float)y / height * scale;

        float xCoord2 = (float)x / width * scale2;
        float yCoord2 = (float)y / height * scale2;

        return (Mathf.PerlinNoise(xCoord, yCoord) * depth) + (Mathf.PerlinNoise(xCoord2, yCoord2) * depth2);
    }
    // Update is called once per frame
    
}
