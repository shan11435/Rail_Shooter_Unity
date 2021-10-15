using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    //this will call the particle effect once object is destroyed
    [SerializeField] private GameObject deathVFX;
    [SerializeField] private GameObject hitVFX;
    [SerializeField] private int scorePerHit = 15;
    [SerializeField] int health = 10;
    //this calls the scoreboard.cs class
    ScoreBoard scoreBoard;

    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    //this is responsible for when the particles hit something
    private void OnParticleCollision(GameObject other)
    {
        
       ProcessBossHit();
        
        if (health == 0)
        {
          KillBoss();
          stopPlayerAnimation();
        }

    }

    //this will stop the animation, and player moving
    private void stopPlayerAnimation()
    {
        var player = GameObject.FindWithTag("Player");
        player.GetComponent<Animator>().enabled = false;
        var playerMovement = GameObject.FindWithTag("GameController");
        playerMovement.GetComponent<PlayerControls>().enabled = false;
    }

    //this method will react when the laser hits an object
    private void ProcessBossHit()
    {
        //this will make the particle effect appear after object is hit
        Instantiate(hitVFX, transform.position, Quaternion.identity);
        //health system
        health = health - 1; 
        //this is using the method from the scoreboard.cs class
        scoreBoard.IncreaseScore(scorePerHit);  
    }
    
    //this method is responsible for the object being destroyed
    private void KillBoss()
    {
        scoreBoard.IncreaseScore(100);
        //this will search an object with the tag boss in unity inspector
        var go = GameObject.FindWithTag("Boss");
        //this will make the particle effect appear after object is destroyed
        Instantiate(deathVFX, transform.position, Quaternion.identity);
        //it will make object disappear
        Destroy(gameObject);
    }

    
}
