using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// used only to store and information values about the character
public class CharacterState : MonoBehaviour
{
    /* --- Debug --- */
    private string DebugTag = "[K2] {CharacterState}: ";
    private bool DEBUG_init = false;

    /*--- Components ---*/
    public Collider2D hitbox;
    public Collider2D hull;
    public SpriteRenderer spriteRenderer;
    public Sprite portrait;

    /* --- Internal Variables --- */
    [HideInInspector] public float maxEnergy = 1f;
    [HideInInspector] public float currEnergy = 1f;

    [HideInInspector] public bool isDead = false;

    /*--- Unity Methods ---*/
    void Start()
    {
        if (DEBUG_init) { print(DebugTag + "Activated for " + gameObject.name); }
    }

    void OnMouseDown()
    {
        Select();
    }

    /*--- Methods ---*/
    public void UseEnergy(float energy)
    {
        currEnergy = currEnergy - energy;
        if (currEnergy < 0)
        {
            isDead = true;
        }
    }

    public void Select()
    {
        // find HUD and activate the HUD inspect method on this object (assumes 1 exists in the scene)
        HUD hud = GameObject.FindGameObjectsWithTag("HUD")[0].GetComponent<HUD>();
        hud.Inspect(this);

        // finds the Camera and sets its focus to this (assumes 1 exists in the scene)
        CameraFocus cameraFocus = GameObject.FindGameObjectsWithTag("MainCamera")[0].GetComponent<CameraFocus>();
        if (!cameraFocus.isBuffering)
        {
            cameraFocus.Focus(transform);
        }

        cameraFocus.isBuffering = true;
        StartCoroutine(cameraFocus.Buffer(cameraFocus.bufferTime));
    }
}
