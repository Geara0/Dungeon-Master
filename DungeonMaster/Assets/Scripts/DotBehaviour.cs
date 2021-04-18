using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ReSharper disable Unity.InefficientPropertyAccess

public class DotBehaviour : MonoBehaviour
{
    private float nextActionTime;
    public float fireRate = 1;
    
    public ProjectileBehaviour projectilePrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime += 1 / fireRate;
            var xOffset = transform.right * (transform.localScale.x / 2f + projectilePrefab.transform.localScale.x / 3.5f);
            var yOffset = transform.up * (transform.localScale.y / 2f + projectilePrefab.transform.localScale.y / 3.5f);
            
            Instantiate(projectilePrefab, transform.position + xOffset, Quaternion.Euler(0f, 0f, 0f));
            Instantiate(projectilePrefab, transform.position + yOffset, Quaternion.Euler(0f, 0f, 90f));
            Instantiate(projectilePrefab, transform.position - xOffset, Quaternion.Euler(0f, 0f, 180f));
            Instantiate(projectilePrefab, transform.position - yOffset, Quaternion.Euler(0f, 0f, 270f));
        }
    }
}
