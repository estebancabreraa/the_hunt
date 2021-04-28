using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Class that is father to every playable character in the game.
/// Has 4 main methods:
///
/// <list type="bullet">
/// <item>
/// <term>
/// Move
/// </term>
/// <description>
/// Allows the player to move
/// </description>
/// </item>
///
/// <item>
/// <term>
/// Interact
/// </term>
/// <description>
/// Main interaction. Tasks for players, non-aggressive ability for villain.
/// </description>
/// </item>
/// <item>
/// <term>
/// Attack
/// </term>
/// <description>
/// Main attack of the character. In case of player, main non-aggressive ability.
/// </description>
/// </item>
/// <item>
/// <term>
/// Attack2
/// </term>
/// <description>
/// Secondary attack of the character. In case of player, secondary, less powerful ability.
/// </description>
/// </item>
/// </list>
/// </summary>
public class PlayableCharacter : MonoBehaviour
{
    /*
     * Can:
     *  - Move
     *  - Interact
     *  - Attack
     *  - 2nd attack
     */

    protected Vector2 Movement;

    public Rigidbody2D rb;
    [SerializeField] protected float speed = 5f;
    [SerializeField] protected float speedDifferentiator = 2.5f;


    [SerializeField] protected Animator animator;

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public virtual bool HasHealth()
    {
        return false;
    }

    protected virtual void Interact()
    {
        return;
    }

}