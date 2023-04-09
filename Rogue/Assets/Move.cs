using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float moveSpeed = 15f; // скорость движения
    public Rigidbody rb; // Rigidbody объекта

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {

        // Получаем текущую скорость Rigidbody
        Vector3 velocity = rb.velocity;

        // Ограничиваем скорость в заданных пределах
        velocity = Vector3.ClampMagnitude(velocity, 8f);

        // Применяем измененную скорость обратно в Rigidbody
        rb.velocity = velocity;

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        rb.AddForce(movement * moveSpeed);
    }
}
