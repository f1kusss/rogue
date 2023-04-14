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

        // Ограничиваем скорость в заданных пределах

        // Применяем измененную скорость обратно в Rigidbody

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        rb.velocity = movement * moveSpeed;
    }
}
