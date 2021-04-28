using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntityAbility : MonoBehaviour
{
    protected int[] abilityCooldowns = {15, 10};
    protected bool[] abilityAvailable = {true, true};
    [SerializeField] protected Image qCD;
    protected float currentQ;

    protected virtual void Start()
    {
        currentQ = abilityCooldowns[0];
    }

    // Hey, if it works, it works. 
    // Nevertheless, we need to make this abstract. 
    // Update uses a lot of processing power.
    // We can make a coroutine to manage the current
    // Availability of the ability
    protected virtual void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            UseFirstAbility();
        }

        const float tolerance = 0.01f;
        if (Math.Abs(currentQ - abilityCooldowns[0]) > tolerance && !abilityAvailable[0])
            currentQ += Time.deltaTime;
        qCD.fillAmount = _HelperFunctions.GetPercentage((int) currentQ, abilityCooldowns[0]);
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
        yield return new WaitForSecondsRealtime(abilityCooldowns[ability - 1]);
        abilityAvailable[ability - 1] = true;
        currentQ = abilityCooldowns[0];
    }
}