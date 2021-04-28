using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeKeyRotation : MonoBehaviour
{
    public Quaternion fromAngle;
    public Quaternion toAngle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        Debug.Log("Pipe-Key-Click");
        fromAngle = transform.rotation;
        toAngle = Quaternion.Euler(transform.eulerAngles + new Vector3(0, 0, 90f));
        transform.rotation = Quaternion.Lerp(fromAngle, toAngle, 1f);
    }
}
