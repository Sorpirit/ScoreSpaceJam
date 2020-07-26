using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] private Animator camAnim;

    private bool cameraState = true;

    public void SwitchCameras()
    {
        cameraState = !cameraState;
        camAnim.SetBool("CameraState", cameraState);
    }
}
