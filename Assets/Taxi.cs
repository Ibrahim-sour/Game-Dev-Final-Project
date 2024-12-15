using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TaxiMovement : MonoBehaviour
{
    public float moveSpeed = 5f;          // Base movement speed
    public float accelerationMultiplier = 2f; // Speed multiplier when accelerating
    public float rotationSpeed = 100f;   // Rotation speed
    private bool isDriveGear = true;     // True for drive, false for reverse

    void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object's name starts with "COLLIDER"
        if (collision.gameObject.name.StartsWith("COLLIDER"))
        {
            Debug.Log("Collision detected with object: " + collision.gameObject.name);
            // Load the GameOver scene
            SceneManager.LoadScene("GameOver");
        }
    }

    void FixedUpdate()
    {
        // Toggle between Drive and Reverse gears using the Space key
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            isDriveGear = !isDriveGear;
        }*/

        // Determine current speed based on gear and acceleration
        float currentSpeed = moveSpeed;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed *= accelerationMultiplier; // Accelerate when Shift is held
        }

        // Move the taxi forward or backward based on the current gear
        if (Input.GetKey(KeyCode.UpArrow))
        {
            float direction = isDriveGear ? 1 : -1; // Forward for drive, backward for reverse
            transform.Translate(Vector3.forward * currentSpeed * direction * Time.deltaTime);
        }

        // Rotate the taxi left or right
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }

    }

    void Update()
    {
        // Toggle between Drive and Reverse gears using the Space key
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isDriveGear = !isDriveGear;
        }
    }



}

