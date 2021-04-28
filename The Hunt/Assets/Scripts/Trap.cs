using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{

    private bool disabled;
    private SpriteRenderer srenderer;

    private void Start()
    {
        srenderer = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var crewm = collision.gameObject.GetComponent<PlayerManager>();
        if (crewm != null && collision.tag == "Player")
        {
            if (!disabled)
                crewm.AlterHealth(1, -1);
            Destroy(gameObject);
        }

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
