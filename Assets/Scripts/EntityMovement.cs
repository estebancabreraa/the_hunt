using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMovement : MonoBehaviour
{
    protected Vector2 movement;
    protected Rigidbody2D rb;
    [SerializeField] protected float normalSpeed = 5f;
    protected float speed;
    [SerializeField] protected float speedDiffentiator;
    [SerializeField] protected Animator animator;
    [SerializeField] protected int TimeDisabledSpeed;
    protected Coroutine SpeedChanger;
    private static readonly int Horizontal = Animator.StringToHash("Horizontal");
    private static readonly int Vertical = Animator.StringToHash("Vertical");
    private static readonly int Speed = Animator.StringToHash("Speed");


    // Start is called before the first frame update
    protected virtual void Start()
    {
        speed = normalSpeed;
        speedDiffentiator = .5f;
        rb = GetComponent<Rigidbody2D>();
        TimeDisabledSpeed = 15;
        SpeedChanger = null;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat(Horizontal, movement.x);
        animator.SetFloat(Vertical, movement.x);
        animator.SetFloat(Speed, movement.sqrMagnitude);
    }

    protected virtual void FixedUpdate()
    {
        var calculatedSpeed = speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement * calculatedSpeed);
    }

    public virtual void SetSpeed(float factor, bool reset = false)
    {
        const double tolerance = .001f;
        if (Math.Abs(factor - (-1f)) < tolerance)
            factor = speedDiffentiator;

        speed = reset ? normalSpeed * factor : normalSpeed;
        if (reset) return;

        // If the coroutine is not running already 
        if (!(SpeedChanger is null))
        {
            StopCoroutine(SpeedChanger);
        }

        SpeedChanger = StartCoroutine(AffectSpeedForTime());
    }


    public virtual void Kill()
    {
        speed = 0;
    }

    protected virtual IEnumerator AffectSpeedForTime()
    {
        yield return new WaitForSecondsRealtime(TimeDisabledSpeed);
        SetSpeed(0, true);
    }
}