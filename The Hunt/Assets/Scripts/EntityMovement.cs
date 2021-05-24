using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using MLAPI.Messaging;
using MLAPI.NetworkVariable;

public class EntityMovement : NetworkBehaviour
{
    protected Vector2 movement;
    protected Rigidbody2D rb;
    [SerializeField] public float normalSpeed = 5f;
    public NetworkVariableFloat speed;
    [SerializeField] protected float speedDiffentiator;
    [SerializeField] protected Animator animator;
    [SerializeField] protected int TimeDisabledSpeed;
    protected Coroutine SpeedChanger;
    private static readonly int Horizontal = Animator.StringToHash("Horizontal");
    private static readonly int Vertical = Animator.StringToHash("Vertical");
    private static readonly int Speed = Animator.StringToHash("Speed");
    public Transform cameraT;
    public GameObject canvas;
    public NetworkObject villainp;


    // Start is called before the first frame update
    protected virtual void Start()
    {
        speed.Value = normalSpeed;
        speedDiffentiator = .5f;
        TimeDisabledSpeed = 10;
        SpeedChanger = null;
        if (!IsLocalPlayer)
        {
            cameraT.GetComponent<AudioListener>().enabled = false;
            cameraT.GetComponent<Camera>().enabled = false;
            canvas.SetActive(false);
        }
        else
        {
            rb = GetComponent<Rigidbody2D>();
            
        }
        if (IsOwner && !IsHost)
        {
            if (GameObject.Find("Thea(Clone)") == null)
                SpawnCliServerRpc(OwnerClientId, 1);
        }
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //animator.SetFloat(Horizontal, movement.x);
        //animator.SetFloat(Vertical, movement.x);
        //animator.SetFloat(Speed, movement.sqrMagnitude);
    }

    protected virtual void FixedUpdate()
    {
        if (IsLocalPlayer)
        {
            var calculatedSpeed = speed.Value * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + movement * calculatedSpeed);
        }
    }

    public virtual void SetSpeed(float factor, bool reset = false)
    {
        const double tolerance = .001f;
        if (Math.Abs(factor - (-1f)) < tolerance)
            factor = speedDiffentiator;

        speed.Value = reset ? normalSpeed : normalSpeed * factor;
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
        speed.Value = 0;
    }

    public virtual IEnumerator AffectSpeedForTime()
    {
        yield return new WaitForSecondsRealtime(TimeDisabledSpeed);
        if (speed.Value != 0)
            SetSpeed(0, true);
    }

    [ServerRpc]
    public void SpawnCliServerRpc(ulong cid, int character)
    {
        if (character == 1)
        {
            NetworkObject villaini = Instantiate(villainp, Vector3.zero, Quaternion.identity);
            villaini.SpawnAsPlayerObject(cid);
            Destroy(gameObject);
        }
    }
}