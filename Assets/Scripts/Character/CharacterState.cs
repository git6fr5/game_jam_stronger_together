using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterState : MonoBehaviour
{
    /* --- Debug --- */
    private string DebugTag = "[K2] {CharacterState}: ";
    private bool DEBUG_init = false;

    /*--- Components ---*/
    public Collider2D hitbox;
    public Collider2D hull;
    public SpriteRenderer spriteRenderer;

    /* --- Internal Variables --- */
    public Sprite portrait;

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
        // Find HUD and activate the HUD inspect method on this object
    }
}
