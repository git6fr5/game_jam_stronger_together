using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDPortrait : MonoBehaviour
{
    /* --- Debug --- */
    private string DebugTag = "[Entaku Island] {Character Portrait}: ";
    private bool DEBUG_init = false;

    /* --- Components --- */
    public Image portraitImage;
    public Sprite defaultSprite;
    public Text characterName;
    public Image borderImage;

    /* --- Internal Variables --- */

    /*--- Unity Methods ---*/
    void Start()
    {
        if (DEBUG_init) { print(DebugTag + "Activated"); }
        portraitImage.sprite = defaultSprite;
    }

    /*--- Methods ---*/

}
