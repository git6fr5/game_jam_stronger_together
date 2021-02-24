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
    public Transform emptyFocus;


    /*--- Internal Variables ---*/
    [HideInInspector] public float bufferTime = 0.1f;
    [HideInInspector] public bool isBuffering = false;
    private const float Speed = 0.0075f;


    /*--- Unity Methods ---*/
    void Start()
    {
        if (DEBUG_init) { print(DebugTag + "Activated"); }
    }

    /* --- Methods ---*/
    public void Focus(Transform _focus)
    {
        virtualCamera.m_Follow = _focus;
        isBuffering = true;
        StartCoroutine(Buffer(bufferTime));
    }

    // so that there is some buffer time to control for misclicks
    public IEnumerator Buffer(float elapsedTime)
    {
        yield return new WaitForSeconds(elapsedTime);

        isBuffering = false;

        yield return null;

    }
}
