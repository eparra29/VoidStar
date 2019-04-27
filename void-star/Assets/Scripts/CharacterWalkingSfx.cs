using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWalkingSfx : MonoBehaviour
{
    private bool isWalking = false;
    private bool isRunning = false;
    private bool movedBefore = false;


    // Update is called once per frame
    void Update()
    {


        if ((Input.GetButton("Horizontal") || Input.GetButton("Vertical")) && Input.GetButton("Shift"))     
        {

            if (!isRunning)
            {
                gameObject.GetComponents<AudioSource>()[0].Pause();
                gameObject.GetComponents<AudioSource>()[1].Play();
            }

            movedBefore = true;
            isWalking = false;
            isRunning = true;
        }
        else if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {

            if (!isWalking)
            {
                gameObject.GetComponents<AudioSource>()[1].Pause();
                gameObject.GetComponents<AudioSource>()[0].Play();
            }

            movedBefore = true;
            isRunning = false; 
            isWalking = true;
        }
        if ((Input.GetButtonUp("Horizontal") || Input.GetButtonUp("Vertical")) && movedBefore)
        {

            gameObject.GetComponents<AudioSource>()[0].Pause();
            gameObject.GetComponents<AudioSource>()[1].Pause();
            isWalking = false;
            isRunning = true;
        }


       
    } 

}
