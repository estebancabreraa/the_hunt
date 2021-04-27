using System;
using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : PlayableCharacter
{
    public UnityEngine.UI.Image healthbar;
    public int health;
    private const int TotalHealth = 3;

    [SerializeField] private int damageTaken = 1;

    protected override void Start()
    {
        base.Start();
        speedDifferentiator = _HelperFunctions.GetPercentage((int) speed, TotalHealth);
        health = TotalHealth;
    }


    /// <summary>
    /// If the changer is positive
    /// </summary>
    /// <param name="changer"></param>
    private void AlterateHealth(int changer = 1)
    {
        health += changer * damageTaken;
        if (health <= 0)
            speed = 0;
        else
            speed += changer * speedDifferentiator;

        healthbar.fillAmount = _HelperFunctions.GetPercentage(health, TotalHealth);
    }

    /// <summary>
    /// Manipulates the players health
    /// </summary>
    /// <param name="typeInteraction">
    /// <list type="bullet">
    /// <item>
    /// <term>
    /// 1
    /// </term>
    /// <description>
    /// Attacks the player
    /// </description>
    /// </item>
    /// <item>
    /// <term>
    /// 2
    /// </term>
    /// <description>
    /// Heals the player
    /// </description>
    /// </item>
    /// </list>
    /// </param>
    public void ManipulateHealth(int typeInteraction)
    {
        switch (typeInteraction)
        {
            case -1:
                if (health < 1) break;
                AlterateHealth(-1);
                break;

            case 1:
                if (health == 0 || health == TotalHealth) break;
                AlterateHealth();
                break;
        }
    }

    public override bool HasHealth()
    {
        return true;
    }
}