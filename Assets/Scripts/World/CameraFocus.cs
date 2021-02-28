using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

// used to control the camera focus in the scene
public class CameraFocus : MonoBehaviour
{
    /* --- Debug --- */
    private string DebugTag = "[K2] {Camera}: ";
    private bool DEBUG_init = false;

    /*--- Components ---*/
    public CinemachineVirtualCamera virtualCamera;

    /*--- Internal Variables ---*/

    /*--- Unity Methods ---*/
    void Start()
    {
        if (DEBUG_init) { print(DebugTag + "Activated"); }
    }

    /* --- Methods ---*/
    public void Focus(Transform _focus)
    {
        virtualCamera.m_Follow = _focus;
        virtualCamera.m_LookAt = _focus;

    }
}
