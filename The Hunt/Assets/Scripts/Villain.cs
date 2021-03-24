using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Villain : MonoBehaviour
{
    private Player crewm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        Player crewm = collision.gameObject.GetComponent<Player>();
        if (Input.GetKeyDown(KeyCode.K) && crewm != null)
        {
            crewm.TakeHit();
            Debug.Log(crewm);
        }
    }


}
