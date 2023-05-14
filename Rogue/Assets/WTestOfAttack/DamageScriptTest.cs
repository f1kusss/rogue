using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScriptTest : MonoBehaviour
{
    public GameObject player;
    public int damageAmount = 20;

    //public Update()
    //{
    //    swinging = player.GetComponent<AttackScriptTest>().swinging;
    //}

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")//&& "swinging"
        {
            other.GetComponent<EnemyScript>().TakeDamage(damageAmount);
        }
    }
}
