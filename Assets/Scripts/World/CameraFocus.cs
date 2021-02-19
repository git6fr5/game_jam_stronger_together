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


   /* void LateUpdate()
    {
        // if nothing was selected, then move camera to the position
        if (Input.GetMouseButtonDown(0) && !isBuffering)
        {
            //print("Empty Focus");
            //emptyFocus.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Focus(emptyFocus);

            HUD hud = GameObject.FindGameObjectsWithTag("HUD")[0].GetComponent<HUD>();
            hud.Inspect(null);
        }

        if (!isBuffering)
        {
            float xAxisValue = Input.GetAxis("Horizontal") * Speed;
            float yAxisValue = Input.GetAxis("Vertical") * Speed;
            Vector3 newPos = new Vector3(transform.position.x + xAxisValue, transform.position.y + yAxisValue, -10);

            transform.position = newPos;
            emptyFocus.position = newPos;
        }
      
    }
        */

    /* --- Methods ---*/
    public void Focus(Transform _focus)
    {
        virtualCamera.enabled = true;
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
