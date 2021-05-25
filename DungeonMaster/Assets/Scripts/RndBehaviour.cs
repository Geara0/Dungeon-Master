using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

// ReSharper disable Unity.InefficientPropertyAccess

public class RndBehaviour : MonoBehaviour, ITower
{
    public float fireRate = 1;
    public float spinCount = 3;
    public int price = 200;
    //private float nextShotTime;
    //private float nextSpinTime;
    //private bool fullRnd = true;

    private float rotationAngle = 180 + 22.5f; // - 22.5f
    private float rotationDelta = 22.5f;
    private List<(float, float)> rotatioinPoints = new List<(float, float)>
    {
        (-0.66f, 0f), (-0.66f, 0.33f), (-0.66f, 0.66f),
        (-0.33f, 0.66f), (0f, 0.66f), (0.33f, 0.66f), (0.66f, 0.66f),
        (0.66f, 0.33f), (0.66f, 0f), (0.66f, -0.33f), (0.66f, -0.66f),
        (0.33f, -0.66f), (0f, -0.66f), (-0.33f, -0.66f), (-0.66f, -0.66f),
        (-0.66f, -0.33f)
    };
    private int rotationIndex;

    public ProjectileBehaviour projectilePrefab;
    public Transform projectileSpawner;

    private void Start()
    {
        projectileSpawner.transform.localPosition = new Vector3(-0.644f, 0, 0);
        StartCoroutine(nameof(DoFire));
    }

    public IEnumerator DoFire()
    {
        while (true)
        {
            Shoot();
            MoveProjectileSpawner();
            yield return new WaitForSeconds(1 / fireRate);
        }
    }

    private void MoveProjectileSpawner()
    {
        /*
        if (fullRnd)
        {
            if (projectileSpawner.transform.position.y < transform.position.y + transform.localScale.y / 2)
                projectileSpawner.transform.position += transform.up * (transform.localScale.y / spinCount);
            else if (projectileSpawner.transform.position.x < transform.position.x + transform.localScale.y / 2)
                projectileSpawner.transform.position += transform.right * (transform.localScale.x / spinCount);
            else
            {
                fullRnd = false;
                projectileSpawner.transform.position -= transform.up * (transform.localScale.y / spinCount);
            }
        }
        else
        {
            if (projectileSpawner.transform.position.y > transform.position.y - transform.localScale.y / 2)
                projectileSpawner.transform.position -= transform.up * (transform.localScale.y / spinCount);
            else if (projectileSpawner.transform.position.x > transform.position.x - transform.localScale.y / 2)
                projectileSpawner.transform.position -= transform.right * (transform.localScale.x / spinCount);
            else
            {
                fullRnd = true;
                projectileSpawner.transform.position += transform.up * (transform.localScale.y / spinCount);
            }
        }
        */

        rotationAngle -= rotationDelta;
        var (x, y) = rotatioinPoints[rotationIndex % rotatioinPoints.Count];
        projectileSpawner.transform.localPosition =
            new Vector3(x, y);
        rotationIndex++;
    }

    public void Shoot()
    {
        //var dx = Math.Sqrt(transform.position.x * transform.position.x);
        //var dy = Math.Sqrt(Math.Pow(projectileSpawner.transform.position.x - transform.position.x, 2) +
        //                   Math.Pow(projectileSpawner.transform.position.y - transform.position.y, 2));
        //var angle = (float) (Math.Acos(-transform.position.x *
        //                               (projectileSpawner.transform.position.x - transform.position.x) /
        //                               (dx * dy)) * 180 / Math.PI);
        //Instantiate(projectilePrefab, projectileSpawner.position, Quaternion.Euler(0f, 0f, angle));
        Instantiate(projectilePrefab, projectileSpawner.position, 
            Quaternion.Euler(0f, 0f, rotationAngle));
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