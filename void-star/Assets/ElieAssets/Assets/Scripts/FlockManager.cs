using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockManager : MonoBehaviour
{
    //tutorial has this asfish prefab
    public GameObject tieFighter;
    public int numberOfTieFighters = 13;
    //tutorial refrences this as allLeaders[]
    public List<GameObject> tieFighterSquadron;
    public Vector3 flightLimits = new Vector3(5, 5, 5);
    public Vector3 goalPosition;
    public bool followTheLeaderActivated = false;
    public bool circleTreeActivated = false;
    public bool lazyFlightActivated = true;
    public GameObject leader;

    [Header("Leader Settings")]

    //[Range(0.0f, 15.0f)]
    [SerializeField]
    private float minimumSpeed;
    //[Range(0.0f, 15.0f)]
    [SerializeField]

    private float maximumSpeed;
    [Range(0.0f, 15.0f)]
    public float neighborSpacing;
    [Range(0.0f, 15.0f)]
    public float rotationSpeed;

    // Start is called before the first frame update
    public void Start()
    {
        this.minimumSpeed = 5f;
        this.maximumSpeed = 7f;
        //leader = GameObject.Find("TieSilencer");
        leader.SetActive(false);

        tieFighterSquadron = new List<GameObject>();//size or number of leaders
        for (int i = 0; i < numberOfTieFighters; i++)
        {
            //calculate how close or far in range leader object will appear to its leader manger
            Vector3 position = this.transform.position + new Vector3(Random.Range(-flightLimits.x, flightLimits.x),
                                                                     Random.Range(-flightLimits.y, flightLimits.y),
                                                                     Random.Range(-flightLimits.z, flightLimits.z));

            //this will instantiate and place leader object in calculated position            
            tieFighterSquadron.Add(Instantiate(tieFighter, position, Quaternion.identity) as GameObject) ;
            //linking leader with leader manager
            Flock flock = tieFighterSquadron[i].GetComponent<Flock>();
            flock.flockManager = this;
        }
        goalPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(tieFighterSquadron == null || tieFighterSquadron.Count == 0) {
            Destroy(this.gameObject);
            return;
         }

        if (lazyFlightActivated)
        {
            if (Random.Range(0, 100) < 1)
                goalPosition = this.transform.position + new Vector3(Random.Range(-flightLimits.x - 15, flightLimits.x + 15),Random.Range(-flightLimits.y - 15, flightLimits.y + 15),Random.Range(-flightLimits.z - 15, flightLimits.z + 15));
        }
        else if(followTheLeaderActivated)
            goalPosition = leader.transform.position;

        else if(circleTreeActivated)
            goalPosition = this.transform.position; 
           
    }


    public void LazyFlight()
    {
        leader.SetActive(false);
        followTheLeaderActivated = false;
        circleTreeActivated = false;
        lazyFlightActivated = true;
        this.minimumSpeed = 5f;
        this.maximumSpeed = 7f;
    }

    public void CircleTree()
    {
        lazyFlightActivated = false;
        leader.SetActive(false);
        followTheLeaderActivated = false;
        circleTreeActivated = true;
        this.minimumSpeed = 9f;
        this.maximumSpeed = 11f;
    }


    public void FollowTheLeader()
    {

        lazyFlightActivated = false;
        circleTreeActivated = false;
        leader.SetActive(true);
        followTheLeaderActivated = true;
        this.minimumSpeed = 13f;
        this.maximumSpeed = 15f;
    }



    public float GetMinimumSpeed()
    {
        return this.minimumSpeed;
    }

    public float GetMaximumSpeed()
    {
        return this.maximumSpeed;
    }
}
