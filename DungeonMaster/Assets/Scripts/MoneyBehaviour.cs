using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyBehaviour : MonoBehaviour
{
    public int cost = 20;
    public float DisappearTime = 16;

    private void Start()
    {
        StartCoroutine(nameof(Disappear));
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        var player = other.collider.GetComponent<PlayerController>();
        if (!player) return;
        PlayerController.GainMoney(cost);
        Destroy(gameObject);
    }

    private IEnumerator Disappear()
    {
        yield return new WaitForSeconds(DisappearTime);
        Destroy(gameObject);
    }
}
