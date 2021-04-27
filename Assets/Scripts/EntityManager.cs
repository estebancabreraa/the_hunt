using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityManager : MonoBehaviour
{
    protected int health;
    public UnityEngine.UI.Image healthBar;
    private const int TotalHealth = 3;
    private PlayerMovement MovementController;
    private PlayerAbility AbilityController;

    protected virtual void Start()
    {
        health = TotalHealth;
        MovementController = GetComponent<PlayerMovement>();
        AbilityController = GetComponent<PlayerAbility>();
    }

    private void AlterHealth(int changer = 1, int modifier = 1)
    {
        health += changer * modifier;
        if (health <= 0)
            MovementController.Kill();
        else
            MovementController.SetSpeed(-1);
        healthBar.fillAmount = _HelperFunctions.GetPercentage(health, TotalHealth);
    }
}