using UnityEngine;
using UnityEngine.SceneManagement; // Required to manage scenes

public class EscapeToStart : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // Check if the Escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Load the Start screen scene
            SceneManager.LoadScene("STARTSCREEN");
        }
    }
}
