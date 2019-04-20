using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AimingStyleController : MonoBehaviour
{
    public Sprite[] aminingStyleList = new Sprite[3];
    // Start is called before the first frame update
    void Start()
    {
        Image image = GetComponent<Image>();
        int style = PlayerPrefs.GetInt(Utils.AIMING_STYLE);
        image.sprite = aminingStyleList[style];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
