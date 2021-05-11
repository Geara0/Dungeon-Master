using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public int Hitpoints;
    public int MaxHitpoints;
    public List<Vector2> wayPoints;

    private int wayIndex;
    public float speed;
    
    public EnemyBehaviour(List<Vector2> wayPoints, float speed)
    {
        this.wayPoints = wayPoints;
        this.speed = speed;
    }


    void Start()
    {
        Hitpoints = MaxHitpoints;
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
        Hitpoints -= damage;
        if (Hitpoints <= 0)
            Destroy(gameObject);
    }

	private void OnCollisionEnter2D(Collision2D other)
    {
		var baseObj = other.collider.GetComponent<BaseBehaviour>();
		if(baseObj)
			baseObj.TakeHit(1);
        Destroy(gameObject);
    }
}