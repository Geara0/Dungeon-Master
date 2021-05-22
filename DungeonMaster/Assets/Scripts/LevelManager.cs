using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelManager : MonoBehaviour
{
    public GameObject cellPref;
    public Transform cellParent;

    // Start is called before the first frame update
    void Start()
    {
        CreateLevel();
    }

    private void CreateLevel()
    {
        var bg = GameObject.FindGameObjectsWithTag("Background")[0].GetComponent<Tilemap>();
        var road = GameObject.FindGameObjectsWithTag("Road")[0].GetComponent<Tilemap>();
        var objects = GameObject.FindGameObjectsWithTag("Objects")[0].GetComponent<Tilemap>();
        
        for (var x = bg.origin.x; x < bg.origin.x + bg.size.x; x++)
        for (var y = bg.origin.y; y < bg.origin.y + bg.size.y; y++)
        {
            if (road.HasTile(new Vector3Int(x, y, 0)) || 
                objects.HasTile(new Vector3Int(x, y, 0))) continue;
            var pos = bg.CellToWorld(new Vector3Int(x, y, 0)) + new Vector3(.5f, .5f);
            CreateCell(pos);
        }
    }

    private void CreateCell(Vector3 pos)
    {
        var tmpCell = Instantiate(cellPref, pos, Quaternion.Euler(0f, 0f, 0f), cellParent);
    }
}