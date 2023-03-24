using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class GenerateMap : MonoBehaviour
{
    [SerializeField] private Vector2Int startingPosition = new Vector2Int(0, 0);

    [SerializeField] private int walkDistance = 10;

    [SerializeField] private int iterations = 10;

    [SerializeField] private bool startAtRandomPlace = true;

    [SerializeField] private GameObject TileHolder;

    [SerializeField] private GameObject Tile;

    public HashSet<Vector2Int> FloorPositions;


    void Awake()
    {
        FloorPositions = new HashSet<Vector2Int>();
        for (int i = 0; i < iterations; i++)
        {
            FloorPositions.UnionWith(RandomWalk.GoForWalk(startingPosition, walkDistance));
            if (startAtRandomPlace) startingPosition = FloorPositions.ElementAt(Random.Range(0,FloorPositions.Count));
        }

        for (int i = 0; i < FloorPositions.Count; i++)
        {
            Debug.Log(FloorPositions.ElementAt(i));
        }
    }
    
}
