using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class EnemyBehaviour : MonoBehaviour
{
    public int hitpoints;
    public int maxHitpoints;
    public List<Vector2> wayPoints;
    
    public GameObject coinPrefab;
    public int maxMoneyCount;

    private int wayIndex;
    public float speed;

    public EnemyBehaviour(List<Vector2> wayPoints, float speed)
    {
        this.wayPoints = wayPoints;
        this.speed = speed;
    }


    void Start()
    {
        hitpoints = maxHitpoints;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        var dir = wayPoints[wayIndex] - (Vector2) transform.position;

        transform.Translate(dir.normalized * (Time.deltaTime * speed));

        if (Vector3.Distance(transform.position, wayPoints[wayIndex]) < .2f)
        {
            if (wayIndex < wayPoints.Count - 1)
                wayIndex++;
            else
                Destroy(gameObject);
        }
    }

    public void TakeHit(int damage)
    {
        hitpoints -= damage;
        if (hitpoints <= 0)
        {
            var rnd = new Random();
            Destroy(gameObject);
            SpawnCoin(rnd.Next(1, maxMoneyCount));
        }
    }

    private void SpawnCoin(int count)
    {
        var rnd = new Random();
        for (var i = 0; i < count; i++)
        {
            var posX = (float) rnd.NextDouble() * 2 - 1;
            var posY = (float) rnd.NextDouble() * 2 - 1;
            Instantiate(coinPrefab, transform.position + new Vector3(posX, posY), 
                Quaternion.Euler(0, 0, 0));
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        var baseObj = other.collider.GetComponent<BaseBehaviour>();
        if (baseObj)
        {
            baseObj.TakeHit(1);
            Destroy(gameObject);
        }
        //TODO: 
        //Сделай столкновение со снарядом
        //else if ()
    }
}