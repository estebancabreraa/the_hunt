using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piano : MonoBehaviour
{
    public bool notPressed = true;

    public AudioSource a;
    public AudioSource b;
    public AudioSource c;
    public AudioSource d;
    public AudioSource e;
    public AudioSource f;
    public AudioSource g;

    public GameObject c1;
    public GameObject d1;
    public GameObject e1;
    public GameObject f1;
    public GameObject g1;
    public GameObject a1;
    public GameObject b1;
    // Update is called once per frame


    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            a.Play();
            a1.active = true;
        }
        if (Input.GetKey(KeyCode.B))
        {
            b.Play();
            b1.active = true;
        }
        if (Input.GetKey(KeyCode.C))
        {
            c.Play();
            c1.active = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            d.Play();
            d1.active = true;
        }
        if (Input.GetKey(KeyCode.E))
        {
            e.Play();
            e1.active = true;
        }
        if (Input.GetKey(KeyCode.F))
        {
            f.Play();
            f1.active = true;
        }
        if (Input.GetKey(KeyCode.G))
        {
            g.Play();
            g1.active = true;
        }
    }
}
