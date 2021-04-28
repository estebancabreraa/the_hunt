using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JarDrag : MonoBehaviour
{
    public bool isDragging;
    // Start is called before the first frame update



    void Start()
    {
        isDragging = false;
    }

    public void OnMouseDown()
    {
        isDragging = true;
    }

    public void OnMouseUp()
    {
        isDragging = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDragging)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousePosition);
        }
    }
}
