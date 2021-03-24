using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piano : MonoBehaviour
{
    public AudioSource a;
    public AudioSource b;
    public AudioSource c;
    public AudioSource d;
    public AudioSource e;
    public AudioSource f;
    public AudioSource g;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            a.Play();
        }
        if (Input.GetKey(KeyCode.B))
        {
            b.Play();
        }
        if (Input.GetKey(KeyCode.C))
        {
            c.Play();
        }
        if (Input.GetKey(KeyCode.D))
        {
            d.Play();
        }
        if (Input.GetKey(KeyCode.E))
        {
            e.Play();
        }
        if (Input.GetKey(KeyCode.F))
        {
            f.Play();
        }
        if (Input.GetKey(KeyCode.G))
        {
            g.Play();
        }
    }
}
