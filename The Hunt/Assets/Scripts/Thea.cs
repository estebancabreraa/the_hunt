using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MLAPI.Messaging;
using MLAPI.NetworkVariable;

public class Thea : EntityAbility
{

    [SerializeField] protected Transform arrow;
    protected Transform villain;
    [SerializeField] protected float minDistance;
    protected NetworkVariableBool active = new NetworkVariableBool(new NetworkVariableSettings { WritePermission = NetworkVariablePermission.OwnerOnly }, false);


    protected override void Start()
    {
        abilityCooldowns.Value = 20;
        base.Start();
        villain = GameObject.FindGameObjectWithTag("Villain").transform;
    }
    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (!active.Value)
        {
            arrow.gameObject.SetActive(false);

            return;
        }
        var dir = villain.position - arrow.position;
        if (dir.magnitude < minDistance)
            arrow.gameObject.SetActive(false);
        else
        {
            arrow.gameObject.SetActive(true);
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            arrow.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    protected override void UseFirstAbility()
    {
        //base.UseFirstAbility();
        if (!abilityAvailable[0]) return;
        currentQ.Value = 0;
        abilityAvailable[0] = false;
        active.Value = true;
        StartCoroutine(Deactivate());
        StartCoroutine(ResetAbility(1));

    }

    protected IEnumerator Deactivate()
    {
        yield return new WaitForSecondsRealtime(7);
        active.Value = false;
    }

}
