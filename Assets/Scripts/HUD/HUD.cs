using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{

    /* --- Debug --- */
    private string DebugTag = "[Entaku Island] {HUD}: ";
    private bool DEBUG_init = false;

    /*--- Components ---*/
    public HUDMinimap hudMinimap;
    public HUDGameOver hudGameOver;
    public HUDPortrait hudPortrait;

    public Text description;


    public Button actionButton1;

    /* --- Internal Variables --- */
    [HideInInspector] public GameObject currSelection = null;
    [HideInInspector] public bool inAction = false;

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
            characterState.ShowHud(this);
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
                currSelectionState.Deselect();
            }
        }
        this.inAction = false;
        currSelection = null;
        HideHUD();
    }

    public void action1()
    {
        this.inAction = true;
        currSelection.GetComponent<CharacterState>().Action1();
    }



    private void HideHUD()
    {
        actionButton1.gameObject.SetActive(false);
        description.gameObject.SetActive(false);
    }
}
