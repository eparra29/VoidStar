using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    public GameObject smallExplosion;
    public GameObject smokeParticle;
     
    private void OnCollisionEnter(Collision collision)
    {
        GameObject newSmallExplosion = Instantiate(smallExplosion, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
        GameObject newSmokeParticle = Instantiate(smokeParticle, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
        newSmallExplosion.GetComponent<ParticleSystem>().Play();
        newSmokeParticle.GetComponent<ParticleSystem>().Play();
        Destroy(gameObject);
        Destroy(newSmallExplosion, 1.5f);
        Destroy(newSmokeParticle, 5);
    }
}
