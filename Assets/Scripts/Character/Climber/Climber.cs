using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Climber : CharacterState
{


    string[] actions = new string[] { "Free Climb", "Throw Rope" };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public new void Action1()
    {

    }


    public override void ShowHud(HUD hud)
    {
        hud.actionButton1.GetComponentInChildren<Text>().text = this.actions[0];
        hud.actionButton1.gameObject.SetActive(true);
    }
}
