using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// to avoid using the unity animator which is clunky af
public class CharacterAnimation : MonoBehaviour
{
    /* --- Debug --- */
    private string DebugTag = "[K2] {CharacterAnimation}: ";
    private bool DEBUG_init = false;

    /* --- Components --- */

    // Animation Clips
    public AnimationClip idleAnim;
    public AnimationClip moveAnim;
    public AnimationClip actionAnim;
    public AnimationClip hurtAnim;
    public AnimationClip deathAnim;

    // The Animator
    public Animator animator;

    // Audio Clips
    public AudioClip idleAudio;
    public AudioClip moveAudio;
    public AudioClip actionAudio;
    public AudioClip hurtAudio;
    public AudioClip deathAudio;

    // The Audio Source
    public AudioSource audioSource;

    /* --- Internal Variables --- */
    [HideInInspector] public bool move = false;
    [HideInInspector] public bool hurt = false;
    [HideInInspector] public bool death = false;
    [HideInInspector] public bool action = false;
    [HideInInspector] public bool collect = false;

    private bool overriding = false;
    private float duration;
    private float elapsedDuration = 0f;

    /* --- Unity Methods --- */
    void Start()
    {
        if (DEBUG_init) { print(DebugTag + "Activated for " + gameObject.name); }
    }

    void Update()
    {
        // if not playing an 'unoverridable' animation
        // check to see if the selected animation has changed
        if (!overriding)
        {
            SetAnimation();
        }
    }

    void FixedUpdate()
    {
        // if playing an 'unoverridable' animation
        // check to see if that animation has ended
        if (overriding)
        {
            OverrideAnimationForDuration(elapsedDuration, duration);
        }
    }

    // runs through the possible animations that can be played and selects the highest priority one
    public void SetAnimation()
    {
        bool animated = false;

        /* --- High Priority --- */
        
        // if one of these are selected, then we must run through the whole animation (hence, overriding)
        if (death && deathAnim)
        {
            animator.Play(deathAnim.name);
            overriding = true; duration = deathAnim.length;
            return;
        }
        else if (hurt && hurtAnim)
        {
            animator.Play(hurtAnim.name);
            overriding = true; duration = hurtAnim.length;
            return;
        }

        /* --- Mid Priority --- */
        if (move && moveAnim)
        {
            animator.Play(moveAnim.name);
            return;
        }
        else if (action && actionAnim)
        {
            animator.Play(actionAnim.name);
            return;
        }
        if (animated) { return; }

        /* --- Low Priority --- */
        animator.Play(idleAnim.name);
        return;
    }

    // releases the override once the animation duration is up
    public void OverrideAnimationForDuration(float elapsedDuration, float duration)
    {
        elapsedDuration = elapsedDuration + Time.fixedDeltaTime;
        if (elapsedDuration > duration)
        {
            overriding = false;
        }
    }

    // runs through the possible sounds that can be played and selects the highest priority one
    public void PlaySound()
    {
        if (death && deathAudio)
        {
            audioSource.clip = deathAudio;
            audioSource.Play(); 
            death = false;
            return;
        }
        else if (hurt && hurtAudio)
        {
            audioSource.clip = hurtAudio;
            audioSource.Play(); 
            hurt = false;
            return;
        }
        else if (action && actionAudio)
        {
            audioSource.clip = actionAudio;
            audioSource.Play(); 
            action = false;
            return;
        }

        /*--- Low Priority ---*/

        audioSource.clip = idleAudio;
        audioSource.Play();
        return;
    }
}
