using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LevelSelect : MonoBehaviour
{
    /* --- Debug --- */
    private string DebugTag = "[SUMMIT FEVER] {LevelSelect}: ";
    private bool DEBUG_init = false;

    /* --- Components --- */


    /*--- Unity Methods ---*/
    void Start()
    {
        if (DEBUG_init) { print(DebugTag + "Activated"); }
    }

    /* --- Methods --- */
    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName, LoadSceneMode.Single);
    }
}
