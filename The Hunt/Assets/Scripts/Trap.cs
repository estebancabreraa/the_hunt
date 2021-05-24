using MLAPI;
using MLAPI.Messaging;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : NetworkBehaviour
{

    private bool disabled;
    private SpriteRenderer srenderer;
    private PlayerManager trappedPlayer;

    private void Start()
    {
        srenderer = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerManager crewm = collision.gameObject.GetComponent<PlayerManager>();
        if (crewm != null && collision.tag == "Player")
        {
            trappedPlayer = crewm;
            GotPlayerServerRpc();
            
        }

    }

    [ServerRpc]
    public void GotPlayerServerRpc()
    {

        if (!disabled)
            trappedPlayer.AlterHealth(1, -1);
        Destroy(gameObject);
    }
    public void DisableTrap()
    {
        srenderer.enabled = true;
        disabled = true;
    }
    public void EnableTrap()
    {
        srenderer.enabled = false;
        disabled = false;
    }
}
