using MLAPI;
using MLAPI.NetworkVariable;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityManager : NetworkBehaviour
{
    public NetworkVariableFloat health = new NetworkVariableFloat(3f);
    public UnityEngine.UI.Image healthBar;
    private const int TotalHealth = 3;
    private PlayerMovement MovementController;

    protected virtual void Start()
    {
        health.Value = TotalHealth;
        MovementController = GetComponent<PlayerMovement>();
    }

    public virtual void AlterHealth(int changer = 1, int modifier = 1)
    {
        if (health.Value == TotalHealth && changer == 1 && modifier == 1) return;
        health.Value += changer * modifier;
        if (health.Value <= 0)
            MovementController.Kill();
        else if (IsOwner)
        {
            if (modifier > 0)
                MovementController.SetSpeed(-1, true);
            else
                MovementController.SetSpeed(-1);
        }
    }

    private void OnEnable()
    {
        health.OnValueChanged += UpdateFill;
    }
    private void OnDisable()
    {
        health.OnValueChanged -= UpdateFill;

    }

    protected void UpdateFill(float oldValue, float newValue)
    {
        healthBar.fillAmount = newValue / TotalHealth;
    }

}