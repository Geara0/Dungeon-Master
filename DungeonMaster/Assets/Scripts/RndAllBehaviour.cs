using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RndAllBehaviour : MonoBehaviour, ITower
{
    public float fireRate = 1;
    public float spinCount = 3;
    public int price = 200;
    //private float nextShotTime;
    //private float nextSpinTime;
    //private bool fullRnd = true;

    private float rotationAngle = 180; // - 22.5f
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

    private void Start()
    {
        StartCoroutine(nameof(DoFire));
    }

    public IEnumerator DoFire()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(1 / fireRate);
        }
    }

    public void Shoot()
    {
        for (var i = 0; i < rotatioinPoints.Count; i++)
        {
            var (x, y) = rotatioinPoints[i];
            Instantiate(
                projectilePrefab,
                transform.position + new Vector3(x, y),
                Quaternion.Euler(0, 0, rotationAngle));
            rotationAngle -= rotationDelta;
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
