using System.Collections;
using UnityEngine;

public class MasterScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MapGenerator mapGenerator = GetComponent<MapGenerator>();
        mapGenerator.GenerateMap();
    }


}
