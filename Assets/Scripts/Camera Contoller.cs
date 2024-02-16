using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraContoller : MonoBehaviour
{
    //Assign these in the inspector
    public Camera cameraOne;
    public Camera cameraTwo;

    //Use this to keep track of which camera is currently active
    private bool isCameraOneActive;

    private void Start()
    {
        //Ensure camera one is active and camera two is inactive at start
        if (cameraOne != null && cameraTwo != null)
        {
            cameraOne.enabled = true;
            cameraTwo.enabled = false;
            isCameraOneActive = true;
        }
        else
        {
            Debug.LogError("Cameras not assigned in the CameraSwitcher script");
        }
    }

    private void Update()
    {
        //Check for the 'C' key press
        if (Input.GetKeyDown(KeyCode.C))
        {
            SwitchCamera();
        }
    }

    private void SwitchCamera()
    {
        //Toggle the active state of the cameras
        isCameraOneActive = !isCameraOneActive;

        if (cameraOne != null && cameraTwo != null)
        {
            cameraOne.enabled = isCameraOneActive;
            cameraTwo.enabled = !isCameraOneActive;
        }
    }
}
