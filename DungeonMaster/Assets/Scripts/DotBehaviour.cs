using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ReSharper disable Unity.InefficientPropertyAccess

public class DotBehaviour : MonoBehaviour, ITower
{
    private float nextActionTime;
    public float fireRate = 1;
    public int price = 200;
    
    public ProjectileBehaviour projectilePrefab;

    void Update()
    {
        Shoot();
    }

    public void Shoot()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime += 1 / fireRate;
            var xOffset = transform.right * (transform.localScale.x / 2);
            var yOffset = transform.up * (transform.localScale.y / 2);

            Instantiate(projectilePrefab, transform.position + xOffset, Quaternion.Euler(0f, 0f, 0f));
            Instantiate(projectilePrefab, transform.position + yOffset, Quaternion.Euler(0f, 0f, 90f));
            Instantiate(projectilePrefab, transform.position - xOffset, Quaternion.Euler(0f, 0f, 180f));
            Instantiate(projectilePrefab, transform.position - yOffset, Quaternion.Euler(0f, 0f, 270f));
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
