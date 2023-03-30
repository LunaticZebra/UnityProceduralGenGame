using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GenerateWalls
{
    public static HashSet<Vector2Int> GetWallsPositions(HashSet<Vector2Int> floorPositions)
    {
        HashSet<Vector2Int> wallsPositions = new HashSet<Vector2Int>();
        List<Vector2Int> directions = new List<Vector2Int>()
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

        foreach (Vector2Int floorPos in floorPositions)
        {
            foreach(Vector2Int direction in directions)
            {
                Vector2Int adjacentPos = floorPos + direction;
                if (!floorPositions.Contains(adjacentPos)) wallsPositions.Add(adjacentPos);
            }
        }
        return wallsPositions;
    }
}
