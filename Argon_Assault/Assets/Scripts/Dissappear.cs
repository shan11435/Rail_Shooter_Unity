using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissappear : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //makes the rocket dissappear
        GetComponent<MeshRenderer>().enabled = false;
    }
}
