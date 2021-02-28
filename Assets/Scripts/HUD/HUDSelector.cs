using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDSelector : MonoBehaviour
{
    /* --- Debug --- */
    private string DebugTag = "[SUMMIT FEVER] {HUDSelector}: ";
    private bool DEBUG_init = false;

    /* --- Components --- */


    /* --- Internal Variables --- */

    /*--- Unity Methods ---*/
    void Start()
    {
        if (DEBUG_init) { print(DebugTag + "Activated"); }
    }

    /*--- Methods ---*/

}

