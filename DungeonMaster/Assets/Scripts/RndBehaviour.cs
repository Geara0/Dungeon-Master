using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
// ReSharper disable Unity.InefficientPropertyAccess

public class RndBehaviour : MonoBehaviour, ITower
{
    public float fireRate = 1;
    public float spinRate = 10;
    public int price = 200;
    private float nextShotTime;
    private float nextSpinTime;
    private bool fullRnd = true;

    public ProjectileBehaviour projectilePrefab;
    public Transform projectileSpawner;

    private void Update()
    {
        MoveProjectileSpawner();
        Shoot();
    }

    private void MoveProjectileSpawner()
    {
        if (Time.time > nextSpinTime)
        {
            nextSpinTime += 1 / spinRate;
            
            if (fullRnd)
            {
                if (projectileSpawner.transform.position.y < transform.position.y + transform.localScale.y / 2)
                    projectileSpawner.transform.position += transform.up * (transform.localScale.y / 7);
                else if (projectileSpawner.transform.position.x < transform.position.x + transform.localScale.y / 2)
                    projectileSpawner.transform.position += transform.right * (transform.localScale.x / 7);
                else
                {
                    fullRnd = false;
                    projectileSpawner.transform.position -= transform.up * (transform.localScale.y / 7);
                }
            }
            else
            {
                if (projectileSpawner.transform.position.y > transform.position.y - transform.localScale.y / 2)
                    projectileSpawner.transform.position -= transform.up * (transform.localScale.y / 7);
                else if (projectileSpawner.transform.position.x > transform.position.x - transform.localScale.y / 2)
                    projectileSpawner.transform.position -= transform.right * (transform.localScale.x / 7);
                else
                {
                    fullRnd = true;
                    projectileSpawner.transform.position += transform.up * (transform.localScale.y / 7);
                }
            }
        }
    }
    
    public void Shoot()
    {
        if (Time.time > nextShotTime)
        {
            nextShotTime += 1 / fireRate;

            var dx = Math.Sqrt(transform.position.x * transform.position.x);
            var dy = Math.Sqrt(Math.Pow(projectileSpawner.transform.position.x - transform.position.x, 2) +
                               Math.Pow(projectileSpawner.transform.position.y - transform.position.y, 2));
            var angle = (float) (Math.Acos(-transform.position.x *
                                           (projectileSpawner.transform.position.x - transform.position.x) /
                                           (dx * dy)) * 180 / Math.PI);

            angle = transform.position.y > projectileSpawner.transform.position.y
                ? 360 - angle
                : angle;
            
            Instantiate(projectilePrefab, projectileSpawner.position, Quaternion.Euler(0f, 0f, angle));
        }
    }

    public Sprite getSprite()
    {
        return GetComponent<SpriteRenderer>().sprite;
    }

    public string getPrice()
    {
        return price.ToString();
    }
}