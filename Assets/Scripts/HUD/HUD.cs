using System.Collections;
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

    /* --- Internal Variables --- */
    [HideInInspector] public GameObject currSelection;

    /*--- Unity Methods ---*/
    void Start()
    {
        if (DEBUG_init) { print(DebugTag + "Activated"); }
    }

    /* --- Methods ---*/
    public void Inspect(CharacterState characterState)
    {
        Deselect();

        if (characterState)
        {
            print("Inspecting Character");
            currSelection = characterState.gameObject;
            hudPortrait.portraitImage.sprite = characterState.portrait;
            return;
        }
        hudPortrait.portraitImage.sprite = hudPortrait.defaultSprite;
    }

    public void Deselect()
    {
        if (currSelection)
        {
            if (currSelection.GetComponent<CharacterState>())
            {
                CharacterState currSelectionState = currSelection.GetComponent<CharacterState>();
                currSelectionState.selected.enabled = false;
                currSelectionState.Highlight(false);
            }
        }
    }
}
