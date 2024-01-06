using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    private EnemySpawner spawner;


    public int health;
    public int own_damage;

    private float StartTime;
    public int damage;

    public bool isMoving;
    public float AttackSpeed = 2;
    public float attackdistance = 2;

        private Animator animator;
            private void Start()
        {

            animator = GetComponent<Animator>();
            spawner = GetComponentInParent<EnemySpawner>();

        }

public void startMove(){
    isMoving = true;
}
public void endMove(){
    isMoving = false;
}

    void Update()
    {
        animator.SetBool("isMoving", true);
        if(isMoving){
            transform.Translate((PlayerControl.main.transform.position - transform.position).normalized * speed * Time.deltaTime, Space.World);
        }
        

        if (Vector2.Distance(transform.position, PlayerControl.main.transform.position) < attackdistance && Time.time - StartTime > AttackSpeed)
        {
            PlayerControl.main.TakeDamage(damage);
            StartTime = Time.time;
        }

    }
    public int speed;
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            spawner.enemies.Remove(gameObject);
            Destroy(gameObject);
            PlayerControl.main.xp+=15;
        }
    }

private void HandleXpChanged(int newXP)
{
        // чёта делаем
}
}
