using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void LoadStartScene()
    {
        SceneManager.LoadScene("STARTSCREEN"); // Replace "START" with your start scene name
    }
}

