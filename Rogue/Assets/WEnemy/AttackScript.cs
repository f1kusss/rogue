using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public int damageAmount;
    public LayerMask layerMask;

    public void DoDamage()
    {
        Debug.LogError("Do Damage");
        var targets = Physics.OverlapSphere(transform.position, 3, layerMask, QueryTriggerInteraction.Ignore);
        foreach (var item in targets)
        {
            if (item.tag == "Enemy")
        {
            item.GetComponent<EnemyScript>().TakeDamage(damageAmount);
        }
        }
    }
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetButtonDown("attack")) animator.SetBool("attack", true);
        else if (Input.GetButtonUp("attack")) animator.SetBool("attack", false);
    }
}
