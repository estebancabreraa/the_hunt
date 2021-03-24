using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Villain : PlayableCharacter
{
    private List<Player> playerList;
    private Player current;
    protected override void Start()
    {
        base.Start();
        playerList = new List<Player>();
    }

    protected override void Update()
    {
        base.Update();
        if (!Input.GetKeyDown(KeyCode.K)) return;
        SelectPlayer();
        if (current is null) return;
        current.ManipulateHealth(-1);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var crewm = collision.gameObject.GetComponent<Player>();
        if (crewm != null)
            playerList.Add(crewm);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        var crewm = collision.gameObject.GetComponent<Player>();
        if (crewm != null)
        {
            //Quitar selected
            playerList.Remove(crewm);
            current = null;
        }
    }

    public void SelectPlayer()
    {
        //Calcular player mas cercano
        if(playerList.Count > 0)
        {
            Player selected = null;
            float minDistance = 1100f;
            foreach (Player crewm in playerList)
            {
                float distance = Vector3.Distance(transform.position, crewm.transform.position);
                if(distance < minDistance)
                {
                    minDistance = distance;
                    selected = crewm;
                }
            }
            if(selected != null)
                current = selected;
        }
    }

}