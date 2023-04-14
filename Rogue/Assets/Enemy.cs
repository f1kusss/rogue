using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Speed;
    public Room Room;
    public Transform PatrolPoints;
    GameObject Player;
    Rigidbody rigidbody;

    void Start()
    {
        Player = GameObject.Find("character_mage");
        rigidbody = GetComponent<Rigidbody>();
        PatrolPoints = Player.GetComponent<Transform>();
    }

    void Update()
    {
        Vector3 Playerpos = PatrolPoints.position;
        Vector3 DoorUPos = Room.DoorU.transform.position;
        Vector3 DoorDPos = Room.DoorD.transform.position;
        Vector3 DoorLPos = Room.DoorL.transform.position;
        Vector3 DoorRPos = Room.DoorR.transform.position;
        if (Playerpos.z < DoorUPos.z && Playerpos.x < DoorRPos.x && Playerpos.z > DoorDPos.z && Playerpos.x > DoorLPos.x)
        {
            Vector3 movementVector = PatrolPoints.position - transform.position;
            movementVector.Normalize();

            rigidbody.velocity = movementVector * Speed;
            transform.LookAt(PatrolPoints.position);
        }
        
    }
}
