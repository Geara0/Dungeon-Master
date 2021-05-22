using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.VFX;

public class MovementBehaviour : MonoBehaviour
{
    public float speed;
    public GameObject start;
    public float spawnRate = 1;
    public List<int> enemyCount;
    public List<EnemyBehaviour> enemy;

    private float nextActionTime;

    private List<Vector2> wayPoints;

    // Start is called before the first frame update
    void Start()
    {
        var road = GameObject.FindGameObjectsWithTag("Road")[0].GetComponent<Tilemap>();
        var tiles = new HashSet<Vector2>();
        for (var x = road.origin.x; x < road.origin.x + road.size.x; x++)
        for (var y = road.origin.y; y < road.origin.y + road.size.y; y++)
            if (road.HasTile(new Vector3Int(x, y, 0)))
                tiles.Add(
                    road.CellToWorld(new Vector3Int(x, y, 0)) + new Vector3(.5f, .5f));

        var minLen = double.PositiveInfinity;
        var corePoints = new List<Vector2>();
        Vector2? startPoint = null;

        foreach (var tile in tiles)
        {
            var lenToStart = Vector2.Distance(start.transform.position, tile);
            if (!(lenToStart < minLen)) continue;

            startPoint = tile;
            minLen = lenToStart;
        }

        // ReSharper disable once PossibleInvalidOperationException
        //Оно не может быть нулём
        corePoints.Add((Vector2) startPoint);
        tiles.Remove((Vector2) startPoint);

        var corePoint = (Vector2) startPoint;
        while (tiles.Count != 0)
            for (var dx = -1; dx <= 1; dx++)
            for (var dy = -1; dy <= 1; dy++)
            {
                if (dx != 0 && dy != 0 || dx == 0 && dy == 0) continue;

                var dirVector = new Vector2(dx, dy);
                corePoint = GetNextCorePoint(tiles, corePoint, dirVector);
                if (!corePoints.Contains(corePoint)) corePoints.Add(corePoint);
            }

        wayPoints = corePoints;

    }

    // Update is called once per frame
    void Update()
    {
        Spawn();
    }

    private void Spawn()
    {
        if (Time.time > nextActionTime && enemyCount.Count > 0)
        {
            nextActionTime += 1 / spawnRate;
            
            if (enemyCount[enemyCount.Count - 1] != 0)
            {
                var tmpEnemy = 
                    Instantiate(enemy[enemy.Count - 1], transform.position, Quaternion.Euler(0f, 0f, 0f));
                //tmpEnemy.transform.SetParent(gameObject.transform, false);
                var enemyScr = tmpEnemy.GetComponent<EnemyBehaviour>();
                enemyScr.wayPoints = wayPoints;
                enemyScr.speed = speed;
                enemyCount[enemyCount.Count - 1]--;
            }
            else
            {
                enemy.RemoveAt(enemy.Count - 1);
                enemyCount.RemoveAt(enemyCount.Count - 1);
            }
        }
    }

    private Vector2 GetNextCorePoint(HashSet<Vector2> tiles, Vector2 corePoint, Vector2 dirVector)
    {
        while (tiles.Contains(corePoint + dirVector))
        {
            tiles.Remove(corePoint + dirVector);
            corePoint += dirVector;
        }

        return corePoint;
    }
}
