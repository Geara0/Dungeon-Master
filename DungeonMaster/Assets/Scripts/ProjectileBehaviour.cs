using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public float speed = 3;
    
    void Update()
    {
        transform.position += transform.right * (Time.deltaTime * speed);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
		var enemy = other.collider.GetComponent<EnemyBehaviour>();
        var enemyContainer = other.collider.GetComponent<EnemyContainerBehaviour>();
        var player = other.collider.GetComponent<PlayerController>();
        
		if(enemy)
        {
            enemy.TakeHit(1);
        }
        if(enemyContainer)
        {
            enemyContainer.TakeHit(1);
        }
        if (player) player.TakeHit(1);
        Destroy(gameObject);
    }
}
