using UnityEngine;
using System.Collections;
public class Move : MonoBehaviour 
{
    public GameObject player;
    float speedRotation = 1.5f;
    int speed = 7;
    Rigidbody PlayerRigid;

    void Start () 
    {
        PlayerRigid = player.GetComponentInChildren<Rigidbody>();
    }
    void Update()
    {
    if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) 
      {
            PlayerRigid.velocity = transform.forward * speed;
        }
        else
        {
            PlayerRigid.velocity = transform.forward * 0;
        }
    if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) 
      {
            PlayerRigid.velocity = -transform.forward * speed; 
      } 
    if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) 
      { 
        player.transform.Rotate(Vector3.down * speedRotation); 
      } 
    if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) 
      { 
        player.transform.Rotate(Vector3.up * speedRotation); 
      } 
    }
}