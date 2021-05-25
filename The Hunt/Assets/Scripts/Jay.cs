using MLAPI;
using MLAPI.Messaging;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jay : EntityAbility
{
    [SerializeField] protected int maxSpawns = 2;
    [SerializeField] protected NetworkObject pickup;
    [SerializeField] protected Transform destination;
    [SerializeField] protected Text amount;

    //protected Heal newHeal;

    protected override void UseFirstAbility()
    {
        //base.UseFirstAbility();
        if (!abilityAvailable[0]) return;
        StartCoroutine(ResetAbility(1));
        SpawnHealServerRpc();
        if (maxSpawns == 0) return;
        maxSpawns -= 1;
        amount.text = maxSpawns.ToString();
        if (maxSpawns == 0)
        {
            abilityAvailable[0] = false;
            currentQ.Value = 0;
        }
    }
    protected override IEnumerator ResetAbility(int ability)
    {
        yield return new WaitForSecondsRealtime(abilityCooldowns.Value);
        abilityAvailable[ability - 1] = true;
        maxSpawns += 1;
        amount.text = maxSpawns.ToString();
        currentQ.Value = abilityCooldowns.Value;
        qCD.fillAmount = 1;

    }

    [ServerRpc]
    public void SpawnHealServerRpc()
    {
        NetworkObject newHeal = Instantiate(pickup, destination.position, Quaternion.identity);
        newHeal.SpawnWithOwnership(OwnerClientId);
    }
}
