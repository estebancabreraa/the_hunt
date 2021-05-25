using MLAPI.Messaging;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ronny : EntityAbility
{
    protected GameObject[] players;

    protected override void UseFirstAbility()
    {
        if (!abilityAvailable[0]) return;
        abilityAvailable[0] = false;
        StartCoroutine(ResetAbility(1));
        currentQ.Value = 0;

        AffectSpeedServerRpc(true);
        StartCoroutine(Deactivate());
    }
    protected IEnumerator Deactivate()
    {
        yield return new WaitForSecondsRealtime(7);
        AffectSpeedServerRpc(false);
    }

    [ServerRpc]
    protected void AffectSpeedServerRpc(bool faster)
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in players)
        {
            PlayerMovement pl = player.GetComponent<PlayerMovement>();
            if (faster)
            {
                pl.speed.Value *= 1.7f;
                pl.normalSpeed *= 1.7f;
            }
            else { 
                pl.speed.Value /= 1.7f;
                pl.normalSpeed /= 1.7f;
            }

        }
    }
}
