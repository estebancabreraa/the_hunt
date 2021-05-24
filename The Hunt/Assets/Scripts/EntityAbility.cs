using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MLAPI;
using MLAPI.NetworkVariable;
using MLAPI.Messaging;
using System.Xml.Schema;

public class EntityAbility : NetworkBehaviour
{
    [SerializeField] protected NetworkVariableFloat abilityCooldowns = new NetworkVariableFloat(new NetworkVariableSettings { WritePermission = NetworkVariablePermission.OwnerOnly }, 15f);
    [SerializeField] protected bool[] abilityAvailable = {true, true};
    [SerializeField] protected Image qCD;
    //protected float currentQ;
    const float tolerance = 0.01f;
    [SerializeField] protected NetworkVariableFloat currentQ = new NetworkVariableFloat(20f);


    protected virtual void Start()
    {
        currentQ.Value = abilityCooldowns.Value;
    }

    private void OnEnable()
    {
        currentQ.OnValueChanged += UpdateFill;
    }
    private void OnDisable()
    {
        currentQ.OnValueChanged -= UpdateFill;

    }
    // Hey, if it works, it works. 
    // Nevertheless, we need to make this abstract. 
    // Update uses a lot of processing power.
    // We can make a coroutine to manage the current
    // Availability of the ability
    protected virtual void Update()
    {
        if (IsOwner)
        {
            if (Input.GetKeyDown(KeyCode.Q))
                UseFirstAbility();
            if (Math.Abs(currentQ.Value - abilityCooldowns.Value) > tolerance && !abilityAvailable[0])
                UpdateCDServerRpc(currentQ.Value + Time.deltaTime);
            //qCD.fillAmount = _HelperFunctions.GetPercentage((int)currentQ.Value, abilityCooldowns.Value);
        }
        
            
    }

    protected virtual void UseFirstAbility()
    {
        //if (!abilityAvailable[0]) return;
        //abilityAvailable[0] = false;
        // DO THE ABILITY HERE
        //StartCoroutine(ResetAbility(1));
    }

    protected virtual void UseSecondAbility()
    {
        if (!abilityAvailable[1]) return;
        abilityAvailable[1] = false;
        // DO THE ABILITY HERE
        StartCoroutine(ResetAbility(2));
    }

    protected virtual IEnumerator ResetAbility(int ability)
    {
        yield return new WaitForSecondsRealtime(abilityCooldowns.Value);
        abilityAvailable[ability - 1] = true;
        //currentQ.Value = abilityCooldowns.Value;
        if (IsOwner)
            UpdateCDServerRpc(abilityCooldowns.Value);
    }

    [ServerRpc]
    protected void UpdateCDServerRpc(float value)
    {
        currentQ.Value = value;
    }
    protected void UpdateFill(float oldValue, float newValue)
    {
        qCD.fillAmount = newValue/abilityCooldowns.Value;
    }
}