using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnowDigger : CharacterState
{

    private Vector2 nextPos;
    //private SnowBlock blockToDig;

    [HideInInspector] public bool choosingDig = false;

    string[] actions = new string[] { "Dig Snow", "Climb Rope" };


    public override void Action1()
    {
        GameObject[] snowBlocks = GameObject.FindGameObjectsWithTag("SnowBlock");

        foreach (GameObject i in snowBlocks)
        {
            i.GetComponent<SnowBlock>().Highlight(true);
        }
        choosingDig = true;
    }

    public void Dig(SnowBlock block)
    {
        this.choosingDig = false;
        nextPos = block.gameObject.transform.position;
        this.transform.position = nextPos;

        block.gameObject.SetActive(false);

    }

    /*public override void Deselect()
    {
        this.choosingDig = false;
        //blockToDig = null;
        nextPos = this.gameObject.transform.position;
        base.Deselect();

    }*/
}
