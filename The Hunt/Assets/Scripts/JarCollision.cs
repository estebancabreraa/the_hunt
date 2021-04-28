using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JarCollision : MonoBehaviour
{
    public GameObject half1;
    public GameObject half2;

    public GameObject complete;

    public GameObject entry;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("asdfasf");
        half1.active = false;
        half2.active = false;
        complete.active = true;
        entry.active = true;
    }
}
