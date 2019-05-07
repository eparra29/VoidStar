using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float timer;
    public Image healthbar;


    // Start is called before the first frame update
    void Start()
    {

        health = 100;
        timer = 8;
    }

    // Update is called once per frame
    void Update()
    {
       
        timer -= 1 * Time.deltaTime;
        if (timer < 0)
        {
            health = health - 15;
            DepleteHealth();
            timer = 8;
        }

        if (health <= 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);

    }

    public void DepleteHealth()
    {

        healthbar.GetComponent<Image>().fillAmount = health / 100;
        
    }


}
