using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyBehaviour : MonoBehaviour
{
    public int cost = 20;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        var player = other.collider.GetComponent<PlayerController>();
        if (player) PlayerController.GainMoney(cost);
        Destroy(gameObject);
    }
}
