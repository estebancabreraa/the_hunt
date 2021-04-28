using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityAbility : MonoBehaviour
{
    protected int[] abilityCooldowns = { 15, 10 };
    protected bool[] abilityAvailable = {true, true};


    protected virtual void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            UseFirstAbility();
        }
    }
    protected virtual void UseFirstAbility()
    {
        if (!abilityAvailable[0]) return;
        abilityAvailable[0] = false;
        // DO THE ABILITY HERE
        StartCoroutine(ResetAbility(1));
    }
    protected virtual void UseSecondAbility()
    {

        if (!abilityAvailable[0]) return;
        abilityAvailable[1] = false;
        // DO THE ABILITY HERE
        StartCoroutine(ResetAbility(2));
    }

    protected virtual IEnumerator ResetAbility(int ability)
    {
        yield return new WaitForSecondsRealtime(abilityCooldowns[ability - 1]);
        abilityAvailable[ability - 1] = true;
    }

}
