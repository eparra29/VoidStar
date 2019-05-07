using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameComplete : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
