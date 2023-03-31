using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class GenerateEnemy
{
    static private List<Vector2Int> directions = new List<Vector2Int>()
        {
            Vector2Int.down,
            Vector2Int.up,
            Vector2Int.left,
            Vector2Int.right,
            new Vector2Int(1,1),
            new Vector2Int(-1,1),
            new Vector2Int(1,-1),
            new Vector2Int(-1,-1),

        };

    public static Dictionary<Vector2Int, List<Vector2Int>> GetEnemiesPositions(HashSet<Vector2Int> floorPositions, int numberToSpawn)
    {
        Dictionary<Vector2Int, List<Vector2Int>> enemyPositions = new Dictionary<Vector2Int, List<Vector2Int>>();

        
        while (enemyPositions.Count != numberToSpawn){
            System.Random rnd = new System.Random();
            int rndPos = rnd.Next(floorPositions.Count-1);
            Vector2Int position = floorPositions.ElementAt(rndPos);
            if (!enemyPositions.ContainsKey(position))
            {
                enemyPositions.Add(position, AdjacentPositions(position, floorPositions));
            }
        }

        return enemyPositions;
    }

    private static List<Vector2Int> AdjacentPositions(Vector2Int startPos, HashSet<Vector2Int> floorPositions)
    {
        List<Vector2Int> adjacentPositions = new List<Vector2Int>
        {
            startPos
        };
        foreach (Vector2Int pos in directions)
        {
            Vector2Int potentialPos = pos + startPos;
            if(floorPositions.Contains(potentialPos)) adjacentPositions.Add(potentialPos);
        }

        return adjacentPositions;
    }
}
