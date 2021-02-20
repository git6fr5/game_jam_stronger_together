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
    public SpriteRenderer highlight;
    public SpriteRenderer selected;

    public SpriteRenderer spriteRenderer;
    public Sprite portrait;

    public CharacterMovement characterMovement;

    public bool isControllable;

    /* --- Internal Variables --- */
    [HideInInspector] public float maxEnergy = 1f;
    [HideInInspector] public float currEnergy = 1f;

    [HideInInspector] public bool isSelected = false;
    [HideInInspector] public bool isDead = false;

    [HideInInspector] public float depth = 0;

    /*--- Unity Methods ---*/
    void Start()
    {
        if (DEBUG_init) { print(DebugTag + "Activated for " + gameObject.name); }
    }

    void Update()
    {
        MoveFlag();
        depth = transform.position.y + hull.offset.y;
        //print(depth);
    }

    public virtual void OnMouseDown()
    {
        Select();
    }

    public virtual void OnMouseOver()
    {
        Highlight(true);
    }

    public virtual void OnMouseExit()
    {
        Highlight(false);
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

    public virtual void Select()
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

        selected.enabled = true;

        cameraFocus.isBuffering = true;
        StartCoroutine(cameraFocus.Buffer(cameraFocus.bufferTime));

        isSelected = true;
    }

    public virtual void Deselect()
    {
        selected.enabled = false;
        Highlight(false);

        CameraFocus cameraFocus = GameObject.FindGameObjectsWithTag("MainCamera")[0].GetComponent<CameraFocus>();
        cameraFocus.isBuffering = false;

        isSelected = false;
    }

    public void Highlight(bool isHover)
    {
        highlight.enabled = isHover;
    }

    public virtual void Action1()
    {
        return;
    }

    public virtual void ShowHud(HUD hud)
    {
        return;
    }

    void MoveFlag()
    {
        // Get the input from the player

        if (isControllable && isSelected)
        {
            print("running move flag " + gameObject.name);
            characterMovement.horizontalMove = Input.GetAxisRaw("Horizontal");
            characterMovement.verticalMove = Input.GetAxisRaw("Vertical");
        }
    }
}
