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

    public GameObject healthBar;

    /* --- Internal Variables --- */
    [HideInInspector] public float maxEnergy = 1f;
    [HideInInspector] public float currEnergy = 1f;

    [HideInInspector] public bool isSelected = false;
    [HideInInspector] public bool isDead = false;

    [HideInInspector] public float depth = 0;

    public float oxy = 100f;
    public static float BASE_DRAIN_RATE = 0.2f;
    [HideInInspector] public float oxyDrainRate = BASE_DRAIN_RATE;

    /*--- Unity Methods ---*/
    void Start()
    {
        if (DEBUG_init) { print(DebugTag + "Activated for " + gameObject.name); }
    }

    void Update()
    {
        MoveFlag();
    }

    void FixedUpdate()
    {
        OxyDrain();
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
    public virtual void Select()
    {
        // find HUD and activate the HUD inspect method on this object (assumes 1 exists in the scene)
        HUD hud = GameObject.FindGameObjectsWithTag("HUD")[0].GetComponent<HUD>();
        hud.Select(this);
    }

    public void Highlight(bool isHover)
    {
        highlight.enabled = isHover;
    }

    void MoveFlag()
    {
        // Get the input from the player
        if (isControllable && isSelected)
        {
            characterMovement.horizontalMove = Input.GetAxisRaw("Horizontal");
            characterMovement.verticalMove = Input.GetAxisRaw("Vertical");
        }

        if (hull) { depth = transform.position.y + hull.offset.y; }
    }

    public void SetOxyDrain(float drainRate)
    {
        if (drainRate < 0)
        {
            oxyDrainRate = BASE_DRAIN_RATE;
            return;
        }
        oxyDrainRate = drainRate;
    }

    void OxyDrain()
    {
        oxy -= oxyDrainRate * Time.fixedDeltaTime;
        if (oxy < 0)
        {
            oxy = 0;
            isDead = true;
        }
    }

    public virtual void Action()
    {
        // mostly action 1, but sometimes might be action 2
    }

    public virtual void Action1()
    {
        return;
    }

    public virtual void Action2()
    {
        return;
    }
}
