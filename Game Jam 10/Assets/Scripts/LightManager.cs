using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LightManager : MonoBehaviour
{
    public Tilemap Darkmap;
    public Tilemap Blurredmap; 
    public Tilemap Walls;

    public Tile Darktile;
    public Tile Blurredtile;

    // Start is called before the first frame update
    void Start()
    {
        Darkmap.origin = Blurredmap.origin = Walls.origin;
        Darkmap.size = Blurredmap.size = Walls.size;

        foreach(Vector3Int p in Darkmap.cellBounds.allPositionsWithin){
            Darkmap.SetTile(p, Darktile);
        }

        foreach(Vector3Int p in Blurredmap.cellBounds.allPositionsWithin){
            Blurredmap.SetTile(p, Blurredtile);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
