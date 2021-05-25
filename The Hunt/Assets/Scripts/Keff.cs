using MLAPI.Messaging;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keff : EntityAbility
{
    //protected GameObject[] traps;

    protected override void UseFirstAbility()
    {
        if (!abilityAvailable[0]) return;
        abilityAvailable[0] = false;
        StartCoroutine(ResetAbility(1));
        currentQ.Value = 0;

        AffectTrapsServerRpc(true);
        StartCoroutine(Deactivate());
    }
    protected IEnumerator Deactivate()
    {
        yield return new WaitForSecondsRealtime(7);
        AffectTrapsServerRpc(false);
    }

    [ServerRpc]
    protected void AffectTrapsServerRpc(bool disable)
    {
        print("entro");
        GameObject[] traps = GameObject.FindGameObjectsWithTag("Trap");
        foreach (GameObject trap in traps)
        {
            print(trap);

            Trap tr = trap.GetComponent<Trap>();
            if (disable)
                tr.DisableTrap();
            else
                tr.EnableTrap();

        }
    }
}
