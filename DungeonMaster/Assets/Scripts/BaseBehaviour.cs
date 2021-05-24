using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseBehaviour : MonoBehaviour
{
    private int Hitpoints;
    public int MaxHitpoints;
    public GameObject videoPlayer;
    public int timeToStop;
    public GameObject objectToDestroy;
	public GameOverScreen GameOverScreen;
	public Text itemsInChest;

    void Start()
    {
        Hitpoints = MaxHitpoints;
        videoPlayer.SetActive(false);
	}

    public void TakeHit(int damage)
    {
        Hitpoints -= damage;
		itemsInChest.text = Hitpoints.ToString() + " ITEMS LEFT IN CHEST";
        if (Hitpoints <= 0)
        {
            videoPlayer.SetActive(true);
            Destroy(videoPlayer, timeToStop);
            Destroy(gameObject);
            Destroy(objectToDestroy);
			var score = GameObject.FindGameObjectsWithTag("LevelManager")[0].GetComponent<ScoreManager>();
			GameOverScreen.Setup(score.score, score.highScore);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        var enemy = other.collider.GetComponent<EnemyBehaviour>();
        if (enemy)
        {
            enemy.TakeHit(1);
        }
    }
}
