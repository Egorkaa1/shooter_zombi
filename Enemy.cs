using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float health;
    [SerializeField] protected float attackDistance;
    [SerializeField] protected int damage;
    [SerializeField] protected float cooldown;
    protected GameObject player;
    protected Animator animator;
    protected Rigidbody rb;
    protected float distance;
    protected float timer;
    bool dead = false;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>().gameObject;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);
        if (!dead)
        {
            Attack();
        }
    }
    
    private void FixedUpdate()
    {
        if (!dead)
        {
            Move();
        }
    }

    protected virtual void Move()
    {
    }
    protected virtual void Attack() 
    {
    }

    public void ChangeHealth(int count)
    {
        //отнимаем здоровье
        health -= count;
        //если здоровье меньше, либо равно нулю, то..
        if(health <= 0)
        {
            //меняем значение булевой переменной(перестают работать методы Attack и Move
            dead = true;
            Destroy(gameObject, 10f);
            //включаем анимацию смерти
            animator.SetBool("Die", true);
        }
    }

}
