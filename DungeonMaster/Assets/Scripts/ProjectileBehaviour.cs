using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public float speed = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * (Time.deltaTime * speed);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
		var enemy = other.collider.GetComponent<EnemyBehaviour>();
		if(enemy)
			enemy.UpdateHit(1);
        if (other.gameObject.CompareTag("Player"))
            Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
