using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WorldRenderer : MonoBehaviour
{
    /* --- Debug --- */
    private string DebugTag = "[Entaku Island] {WorldRenderer}: ";
    private bool DEBUG_init = false;

    /*--- Components ---*/

    /* --- Stats --- */

    /*--- Unity Methods ---*/
    void Start()
    {
        if (DEBUG_init) { print(DebugTag + "Activated"); }
    }

    void Update()
    {
        MinimumSort();
    }

    void OnMouseDown()
    {
    }

    /* --- Methods --- */
    // imported from another 2D project

    public static void MinimumSort()
    {
        // Declare the object array and the array of sorted characters
        GameObject[] characters = GameObject.FindGameObjectsWithTag("Character");
        List<CharacterState> characterStates = new List<CharacterState>();
        List<float> characterDepths = new List<float>();

        // There is no need to sort if there is less than two characters
        if (characters.Length < 2) { return; }

        // Itterate through the rest of the list
        for (int i = 0; i < characters.Length; i++)
        {
            CharacterState characterState = characters[i].GetComponent<CharacterState>();
            characterDepths.Add(characterState.depth);
        }

        while (characterDepths.Count > 0)
        {
            for (int i = 0; i < characters.Length; i++)
            {
                CharacterState characterState = characters[i].GetComponent<CharacterState>();
                if (characterState.depth == characterDepths.Max())
                {
                    characterStates.Add(characterState);
                    characterDepths.Remove(characterDepths.Max());
                    if (characterDepths.Count == 0) { break; }
                }
            }
        }

        for (int i = 0; i < characterStates.Count; i++)
        {
            //print(characterStates[i].name + ", " + i.ToString());
            characterStates[i].spriteRenderer.sortingOrder = i;
        }
    }

}