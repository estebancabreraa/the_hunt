using MLAPI;
using MLAPI.Messaging;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wanderer : EntityAbility
{
    [SerializeField] protected NetworkObject trapp;
    [SerializeField] protected Transform destination;
    [SerializeField] protected Text amount;

    protected int maxTraps = 3;
    //protected Trap newHeal;

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
        SpawnTrapServerRpc();
        
        maxTraps -= 1;
        amount.text = maxTraps.ToString();
        if (maxTraps == 0)
        {
            //currentQ.Value = 0;
            UpdateCDServerRpc(0);
            abilityAvailable[0] = false;
        }

    }

    [ServerRpc]
    public void SpawnTrapServerRpc()
    {
        NetworkObject newHeal = Instantiate(trapp, destination.position, Quaternion.identity);
        //newHeal.gameObject.transform.localPosition = destination.position;
        newHeal.SpawnWithOwnership(OwnerClientId);
        
    }
    protected override IEnumerator ResetAbility(int ability)
    {
        yield return new WaitForSecondsRealtime(abilityCooldowns.Value);
        abilityAvailable[ability - 1] = true;
        maxTraps += 1;
        amount.text = maxTraps.ToString();
        //currentQ.Value = abilityCooldowns.Value;
        UpdateCDServerRpc(abilityCooldowns.Value);
        qCD.fillAmount = 1;

    }
}
