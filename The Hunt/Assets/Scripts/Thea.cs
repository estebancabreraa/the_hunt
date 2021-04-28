using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Thea : EntityAbility
{

    [SerializeField] protected Transform arrow;
    [SerializeField] protected Transform villain;
    [SerializeField] protected float minDistance;
    protected bool active;

    protected override void Start()
    {
        abilityCooldowns[0] = 20;
        base.Start();

    }
    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (!active) return;
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
        currentQ = 0;
        abilityAvailable[0] = false;
        active = true;
        StartCoroutine(Deactivate());
        StartCoroutine(ResetAbility(1));

    }

    protected IEnumerator Deactivate()
    {
        yield return new WaitForSecondsRealtime(7);
        arrow.gameObject.SetActive(false);
        active = false;
    }
}
