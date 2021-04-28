using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entry : MonoBehaviour
{
    public GameObject complete1;
    public GameObject complete2;


    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("asdfasf");
        complete1.active = false;
        complete2.active = true;
    }
}
