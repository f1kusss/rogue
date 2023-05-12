using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump")) animator.SetBool("attack", true);
        else if (Input.GetButtonUp("Jump")) animator.SetBool("attack", false);
    }
}
