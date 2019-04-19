using System;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class MouseLookController : MonoBehaviour
{
    [SerializeField] private MouseLook mouseLook;
    // Start is called before the first frame update
    void Start()
    {
        mouseLook.Init(transform, Camera.main.transform);

    }

    // Update is called once per frame
    void Update()
    {
        mouseLook.LookRotation(transform, Camera.main.transform);
    }

    private void FixedUpdate()
    {
        mouseLook.UpdateCursorLock();
    }
}
