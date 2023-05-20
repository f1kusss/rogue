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
    bool LDoor, RDoor, DDoor, UDoor;
    GameObject DoorU, DoorD, DoorR, DoorL;
    Vector3 Playerpos, DoorUPos, DoorDPos, DoorLPos, DoorRPos;


    float AttackCooldown = 0;
    PlayerStats PlayerStats;


    void Start()
    {
        Player = GameObject.Find("Mage");
        rigidbody = GetComponent<Rigidbody>();
        PatrolPoints = Player.GetComponent<Transform>();
        
        DoorUPos = Room.DoorU.transform.position;
        DoorDPos = Room.DoorD.transform.position;
        DoorLPos = Room.DoorL.transform.position;
        DoorRPos = Room.DoorR.transform.position;
        DoorU = Room.DoorU;
        DoorD = Room.DoorD;
        DoorR = Room.DoorR;
        DoorL = Room.DoorL;
    }

    void Update()
    {
        
        AttackCooldown -= Time.deltaTime;


        Playerpos = PatrolPoints.position;
        Vector3 movementVector = PatrolPoints.position - transform.position;
        movementVector.Normalize();
        transform.LookAt(PatrolPoints.position);

        if (PlayerStats)
        {
            if (AttackCooldown <= 0)
            {
                PlayerStats.ApplyDamage(20);
                AttackCooldown = 3;
            }
        }
        else
        if (Playerpos.z + 1 < DoorUPos.z && Playerpos.x + 1 < DoorRPos.x && Playerpos.z - 1 > DoorDPos.z && Playerpos.x - 1 > DoorLPos.x)
        {
            rigidbody.velocity = movementVector * Speed;
            LockDoor();
            
            
        }
        
    }

    void LockDoor()
    {
        Debug.LogError("LookDoor");
        if (Room.EnemyCount > 0)
            {
                if (DoorU.activeSelf == false)
                {
                    DoorU.SetActive(true);
                    UDoor = true;
                }
                if (DoorD.activeSelf == false)
                {
                    DoorD.SetActive(true);
                    DDoor = true;
                }
                if (DoorR.activeSelf == false)
                {
                    DoorR.SetActive(true);
                    RDoor = true;
                }
                if (DoorL.activeSelf == false)
                {
                    DoorL.SetActive(true);
                    LDoor = true;
                }
            } 
    }

    
    void OnTriggerEnter(Collider other) 
    {
        PlayerStats playerStats = other.gameObject.GetComponent<PlayerStats>();

        if (playerStats) 
        {
            PlayerStats = playerStats;
        }
    }

    void OnTriggerExit(Collider other) 
    {
        PlayerStats playerStats = other.gameObject.GetComponent<PlayerStats>();

        if (playerStats) 
        {
            PlayerStats = null;
        }
    }
    private void OnDisable()
    {

        Room.RigidsList.Remove(transform);
        if (Room.EnemyCount > 0)
        {
            // if (DoorU.activeSelf == false)
            // {
            //     DoorU.SetActive(true);
            //     UDoor = true;
            // }=-
            // if (DoorD.activeSelf == false)
            // {
            //     DoorD.SetActive(true);
            //     DDoor = true;
            // }
            // if (DoorR.activeSelf == false)
            // {
            //     DoorR.SetActive(true);
            //     RDoor = true;
            // }
            // if (DoorL.activeSelf == false)
            // {
            //     DoorL.SetActive(true);
            //     LDoor = true;
            // }
        }
        else
        {
            Debug.LogError($"OpenRoom {Room.gameObject.name}");
            if (LDoor == true)
            {
                Debug.LogError($"OpenDoorL {Room.gameObject.name}");
                DoorL.SetActive(false);
            }
            if (RDoor == true)
            {
                Debug.LogError($"OpenDoorR {Room.gameObject.name}");
                DoorR.SetActive(false);
            }
            if (UDoor == true)
            {
                Debug.LogError($"OpenDoorU {Room.gameObject.name}");
                DoorU.SetActive(false);
            }
            if (DDoor == true)
            {
                Debug.LogError($"OpenDoorD {Room.gameObject.name}");
                DoorD.SetActive(false);
            }
        }
    }
}