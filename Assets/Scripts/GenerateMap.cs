using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using Quaternion = System.Numerics.Quaternion;

public class GenerateMap : MonoBehaviour
{
    [SerializeField] private Vector2Int startingPosition = new Vector2Int(0, 0);

    [SerializeField] private int walkDistance = 10;

    [SerializeField] private int iterations = 10;

    [SerializeField] private bool startAtRandomPlace = true;

    [SerializeField] private GameObject TileHolder;

    [SerializeField] private GameObject Tile;

    [SerializeField] private GameObject Wall;

    public HashSet<Vector2Int> FloorPositions;


    void Awake()
        {
            GenerateFloorPositions();
            InstantiateFloorTiles();
            InstantiateWalls();
        }

    private void InstantiateWalls()
    {
        HashSet<Vector2Int> wallsPositions = GenerateWalls.GetWallsPositions(FloorPositions);
        foreach (Vector2Int wallPos in wallsPositions)
        {
            Instantiate(Wall, new Vector2(wallPos.x, wallPos.y), UnityEngine.Quaternion.identity, TileHolder.transform);
        }
    }

    private void GenerateFloorPositions()
    {
        FloorPositions = new HashSet<Vector2Int>();
        for (int i = 0; i < iterations; i++)
        {
            FloorPositions.UnionWith(RandomWalk.GoForWalk(startingPosition, walkDistance));
            if (startAtRandomPlace) startingPosition = FloorPositions.ElementAt(Random.Range(0,FloorPositions.Count));
        }
    }

    private void InstantiateFloorTiles()
    {
        for (int i = 0; i < FloorPositions.Count; i++)
        {
            Vector2Int position = FloorPositions.ElementAt(i);
            Instantiate(Tile, new Vector2(position.x, position.y),
                UnityEngine.Quaternion.identity, TileHolder.transform);
        }
    }
}
