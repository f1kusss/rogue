using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Speed;
    public List<Transform> PatrolPoints;
    int Iterator;

    Rigidbody rigidbody;

    void Start()
    {
        Iterator = 0;

        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if ((PatrolPoints[Iterator].position - transform.position).magnitude < 1) 
        {
            Iterator++;
            Iterator %= PatrolPoints.Count;
        }

        Vector3 movementVector = PatrolPoints[Iterator].position - transform.position;
        movementVector.Normalize();

        rigidbody.velocity = movementVector * Speed;
        transform.LookAt(PatrolPoints[Iterator].position);
    }
}
