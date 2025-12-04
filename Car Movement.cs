using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CarMovement : MonoBehaviour
{
    public float speed = 5.0f;       // Скорость движения
    public float turnSpeed = 100.0f; // Скорость поворота
    void Update()
    {
        // Получение ввода от пользователя
        float horizontalInput = Input.GetAxis("Horizontal"); // Ввод влево/вправо
        float verticalInput = Input.GetAxis("Vertical");     // Ввод вперед/назад
        // Движение вперед/назад
        transform.Translate(-Vector3.forward * verticalInput * speed * Time.deltaTime);
        // Поворот влево/вправо
        transform.Rotate(Vector3.up * horizontalInput * turnSpeed * Time.deltaTime);
    }
}