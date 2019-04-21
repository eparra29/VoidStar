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
    
    // Start is called before the first frame update
    void Start()
    {
        scoreNumber.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        scoreNumber.text = score.ToString();
    }
}
