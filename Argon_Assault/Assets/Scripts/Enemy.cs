using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //this is responsible for when the particles hit something
    private void OnParticleCollision(GameObject other)
    {
        //it will make object disappear
        Destroy(gameObject);
    }
}
