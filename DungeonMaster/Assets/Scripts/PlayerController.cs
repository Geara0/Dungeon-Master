using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator anim;
    private Vector2 movement;
    private Rigidbody2D rb;

    public float speed;
    public int maxHealth = 10;
    private int currentHealth;
    public HitbarBehaviour healthBar;

    public ProjectileBehaviour projectilePrefab;
    public Transform launchOffset;
    public GameObject videoPlayer;
    public int timeToStop;
    public GameObject objectToDestroy;
	public GameOverScreen GameOverScreen;
	private ScoreManager score;
    public AudioSource footstep;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        videoPlayer.SetActive(false);
        score = GameObject.FindGameObjectsWithTag("LevelManager")[0].GetComponent<ScoreManager>();
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Speed", movement.sqrMagnitude);
    }

    public void TakeHit(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            videoPlayer.SetActive(true);
            Destroy(videoPlayer, timeToStop);
            Destroy(gameObject);
            Destroy(objectToDestroy);
			GameOverScreen.score = score.score;
			GameOverScreen.highScore = score.highScore;
			GameOverScreen.Setup();
        }
    }
	
	public void AddHP(int amount)
	{
		if(currentHealth < maxHealth)
		{
			currentHealth += amount % maxHealth;
			if(currentHealth > maxHealth)
				currentHealth -= currentHealth % maxHealth;
		}
		else
		{
			ScoreManager.instance.AddPoints(10);
		}
		healthBar.SetHealth(currentHealth);	
	}

    public static void GainMoney(int count)
    {
        MoneyManager.Instance.GameMoney += count;
        MoneyManager.Instance.MoneyTxt.text = MoneyManager.Instance.GameMoney.ToString();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * (speed * Time.deltaTime));
    }
	
	private void PlayFootstep()
	{
		footstep.Play();
	}
}