using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSelectionButtonSfx : MonoBehaviour
{

     public void PlayVehicleSelectionButtonSfx()
    {
        gameObject.GetComponents<AudioSource>()[0].Play();
    }
}
