using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnowBlock : CharacterState
{

    HUD hud;
    SnowDigger snowDigger;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.tag = "SnowBlock";
        hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
        snowDigger = GameObject.FindGameObjectWithTag("SnowDigger").GetComponent<SnowDigger>();
    }


    public override void OnMouseDown()
    {
        if (!hud.inAction)
        {
            Select();
        }

        if (snowDigger.choosingDig)
        {

            snowDigger.Dig(this);
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




    public override void ShowHud(HUD hud)
    {

        hud.description.text = "This snow can be dug";
        hud.description.gameObject.SetActive(true);
    }

}
