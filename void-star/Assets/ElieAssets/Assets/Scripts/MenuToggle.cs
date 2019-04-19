using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuToggle : MonoBehaviour
{
    public Animator animator;
    bool menuIsShowing = false;
    public GameObject menuButton;

    public void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if (!menuIsShowing)
            {
                ShowMenu();
                menuIsShowing = true;
            }
            else
            {
                HideMenu();
                menuIsShowing = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
            Application.Quit();
    }


    public void ShowMenu()
    {
        PlayMenuToggleSfx();
        animator.SetBool("ToggleMenuOn", true);
        menuIsShowing = true;
        menuButton.SetActive(false);
    }

    public void HideMenu()
    {
        PlayMenuToggleSfx();
        animator.SetBool("ToggleMenuOn", false);
        menuIsShowing = false;
        StartCoroutine(ShowMenuBars());
    }

    IEnumerator ShowMenuBars()
    {
        yield return new WaitForSeconds(0.7f);
        menuButton.SetActive(true);
    }

    public void PlayMenuToggleSfx()
    {
        gameObject.GetComponent<AudioSource>().Play();
    }
}
