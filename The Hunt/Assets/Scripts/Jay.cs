using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jay : EntityAbility
{
    [SerializeField] protected int maxSpawns = 2;
    [SerializeField] protected Heal pickup;
    [SerializeField] protected Transform destination;
    protected Heal newHeal;

    protected override void UseFirstAbility()
    {
        //base.UseFirstAbility();
        if (!abilityAvailable[0]) return;
        abilityAvailable[0] = false;
        StartCoroutine(ResetAbility(1));
        if (maxSpawns == 0) return;
        newHeal = Instantiate(pickup);
        newHeal.gameObject.transform.localPosition = destination.position;
        maxSpawns -= 1;
        if (maxSpawns == 0)
            abilityAvailable[0] = false;
    }
    protected override IEnumerator ResetAbility(int ability)
    {
        yield return new WaitForSecondsRealtime(abilityCooldowns[ability - 1]);
        abilityAvailable[ability - 1] = true;
        maxSpawns += 1;
    }
}
