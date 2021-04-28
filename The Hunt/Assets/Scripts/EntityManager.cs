using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityManager : MonoBehaviour
{
    [SerializeField] protected int health;
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

    public virtual void AlterHealth(int changer = 1, int modifier = 1)
    {
        if (health == TotalHealth && changer == 1 && modifier == 1) return;
        health += changer * modifier;
        if (health <= 0)
            MovementController.Kill();
        else
        {
            if (modifier > 0)
                MovementController.SetSpeed(-1, true);
            else
                MovementController.SetSpeed(-1);
        }
        healthBar.fillAmount = _HelperFunctions.GetPercentage(health, TotalHealth);
    }
    
    
}