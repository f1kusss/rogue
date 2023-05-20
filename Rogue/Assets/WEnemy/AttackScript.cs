using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackScript : MonoBehaviour
{
    public int damageAmount;
    public LayerMask layerMask;
    public Button button;

    public void DoDamage()
    {
        var targets = Physics.OverlapSphere(transform.position, 2, layerMask, QueryTriggerInteraction.Ignore);
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

        button.onClick.AddListener(Attack);
    }

    void Update()
    {
        if (Input.GetButtonDown("attack")) animator.SetBool("attack", true);
        else if (Input.GetButtonUp("attack")) animator.SetBool("attack", false);
    }

    void Attack() 
    {
        animator.SetBool("attack", true);

        Invoke("StopAttack", 0.5f);
    }

    void StopAttack() 
    {
 animator.SetBool("attack", false);

    }
}
