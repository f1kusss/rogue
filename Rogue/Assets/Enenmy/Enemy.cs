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


    float AttackCooldown = 0;
    PlayerStats PlayerStats;


    void Start()
    {
        Player = GameObject.Find("Mage");
        rigidbody = GetComponent<Rigidbody>();
        PatrolPoints = Player.GetComponent<Transform>();
    }

    void Update()
    {
        
        AttackCooldown -= Time.deltaTime;

        Vector3 Playerpos = PatrolPoints.position;
        Vector3 DoorUPos = Room.DoorU.transform.position;
        Vector3 DoorDPos = Room.DoorD.transform.position;
        Vector3 DoorLPos = Room.DoorL.transform.position;
        Vector3 DoorRPos = Room.DoorR.transform.position;
        GameObject DoorU = Room.DoorU;
        GameObject DoorD = Room.DoorD;
        GameObject DoorR = Room.DoorR;
        GameObject DoorL = Room.DoorL;

        Vector3 movementVector = PatrolPoints.position - transform.position;
        movementVector.Normalize();
        transform.LookAt(PatrolPoints.position);  
         
        if (PlayerStats) 
        {
            if ( AttackCooldown <= 0) 
            {
                PlayerStats.ApplyDamage(20);
                AttackCooldown = 3;
            }
        } 
        else if (Playerpos.z + 1 < DoorUPos.z && Playerpos.x + 1 < DoorRPos.x && Playerpos.z - 1 > DoorDPos.z && Playerpos.x - 1 > DoorLPos.x)
        {

            
            rigidbody.velocity = movementVector * Speed;
            
            if (Room.EnemyCount != 0)
            {
                if (DoorU.activeSelf == false)
                {
                    DoorU.SetActive(true);
                    UDoor = DoorU;
                }
                else if (DoorD.activeSelf == false)
                {
                    DoorD.SetActive(true);
                    DDoor = true;
                }
                else if (DoorR.activeSelf == false)
                {
                    DoorR.SetActive(true);
                    RDoor = true;
                }
                else if (DoorL.activeSelf == false)
                {
                    DoorL.SetActive(true);
                    LDoor = true;
                }
            }
            else
            {
                if (LDoor == true)
                {
                    DoorL.SetActive(false);
                }
                if (RDoor == true)
                {
                    DoorR.SetActive(false);
                }
                if (UDoor == true)
                {
                    DoorU.SetActive(false);
                }
                if (DDoor == true)
                {
                    DoorD.SetActive(false);
                }
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
}