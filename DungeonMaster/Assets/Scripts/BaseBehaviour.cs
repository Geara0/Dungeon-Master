using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBehaviour : MonoBehaviour
{
    public int Hitpoints;
    public int MaxHitpoints;
    void Start()
    {
        Hitpoints = MaxHitpoints;
    }

    public void TakeHit(int damage)
    {
        Hitpoints -= damage;
        if (Hitpoints <= 0)
            Destroy(gameObject);
    }
}
