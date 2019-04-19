using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VehicleSelection : MonoBehaviour
{

    public GameObject[] vehicles;
    public GameObject[] vehicleBackgroundImages;
    private int showIndex, hideIndex = 0;
    // Start is called before the first frame update
    void Start()
    {

        //initializing the vehicle models
        vehicles = new GameObject[3];
        vehicles[0] = GameObject.Find("TieFighter");
        vehicles[1] = GameObject.Find("TieSilencer");
        vehicles[2] = GameObject.Find("X-Wing");
        //displaying only the first of the 3 vehicles
        vehicles[1].SetActive(false);
        vehicles[2].SetActive(false);

        //initializing the background images
        vehicleBackgroundImages = new GameObject[3];
        vehicleBackgroundImages[0] = GameObject.Find("TieFighterImage");
        vehicleBackgroundImages[1] = GameObject.Find("TieSilencerImage");
        vehicleBackgroundImages[2] = GameObject.Find("X-WingImage");
        //displaying only the first of the 3 bgimages corresponding to its matching vehicle
        vehicleBackgroundImages[1].SetActive(false);
        vehicleBackgroundImages[2].SetActive(false);
    }


    public void PreviousVehicle()
    {
        hideIndex = showIndex;
        if (showIndex == 0)
            showIndex = 2;
        else
            showIndex--;

        PlayVehicleSelectionButtonSfx();
        DisplayVehicle();
        DisplayBgImage();
    }

    public void NextVehicle()
    {

        hideIndex = showIndex;
        if (showIndex == 2)
            showIndex = 0;
        else
            showIndex++;

        PlayVehicleSelectionButtonSfx();
        DisplayVehicle();
        DisplayBgImage();
    }

    public void DisplayVehicle()
    {
        vehicles[hideIndex].SetActive(false);
        vehicles[showIndex].SetActive(true);
    }
    public void DisplayBgImage()
    {
        vehicleBackgroundImages[hideIndex].SetActive(false);
        vehicleBackgroundImages[showIndex].SetActive(true);
    }

    public void SelectVehicle()
    {
        PlayVehicleSelectionButtonSfx();
        StartCoroutine(GoToBattleScene());
    }

    public void PlayVehicleSelectionButtonSfx()
    {
        gameObject.GetComponents<AudioSource>()[0].Play();
    }

    IEnumerator GoToBattleScene()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(2);
    }
}
