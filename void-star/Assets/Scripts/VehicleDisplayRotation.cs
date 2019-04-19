using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleDisplayRotation : MonoBehaviour
{
    [SerializeField]
    public float rotationSpeed = 30f;
    

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);  
    }
} 