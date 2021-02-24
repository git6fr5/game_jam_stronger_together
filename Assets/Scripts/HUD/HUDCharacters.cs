using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDCharacters : MonoBehaviour
{
    /* --- Debug --- */
    private string DebugTag = "[SUMMIT FEVER] {HUDCharacters}: ";
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
