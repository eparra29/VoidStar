using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void QuitButton()
    {
        Application.Quit();
    }

    public void CallPlayButton()
    {
        StartCoroutine(PlayButton());
    }

    IEnumerator PlayButton()
    {
        PlayMenuButtonSfx();
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(1);
    }

    public void PlayMenuButtonSfx()
    {
        gameObject.GetComponents<AudioSource>()[0].Play();
    }




}
