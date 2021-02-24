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

    /* --- Internal Variables --- */
    [HideInInspector] public float altitude;
    private float maxAltitude = 1000f;

    /*--- Unity Methods ---*/
    void Start()
    {
        if (DEBUG_init) { print(DebugTag + "Activated"); }
        print("Max Altitude: " + maxAltitude.ToString());
    }

    /*--- Methods ---*/

    void Update()
    {
        print("Altitude: " + altitude.ToString());
    }

}
