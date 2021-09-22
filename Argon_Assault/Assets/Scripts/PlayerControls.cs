using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    //this allows you to control how fast the player moves in unity editor
    [SerializeField] float controlSpeed = 10f;
    //this allows you to control how much the player can appear in the x-axis screen
    [SerializeField] private float xRange = 5f;
    //this allows you to control how much the player can appear in the y-axis screen
    [SerializeField] private float yRange = 5f;
    //this allows you to control how much the player can appear in the -y-axis screen
    [SerializeField] private float negYRange = -7f;

    //this controls the rotation ability for the object
    [SerializeField] private float positionPitchFactor = -2f;
    [SerializeField] private float positionYawFactor = 5f;
    [SerializeField] private float controlPitchFactor = -10f;
    [SerializeField] private float controlRollFactor = -20f;

    float xThrow, yThrow;
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();
    }

  

    private void ProcessRotation()
    {
        //transform.localPosition shows where the object is in the world.
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        
        
        float pitch = pitchDueToPosition + pitchDueToControlThrow;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;
        
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation()
    {
        //this makes the player move when pressing left or right key or A or D key
        xThrow = Input.GetAxis("Horizontal");
        //this makes the player move when pressing up or down keys or W or S keys
        yThrow = Input.GetAxis("Vertical");

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
    void ProcessFiring()
    {
        //if we're pushing a fire button, then print shooting, else don't print shooting
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("shooting");
        }
    }
}
