﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{

    /* --- Debug --- */
    private string DebugTag = "[Entaku Island] {HUD}: ";
    private bool DEBUG_init = false;

    /*--- Components ---*/
    public HUDMinimap hudMinimap;
    public HUDGameOver hudGameOver;
    public HUDPortrait hudPortrait;

    /*--- Unity Methods ---*/
    void Start()
    {
        if (DEBUG_init) { print(DebugTag + "Activated"); }
    }

    /* --- Methods ---*/
    public void Inspect(CharacterState characterState)
    {
        
    }
}
