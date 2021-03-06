﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WorldRenderer : MonoBehaviour
{
    /* --- Debug --- */
    private string DebugTag = "[K2] {WorldRenderer}: ";
    private bool DEBUG_init = true;

    /*--- Components ---*/


    private static List<GameObject> characters = new List<GameObject>();
    private static string[] sortTags = new string[] { "SnowBlock", "SnowDigger", "Climber" };

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
        characters = new List<GameObject>();

        foreach (string _tag in sortTags)
        {
            GameObject[] _gameObjectArray = GameObject.FindGameObjectsWithTag(_tag);
            foreach (GameObject _gameObject in _gameObjectArray)
            {
                characters.Add(_gameObject);
            }
        }
        List<CharacterState> characterStates = new List<CharacterState>();
        List<float> characterDepths = new List<float>();

        // There is no need to sort if there is less than two characters
        if (characters.Count < 2) { return; }

        // Itterate through the rest of the list
        for (int i = 0; i < characters.Count; i++)
        {
            CharacterState characterState = characters[i].GetComponent<CharacterState>();
            characterDepths.Add(characterState.depth);
        }

        while (characterDepths.Count > 0)
        {
            for (int i = 0; i < characters.Count; i++)
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