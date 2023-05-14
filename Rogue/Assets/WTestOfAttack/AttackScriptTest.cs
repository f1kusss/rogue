using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScriptTest : MonoBehaviour
{
    bool swinging;
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            animator.SetBool("attack", true);
            swinging = true;
        }
        else if (Input.GetButtonUp("Jump")) 
        {
            animator.SetBool("attack", false);
            swinging = false;
        }
    }
}
