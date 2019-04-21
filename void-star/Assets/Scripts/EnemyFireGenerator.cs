using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireGenerator : MonoBehaviour
{
    public GameObject enemyFire;
    public int timeBetweenAttacks = 0;
    private int xPosition;
    private int yPosition;
    private int zPosition;

    void Start()
    {
        GenerateEnemyFire();
    }

    // Start is called before the first frame update
    void Update()
    {

        xPosition = Random.Range(-300, 300);
        yPosition = Random.Range(100, 200);
        zPosition = Random.Range(-300, 300);
        //timeBetweenAttacks += Time.deltaTime;
        if(timeBetweenAttacks >= 50)
        {
            timeBetweenAttacks = 0;
            GenerateEnemyFire();
        }



    }

    // Update is called once per frame
    public void GenerateEnemyFire()
    {
        for(int i = 0; i <= 50; i++)
            Instantiate(enemyFire, new Vector3(xPosition,yPosition, zPosition), Quaternion.identity);

    }
}
