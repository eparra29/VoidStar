using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UImanager : MonoBehaviour
{
    [SerializeField]
    public Text scoreNumber;

    [SerializeField]
    public Text timeNumber;

    [SerializeField]
    public Text highScoreNumber;

    [SerializeField]
    public GameObject HighScoreUI;

    [SerializeField]
    public GameObject ScoreUI;

    [SerializeField]
    public GameObject TimeUI;

    [SerializeField]
    public GameObject cockPitImage;

    [SerializeField]
    public GameObject myCamera;

    public int score;

    public float time = 30;

    private int highScore;
    
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

        //end and show high score
        if(time <= 0)
        {
            ScoreUI.SetActive(false);
            TimeUI.SetActive(false);
            cockPitImage.SetActive(false);
            myCamera.GetComponent<ShootController>().enabled = false;
            myCamera.GetComponentInParent<MouseLookController>().enabled = false;
            highScore = score;
            highScoreNumber.text = highScore.ToString();
            HighScoreUI.SetActive(true);
            StartCoroutine(LoadCredits());
        }
    }

    IEnumerator LoadCredits()
    {
        yield return new WaitForSeconds(8.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
