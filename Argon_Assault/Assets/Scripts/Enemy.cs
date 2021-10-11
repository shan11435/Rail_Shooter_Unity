using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //this will call the particle effect once object is destroyed
    [SerializeField] private GameObject deathVFX;
    [SerializeField] private GameObject hitVFX;
    [SerializeField] private int scorePerHit = 15;
    [SerializeField] int hitpoints = 30;
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
        /*
        this is used to make sure the lazer know's it's hitting the enemy
        if (other.CompareTag("HitMarker"))
        {
            StartCoroutine(TouchedLava());
        }
        */
        if (hitpoints == 0)
        {
          KillEnemy();
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
        hitpoints = hitpoints - 1; 
        //this is using the method from the scoreboard.cs class
        scoreBoard.IncreaseScore(scorePerHit);  
    }
    
    //this method is responsible for the object being destroyed
    private void KillEnemy()
    {
        var go = GameObject.FindWithTag("Boss");
        //this will make the particle effect appear after object is destroyed
        Instantiate(deathVFX, transform.position, Quaternion.identity);
        //it will make object disappear
        Destroy(go);
    }

    
}
