using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    //this allows you to control how fast the player moves in unity editor
    [SerializeField] float controlSpeed = 10f;
    [SerializeField] private float xRange = 5f;
    [SerializeField] private float yRange = 5f;
    [SerializeField] private float negYRange = -7f;
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    private void ProcessRotation()
    {
        transform.localRotation = Quaternion.Euler(-30f, 30f, 0f);
    }

    private void ProcessTranslation()
    {
        //this makes the player move when pressing left or right key or A or D key
        float xThrow = Input.GetAxis("Horizontal");
        //this makes the player move when pressing up or down keys or W or S keys
        float yThrow = Input.GetAxis("Vertical");

        //this line makes the player move left or right when pressing the xThrow keys
        float xOffset = xThrow * Time.deltaTime * controlSpeed;
        //transform.localPosition means where you currently are in the world
        float rawXPos = transform.localPosition.x + xOffset;
        //this will cause the rocket to not go off the screen
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);
        //this line makes the player move up or down when pressing the yThrow keys
        float yOffset = yThrow * Time.deltaTime * controlSpeed;
        //transform.localPosition means where you currently are in the world
        float rawYPos = transform.localPosition.y + yOffset;
        //this will cause the rocket to not go off the screen
        float clampedYPos = Mathf.Clamp(rawYPos, negYRange, yRange);
        
        //this is responsible for moving the player object
        //Vector3 is used if your making a 3d game
        //Vector2 is used to make 2d games
        transform.localPosition = new Vector3 (clampedXPos, clampedYPos, transform.localPosition.z);
    }
}
