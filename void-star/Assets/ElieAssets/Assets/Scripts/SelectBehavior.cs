using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectBehavior : MonoBehaviour
{
    FlockManager flockManager;
    


    void Start()
    {
        flockManager = GameObject.Find("FlockManager").GetComponent<FlockManager>();
    }

    public void CallLazyFlight()
    {
        PlayPressButtonSound();
        flockManager.LazyFlight();
    }

    public void CallCircleATree()
    {
        PlayPressButtonSound();
        flockManager.CircleTree();
    }

    public void CallFollowTheLeader()
    {
        PlayPressButtonSound();
        flockManager.FollowTheLeader();
    }

    public void QuitGame()
    {
        PlayPressButtonSound();
        Application.Quit();
    }

    public void PlayPressButtonSound()
    {
        gameObject.GetComponent<AudioSource>().Play();
    }




}
