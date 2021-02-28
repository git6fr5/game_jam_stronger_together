using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Climber : CharacterState
{

    public const float FLYING_DRAIN_RATE = 1f;

    [HideInInspector] public bool isFlying = false;
    private bool ropeThrow = false;
    private SnowBlock snowBlock;

    string[] actions = new string[] { "Fly", "Throw Rope" };

    public override void Action1()
    {
        isFlying = !isFlying;

        GameObject[] snowBlocks = GameObject.FindGameObjectsWithTag("SnowBlock");

        //enabled flyable walls
        foreach (GameObject i in snowBlocks)
        {
            bool hasRope = i.GetComponent<SnowBlock>().hasRope;
            if (!hasRope)
            {
                i.GetComponent<CapsuleCollider2D>().enabled = !isFlying;
            }
        }

        //update oxygen drain rate
        if (isFlying)
        {
            SetOxyDrain(FLYING_DRAIN_RATE);
        }
        else
        {
            SetOxyDrain(BASE_DRAIN_RATE);
        }
    }

    public void LateUpdate()
    {
        if (isFlying)
        {
            spriteRenderer.sortingOrder = 500;
        }
    }

    public override void Action2()
    {
        if (ropeThrow && !snowBlock.hasRope)
        {
            //throw rope animation
            snowBlock.Rope();
        }

        print(ropeThrow.ToString());
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("RopeThrow"))
        {
            this.ropeThrow = true;
            this.snowBlock = collision.gameObject.GetComponentInParent<SnowBlock>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("RopeThrow"))
        {
            this.ropeThrow = false;
        }
    }
}
