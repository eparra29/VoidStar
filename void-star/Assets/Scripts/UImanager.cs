using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    [SerializeField]
    public Text scoreNumber;

    [SerializeField]
    public Text timeNumber;

    public int score;

    public float time = 60;
    
    // Start is called before the first frame update
    void Start()
    {
        timeNumber.text = time.ToString();
        scoreNumber.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        scoreNumber.text = score.ToString();
        timeNumber.text = time.ToString("N0");
        time -= Time.deltaTime; 
    }
}
