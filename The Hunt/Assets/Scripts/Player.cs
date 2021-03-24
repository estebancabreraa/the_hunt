using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;
    private Vector2 movement;
    public Animator animator;
    public UnityEngine.UI.Image healthbar;
    public int health = 2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        

    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
    public void TakeHit()
    {
        
        if (health >= 1)
        {
            health -= 1;
            speed -= 2.5f;
            healthbar.fillAmount -= 0.5f;
        }

    }
    private void Heal()
    {
        if (health == 1)
        {
            health += 1;
            speed += 2.5f;
            healthbar.fillAmount += 0.5f;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Heal")
        {
            Heal();
        }
    }
}
