using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float moveSpeed = 15f; // �������� ��������
    public Rigidbody rb; // Rigidbody �������

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {

        // �������� ������� �������� Rigidbody
        Vector3 velocity = rb.velocity;

        // ������������ �������� � �������� ��������
        velocity = Vector3.ClampMagnitude(velocity, 8f);

        // ��������� ���������� �������� ������� � Rigidbody
        rb.velocity = velocity;

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        rb.AddForce(movement * moveSpeed);
    }
}
