using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMapGrid: MonoBehaviour
{
    public void Start()
    {
        Debug.Log(GenerateNoiseGrid(10, 60));
    }
    public int[,] GenerateNoiseGrid(int size, int density)
    {
        System.Random rand = new();
        int[,] grid = new int[size,size];
        if (density > 0 && density < 100) {
            for (int i = 0; i < size; i++)
            {
                for(int j =0; j < size; j++)
                {
                    if (rand.Next(100) <= density) grid[i,j] = 0;
                    else grid[i,j] = 1;
                }
            }
        }
        return grid;
    }
}
