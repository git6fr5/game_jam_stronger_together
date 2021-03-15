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
    public HUDRadialHealthBar hudRadialHealthBar;
    public HUDAltitudeBar hudAltitudeBar;
    public CharacterState[] hudCharacters;
    public Slider hudActionBar;
    public Button hudActionButton;
    public Slider[] hudHealthBars;
    public Button hudPauseButton;
    public GameObject hudPauseMenu;

    /* --- Internal Variables --- */
    [HideInInspector] public CharacterState currSelection = null;
    [HideInInspector] public bool inAction = false;
    private bool isPaused = false;

    /*--- Unity Methods ---*/
    void Start()
    {
        if (DEBUG_init) { print(DebugTag + "Activated"); }
        InitHealth();
        Select(hudCharacters[0]);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SelectNext();
        }
        UpdateAltitude();
        UpdateHealth();
    }

    /* --- Methods ---*/
    public void Select(CharacterState characterState)
    {
        if (isPaused) { return; }

        Deselect();
        if (characterState) 
        { 
            currSelection = characterState;
            currSelection.selected.enabled = true;
            currSelection.isSelected = true;

            // finds the Camera and sets its focus to this (assumes 1 exists in the scene)
            CameraFocus cameraFocus = GameObject.FindGameObjectsWithTag("MainCamera")[0].GetComponent<CameraFocus>();
            cameraFocus.Focus(currSelection.transform);

        }
    }

    void SelectNext()
    {
        if (isPaused) { return; }

        int index = 0;
        for (int i = 0; i < hudCharacters.Length; i++)
        {
            if (hudCharacters[i] == currSelection)
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
        if (isPaused) { return; }

        inAction = true;
        currSelection.Action();
    }

    void UpdateAltitude()
    {
        if (currSelection)
        {
            hudAltitudeBar.altitude = currSelection.depth;
        }
    }

    void InitHealth()
    {
        // assumes there are atleast as many characters as health bars
        // can be more characters than health bars though
        for (int i = 0; i < hudHealthBars.Length; i++)
        {
            hudHealthBars[i].maxValue = CharacterState.MAX_OXY;
        }
        hudActionBar.maxValue = CharacterState.MAX_OXY;
    }

    void UpdateHealth()
    {
        // assumes there are atleast as many characters as health bars
        // can be more characters than health bars though
        for (int i = 0; i < hudHealthBars.Length; i++) 
        {
            hudHealthBars[i].value = hudCharacters[i].oxy;
        }
        if (currSelection) { hudActionBar.value = currSelection.oxy; }
        else { hudActionBar.value = 0f; }
    }

    public void Pause()
    {
        if (!hudPauseMenu.activeSelf)
        {
            hudPauseMenu.SetActive(true);
            isPaused = true;
            Time.timeScale = 0;
        }
        else
        {
            hudPauseMenu.SetActive(false);
            isPaused = false;
            Time.timeScale = 1;
        }
    }
}
