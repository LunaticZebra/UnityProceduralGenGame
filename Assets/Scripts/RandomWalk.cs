using System.Collections.Generic;
using UnityEngine;

public static class RandomWalk
{
    private static readonly List<Vector2Int> Directions = new List<Vector2Int>()
    {
        Vector2Int.down,
        Vector2Int.up,
        Vector2Int.left,
        Vector2Int.right
    };

    public static HashSet<Vector2Int> GoForWalk(Vector2Int position, int walkLength)
    {
        HashSet<Vector2Int> walkPositions = new HashSet<Vector2Int>();
        for (int i = 0; i < walkLength; i++)
        {
            position += Directions[Random.Range(0, Directions.Count)];
            walkPositions.Add(position);
        }
        return walkPositions;
    }
}
