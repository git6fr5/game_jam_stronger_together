using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnowBlock : CharacterState
{

    HUD hud;
    public bool hasRope = false;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.tag = "SnowBlock";
        hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
    }


    public override void OnMouseDown()
    {
        if (!hud.inAction)
        {
            Select();
        }
    }

    public override void OnMouseOver()
    {
        if (!hud.inAction)
        {
            Highlight(true);
        }
    }

    public override void OnMouseExit()
    {
        if (!hud.inAction) 
        {
        Highlight(false);
        }
    }

    public void Rope()
    {
        this.hasRope = true;
        this.gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
    }

}
