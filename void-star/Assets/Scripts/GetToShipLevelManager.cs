using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GetToShipLevelManager : MonoBehaviour
{
    [SerializeField]
    GameObject tieFighter;

    [SerializeField]
    GameObject tieSilencer;

    [SerializeField]
    GameObject xWing;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt(Utils.AIMING_STYLE) == 0)
        {
            tieFighter.SetActive(true);
        }
        else if(PlayerPrefs.GetInt(Utils.AIMING_STYLE) == 1)
        {
            tieSilencer.SetActive(true);
        }
        else if(PlayerPrefs.GetInt(Utils.AIMING_STYLE) == 2)
        {
            xWing.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
