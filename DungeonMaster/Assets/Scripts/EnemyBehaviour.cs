using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float Hitpoints;
    public float MaxHitpoints = 5;
	public HitbarBehaviour Hitbar;

    void Start()
    {
        Hitpoints = MaxHitpoints;
		Hitbar.SetHealth(Hitpoints, MaxHitpoints);
    }
    
    public void UpdateHit(float damage)
    {
        Hitpoints -= damage;
		Hitbar.SetHealth(Hitpoints, MaxHitpoints);
        if (Hitpoints <= 0)
            Destroy(gameObject);
    }
}