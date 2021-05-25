using MLAPI;
using MLAPI.Messaging;
using MLAPI.NetworkVariable;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : NetworkBehaviour
{

    public NetworkVariableBool disabled = new NetworkVariableBool(new NetworkVariableSettings { WritePermission = NetworkVariablePermission.Everyone } , false);
    public SpriteRenderer srenderer;
    //private PlayerManager trappedPlayer;

    private void Start()
    {
        srenderer = GetComponent<SpriteRenderer>();
        if (!IsHost)
            srenderer.enabled = false;
            //print("hola");
    }
    private void OnEnable()
    {
        disabled.OnValueChanged += UpdateVisibility;
    }
    private void OnDisable()
    {
        disabled.OnValueChanged -= UpdateVisibility;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerManager crewm = collision.gameObject.GetComponent<PlayerManager>();
        if (crewm != null && collision.tag == "Player")
        {
            GotPlayerServerRpc(crewm.name);
            
        }

    }

    [ServerRpc]
    public void GotPlayerServerRpc(string name)
    {
        var trappedPlayer = GameObject.Find(name).GetComponent<PlayerManager>();
        if (!disabled.Value && trappedPlayer != null)
            trappedPlayer.AlterHealth(1, -1);
        Destroy(gameObject);
        print("Deleted");

    }
    public void DisableTrap()
    {
        print("Disabled por " + gameObject.name);
        if (!IsHost)
            srenderer.enabled = true;
        disabled.Value = true;
    }
    public void EnableTrap()
    {
        if (!IsHost)
            srenderer.enabled = false;
        disabled.Value = false;
    }
    protected void UpdateVisibility(bool oldValue, bool newValue)
    {
        if (!IsHost)
            srenderer.enabled = newValue;
    }
}
