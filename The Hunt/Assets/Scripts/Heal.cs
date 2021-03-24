using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    private bool available;
    // Start is called before the first frame update
    void Start()
    {
        available = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var crewm = collision.gameObject.GetComponent<Player>();
        if (crewm is null && !available) return;
        crewm.ManipulateHealth(1);
        available = false;
        this.gameObject.SetActive(false);
        this.Invoke("SpawnHealth", 5);
    }
    private void SpawnHealth()
    {
        available = true;
        this.gameObject.SetActive(true);

    }
}
