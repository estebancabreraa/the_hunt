using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    public GameObject wood;
    public GameObject campFire;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("asdfasf");
        campFire.active = true;
        wood.active = false;
    }
}
