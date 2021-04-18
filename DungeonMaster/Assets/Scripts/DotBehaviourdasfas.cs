using UnityEngine;

public class TowerBehaviour : MonoBehaviour
{
    private float nextActionTime = 0;
    public const float fireRate = 1;
    public ProjectileBehaviour projectilePrefab;
    public Transform launchOffset;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime += fireRate;
            var position = launchOffset.position;
            Instantiate(projectilePrefab, position, Quaternion.Euler(0f, 0f, 0f));
            Instantiate(projectilePrefab, position, Quaternion.Euler(0f, 0f, 90f));
            Instantiate(projectilePrefab, position, Quaternion.Euler(0f, 0f, 180f));
            Instantiate(projectilePrefab, position, Quaternion.Euler(0f, 0f, 270f));
        }
    }
}