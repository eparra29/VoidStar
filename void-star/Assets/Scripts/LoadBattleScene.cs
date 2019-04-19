﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadBattleScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartBattleScene());
    }

    IEnumerator StartBattleScene()
    {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene(3);
    }
}
