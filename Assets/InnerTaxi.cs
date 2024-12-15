using UnityEngine;
using UnityEngine.SceneManagement;

public class TaxiCollisionChecker : MonoBehaviour
{
    private Collider[] colliders;    // Array to store the 4 colliders
    private bool[] isColliding;     // Array to track collision states for each collider

    void Start()
    {
        // Step 1: Access the 4 colliders directly from the GameObject
        colliders = GetComponents<Collider>();
        if (colliders.Length < 4)
        {
            Debug.LogError("This GameObject does not have 4 colliders!");
            return;
        }

        // Step 2: Initialize the collision tracking array
        isColliding = new bool[colliders.Length];
    }

    void OnCollisionEnter(Collision collision)
    {
        // Step 3: Check for collision against objects starting with "COLLIDER"
        for (int i = 0; i < colliders.Length; i++)
        {
            if (collision.contacts[0].thisCollider == colliders[i] &&
                collision.gameObject.name.StartsWith("COLLIDER"))
            {
                isColliding[i] = true; // Mark this collider as colliding
            }
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // Reset the collision state when the object exits collision
        for (int i = 0; i < colliders.Length; i++)
        {
            if (collision.contacts[0].thisCollider == colliders[i] &&
                collision.gameObject.name.StartsWith("COLLIDER"))
            {
                isColliding[i] = false; // Mark this collider as not colliding
            }
        }
    }

    void Update()
    {
        // Step 4: Check if any of the colliders are not colliding with "COLLIDER" objects
        foreach (bool isCurrentlyColliding in isColliding)
        {
            if (!isCurrentlyColliding)
            {
                Debug.Log("Collision check failed! Loading Game Over scene...");
                SceneManager.LoadScene("GameOver");
                return; // Exit after loading the scene
            }
        }
    }
}
