using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    private bool available;
    [SerializeField] bool respawnable = true;
    // Start is called before the first frame update
    void Start()
    {
        available = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var crewm = collision.gameObject.GetComponent<PlayerManager>();
        if (crewm is null || !available || collision.tag != "Player") return;
        crewm.AlterHealth();
        if (!respawnable)
            Destroy(this.gameObject);
        else
        {
            available = false;
            this.gameObject.SetActive(false);
            this.Invoke("SpawnHealth", 5);
        }
    }
    private void SpawnHealth()
    {
        available = true;
        this.gameObject.SetActive(true);

    }
}
