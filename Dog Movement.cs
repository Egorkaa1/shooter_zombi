using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogMovement : Enemy
{
    [SerializeField] float speed;
    [SerializeField] float detectionDistance;
    public Vector3 followOffset = new Vector3(1f, 0, 0); // Смещение — например, справа

    public Transform playerBody; // Назначьте в инспекторе или программно

    private void Start()
    {
        if (playerBody == null)
        {
            // Например, найти по тегу "Player" или по другому признаку
            GameObject playerObj = GameObject.FindGameObjectWithTag("player");
            if (playerObj != null)
                playerBody = playerObj.transform;
        }
    }

    protected override void Move()
    {
        if (playerBody == null) return;

        // Целевая точка — чуть сбоку от тела
        Vector3 targetPosition = playerBody.position + followOffset;

        float distanceToTarget = Vector3.Distance(transform.position, targetPosition);

        if (distanceToTarget < detectionDistance)
        {
            // Вращение к целевой точке
            Vector3 direction = (targetPosition - transform.position).normalized;
            if (direction != Vector3.zero)
            {
                Quaternion lookRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
            }

            // Идем к целевой точке
            animator.SetBool("Run", true);
            Vector3 moveDirection = (targetPosition - transform.position).normalized;
            rb.MovePosition(transform.position + moveDirection * speed * Time.deltaTime);
        }
        else
        {
            // Стоим, если далеко
            animator.SetBool("Run", false);
        }
    }

    protected override void Attack()
    {
        // Враг ничего не атакует
        animator.SetBool("Attack", false);
    }
}