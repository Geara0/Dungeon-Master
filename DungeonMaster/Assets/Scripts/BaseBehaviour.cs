using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBehaviour : MonoBehaviour
{
    public int Hitpoints;
    public int MaxHitpoints;
    public GameObject videoPlayer;
    public int timeToStop;
    void Start()
    {
        Hitpoints = MaxHitpoints;
        videoPlayer.SetActive(false);
    }

    public void TakeHit(int damage)
    {
        Hitpoints -= damage;
        if (Hitpoints <= 0)
        {
            videoPlayer.SetActive(true);
            Destroy(videoPlayer, timeToStop);
            Destroy(gameObject);
        }
    }
}
