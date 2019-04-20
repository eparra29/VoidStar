using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireGenerator : MonoBehaviour
{
    public GameObject enemyFire;
    float timeBetweenAttacks = 0;

    // Start is called before the first frame update
    void Update()
    {
        timeBetweenAttacks += Time.deltaTime;
        if(timeBetweenAttacks > 1)
        {
            timeBetweenAttacks = 0;
            GenerateEnemyFire();
        }

    }

    // Update is called once per frame
    public void GenerateEnemyFire()
    {
        Instantiate(enemyFire, new Vector3(Random.Range(-200,200), 200, Random.Range(-200,200)), Quaternion.identity);
    }
}
