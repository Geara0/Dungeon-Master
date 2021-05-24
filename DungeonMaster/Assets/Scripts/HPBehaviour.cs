using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBehaviour : MonoBehaviour
{
    public int hpAmount = 1;
    public float disappearTime = 16;

    private void Start()
    {
        StartCoroutine(nameof(Disappear));
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        var player = other.collider.GetComponent<PlayerController>();
        if (!player) return;
        AddHP(player, hpAmount);
        Destroy(gameObject);
    }

    private IEnumerator Disappear()
    {
        yield return new WaitForSeconds(disappearTime);
        Destroy(gameObject);
    }

    private void AddHP(PlayerController player, int amount)
    {
        player.AddHP(amount);
    }
}
