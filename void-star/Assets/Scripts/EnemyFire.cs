using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    public GameObject smallExplosion;
    public GameObject smokeParticle;
     
    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(smallExplosion, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
        Instantiate(smokeParticle, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
        Destroy(gameObject);
        GameObject.Find("EnemyFireGenerator").GetComponent<EnemyFireGenerator>().timeBetweenAttacks++;

    }
}
