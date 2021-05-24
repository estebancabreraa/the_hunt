using MLAPI;
using MLAPI.Messaging;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Villain : NetworkBehaviour
{
    protected Vector2 Movement;

    [SerializeField] protected float speed = 5f;
    [SerializeField] protected float speedDifferentiator = 2.5f;
    private List<PlayerManager> playerList;
    private PlayerManager current;
    protected void Start()
    {
        playerList = new List<PlayerManager>();
    }

    protected virtual void Update()
    {
        //base.Update();
        if (!IsLocalPlayer) return;
        if (!Input.GetKeyDown(KeyCode.K)) return;
        SelectPlayer();
        print(current.name);
        HitPlayerServerRpc(current.name);
        print("end");

    }

    [ServerRpc]
    public void HitPlayerServerRpc(string name)
    {
        var player = GameObject.Find(name).GetComponent<PlayerManager>();
        if (player is null) return;
        player.AlterHealth(1, -1);
        print(player.name);


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var crewm = collision.gameObject.GetComponent<PlayerManager>();
        if (crewm != null && IsOwner)
        {
            playerList.Add(crewm);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        var crewm = collision.gameObject.GetComponent<PlayerManager>();
        if (crewm != null && IsOwner)
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
            PlayerManager selected = null;
            float minDistance = 1100f;
            foreach (PlayerManager crewm in playerList)
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