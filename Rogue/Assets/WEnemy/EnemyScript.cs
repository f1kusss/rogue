using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    public int HP = 100;
    public Animator animator;
    public Slider healthBar;

    void Update()
    {
        healthBar.value = HP;
    }
    
    public void TakeDamage(int damageAmount)
    {
        Debug.LogError($"current hp {HP} amount = {damageAmount}");
        HP -= damageAmount;

        if(HP <= 0)
        {
            //animator.SetTrigger("death");
            healthBar.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
        else
        {
            //animator.SetTrigger("damage");

        }
    }

}
