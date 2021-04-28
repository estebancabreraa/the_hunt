using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wanderer : EntityAbility
{
    [SerializeField] protected Trap trapp;
    [SerializeField] protected Transform destination;
    [SerializeField] protected Text amount;

    protected int maxTraps = 3;
    protected Trap newHeal;

    protected override void Start()
    {
        base.Start();

    }

    protected override void UseFirstAbility()
    {
        //base.UseFirstAbility();
        if (!abilityAvailable[0]) return;
        StartCoroutine(ResetAbility(1));

        if (maxTraps == 0) return;
        newHeal = Instantiate(trapp);
        newHeal.gameObject.transform.localPosition = destination.position;
        maxTraps -= 1;
        amount.text = maxTraps.ToString();
        if (maxTraps == 0)
        {
            currentQ = 0;
            abilityAvailable[0] = false;
        }

    }
    protected override IEnumerator ResetAbility(int ability)
    {
        yield return new WaitForSecondsRealtime(abilityCooldowns[ability - 1]);
        abilityAvailable[ability - 1] = true;
        maxTraps += 1;
        amount.text = maxTraps.ToString();
        currentQ = abilityCooldowns[0];
        qCD.fillAmount = 1;

    }
}