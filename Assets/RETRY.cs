using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management

public class MainGameButton : MonoBehaviour
{
    public void LoadMainGameScene()
    {
        SceneManager.LoadScene("MAIN GAME"); // Replace "MAIN_GAME" with your main game scene name
    }
}
