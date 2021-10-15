using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //this will call the particle effect once object is hit with laser
    [SerializeField] private GameObject hitVFX;
    [SerializeField] private int scorePerHit = 15;
    [SerializeField] int hitpoints = 2;
    //this calls the scoreboard.cs class
    ScoreBoard scoreBoard;

    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    //this is responsible for when the particles hit something
    private void OnParticleCollision(GameObject other)
    {
        
        ProcessHit();
        
        if (hitpoints == 0)
        {
            KillEnemy();
        }

    }

    //this method will react when the laser hits an object
    private void ProcessHit()
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
        //it will make object disappear
        Destroy(gameObject);
    }

    
}