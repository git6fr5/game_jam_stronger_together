using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{

    /* --- Debug --- */
    private string DebugTag = "[SUMMIT FEVER] {HUD}: ";
    private bool DEBUG_init = false;

    /*--- Components ---*/
    public HUDActionButton hudActionButton;
    public HUDRadialHealthBar hudRadialHealthBar;
    public HUDAltitudeBar hudAltitudeBar;
    public CharacterState[] hudCharacters;

    /* --- Internal Variables --- */
    [HideInInspector] public CharacterState currSelection = null;
    [HideInInspector] public bool inAction = false;

    /*--- Unity Methods ---*/
    void Start()
    {
        if (DEBUG_init) { print(DebugTag + "Activated"); }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SelectNext();
        }
        if (currSelection) { print(currSelection.name); }
        Altitude();
    }

    /* --- Methods ---*/
    public void Select(CharacterState characterState)
    {
        Deselect();
        if (characterState) 
        { 
            currSelection = characterState;
            currSelection.selected.enabled = true;
            currSelection.isSelected = true;

            // finds the Camera and sets its focus to this (assumes 1 exists in the scene)
            CameraFocus cameraFocus = GameObject.FindGameObjectsWithTag("MainCamera")[0].GetComponent<CameraFocus>();
            if (!cameraFocus.isBuffering)
            {
                print("hello");
                cameraFocus.Focus(transform);
            }

            cameraFocus.isBuffering = true;
            StartCoroutine(cameraFocus.Buffer(cameraFocus.bufferTime));
        }
    }

    void SelectNext()
    {
        int index = 0;
        for (int i = 0; i < hudCharacters.Length; i++)
        {
            if (hudCharacters[i].gameObject == currSelection)
            {
                index = (i + 1) % hudCharacters.Length;
            }
        }
        Select(hudCharacters[index]);
    }

    void Deselect()
    {
        if (currSelection) 
        {
            currSelection.selected.enabled = false;
            currSelection.isSelected = false;
            currSelection = null;
        }

        inAction = false;
    }


    public void Action()
    {
        inAction = true;
        currSelection.Action();
    }

    void Altitude()
    {
        if (currSelection)
        {
            hudAltitudeBar.altitude = currSelection.depth;
        }
    }
}
