using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnowDigger : CharacterState
{

    private Vector2 nextPos;
    private SnowBlock blockToDig;

    [HideInInspector] public bool choosingDig = false;




    string[] actions = new string[] { "Dig Snow", "Climb Rope" };
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {

    }

    public override void Action1()
    {
        GameObject[] snowBlocks = GameObject.FindGameObjectsWithTag("SnowBlock");

        foreach (GameObject i in snowBlocks)
        {
            i.GetComponent<SnowBlock>().Highlight(true);
        }
        choosingDig = true;
    }

    public override void ShowHud(HUD hud)
    {
        hud.actionButton1.GetComponentInChildren<Text>().text = this.actions[0];
        hud.actionButton1.gameObject.SetActive(true);
    }

    public void Dig(SnowBlock block)
    {
        this.choosingDig = false;
        nextPos = block.gameObject.transform.position;
        this.transform.position = nextPos;

        block.gameObject.SetActive(false);

    }

    public override void Deselect()
    {
        this.choosingDig = false;
        blockToDig = null;
        nextPos = this.gameObject.transform.position;

    }
}
