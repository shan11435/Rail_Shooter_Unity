using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private float loadDelay = 1f;
    [SerializeField] private ParticleSystem crashVFX;
    private void OnTriggerEnter(Collider other)
    {
        //this will make the level reload after one sec if the player hits anything
        StartCrashSequence();
    }

    private void StartCrashSequence()
    {
        //plays crash particle effect
        crashVFX.Play();
        GetComponent<BoxCollider>().enabled = false;
        //turns off all player controls
        GetComponent<PlayerControls>().enabled = false;
        Invoke("disappear", 0.5f);
        //it will call the reload level method after 1 second
        Invoke("ReloadLevel", loadDelay);
        
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void disappear()
    {
        gameObject.SetActive(false);
    }

}
