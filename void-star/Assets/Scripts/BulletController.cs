﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject.Find("UImanager").GetComponent<UImanager>().score++;
        GameObject.Find("BattleSfx").GetComponents<AudioSource>()[2].Play();
        Destroy(gameObject);
    }
}
