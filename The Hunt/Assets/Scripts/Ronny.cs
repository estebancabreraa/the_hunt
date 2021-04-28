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
        currentQ = 0;

        AffectSpeed(true);
        StartCoroutine(Deactivate());
    }
    protected IEnumerator Deactivate()
    {
        yield return new WaitForSecondsRealtime(7);
        AffectSpeed(false);
    }

    protected void AffectSpeed(bool faster)
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in players)
        {
            PlayerMovement pl = player.GetComponent<PlayerMovement>();
            if (faster)
            {
                pl.speed *= 1.7f;
                pl.normalSpeed *= 1.7f;
            }
            else { 
                pl.speed /= 1.7f;
                pl.normalSpeed /= 1.7f;
            }

        }
    }
}
