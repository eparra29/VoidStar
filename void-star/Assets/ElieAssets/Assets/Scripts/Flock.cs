using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flock : MonoBehaviour
{
    public FlockManager flockManager;
    float speed;
    bool reachedFlightLimit = false;
    GameObject smallExplosion;




    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(flockManager.GetMinimumSpeed(), flockManager.GetMaximumSpeed());
        smallExplosion = GameObject.Find("SmallExplosionEffect");


    }

    // Update is called once per frame
    void Update()
    {
        speed = Random.Range(flockManager.GetMinimumSpeed(), flockManager.GetMaximumSpeed());

        //Gather tie fighters that have left the flock code was working well before this snippet==============
        Bounds bound = new Bounds(flockManager.transform.position, flockManager.flightLimits * 2);
        if (!bound.Contains(transform.position))
            reachedFlightLimit = true;
        else
            reachedFlightLimit = false;

        if (reachedFlightLimit)
        {
            Vector3 direction = flockManager.transform.position - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), flockManager.rotationSpeed * Time.deltaTime);

            ApplyRules();
        }
        
       
            //speed = Random.Range(flockManager.GetMinimumSpeed(), flockManager.GetMaximumSpeed());
            ApplyRules();

        //====================================================================================================

       
        transform.Translate(0, 0, Time.deltaTime * speed);
    }

    void ApplyRules()
    {

        speed = Random.Range(flockManager.GetMinimumSpeed(), flockManager.GetMaximumSpeed());
        List<GameObject> currentLeaderSquadron;
        currentLeaderSquadron = flockManager.tieFighterSquadron;

        Vector3 averageCenter = Vector3.zero;
        Vector3 averageSpacing = Vector3.zero;
        float globalSpeed = 0.01f;
        float neighborDistance;
        int squadronSize = 0;

        foreach (GameObject currentTieFighter in currentLeaderSquadron)
        {

            if (currentTieFighter != this.gameObject)
            {
                neighborDistance = Vector3.Distance(currentTieFighter.transform.position, this.transform.position);
                if (neighborDistance <= flockManager.neighborSpacing)
                {
                    averageCenter += currentTieFighter.transform.position;
                    squadronSize++;

                    if (neighborDistance < 4f)
                        averageSpacing = averageSpacing + (this.transform.position - currentTieFighter.transform.position);

                    Flock anotherTieFighter = currentTieFighter.GetComponent<Flock>();
                    globalSpeed = globalSpeed + anotherTieFighter.speed;
                }
            }
        }

        if (squadronSize > 0)
        {
            averageCenter = averageCenter/squadronSize + (flockManager.goalPosition - this.transform.position);
            //speed = globalSpeed/squadronSize;

            Vector3 direction = (averageCenter + averageSpacing) - transform.position;
            if (direction != Vector3.zero)
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), flockManager.rotationSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "LaserBullet")
        {

            smallExplosion.transform.position = new Vector3((float)collision.transform.position.x, (float)collision.transform.position.y, (float)collision.transform.position.z);
            flockManager.tieFighterSquadron.Remove(this.gameObject);
            Destroy(this.gameObject);
            GameObject newExplosion = Instantiate(GameObject.Find("SmallExplosionEffect"), smallExplosion.transform.position, Quaternion.identity);
            newExplosion.GetComponent<ParticleSystem>().Play();
            Destroy(newExplosion, 1.5f);
        }
    }
}
