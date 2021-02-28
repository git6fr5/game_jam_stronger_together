using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDAltitudeBar : MonoBehaviour
{
    /* --- Debug --- */
    private string DebugTag = "[SUMMIT FEVER] {HUDAltitudeBar}: ";
    private bool DEBUG_init = false;

    /* --- Components --- */
    public RectTransform altitudeBar;
    public RectTransform altitudeIndicator;

    /* --- Internal Variables --- */
    [HideInInspector] public float altitude;
    private float maxAltitude = 100f;

    /*--- Unity Methods ---*/
    void Start()
    {
        if (DEBUG_init) { print(DebugTag + "Activated"); }
        print("Max Altitude: " + maxAltitude.ToString());
    }

    /*--- Methods ---*/

    void Update()
    {
        //Debug.Log(DebugTag + "Altitude: " + altitude.ToString());

        if (altitude < 0) { altitude = 0; }

        float altitudeScaled = altitude / maxAltitude * altitudeBar.rect.height;
        altitudeIndicator.anchoredPosition = new Vector2( 0, altitudeScaled);
    }

}
