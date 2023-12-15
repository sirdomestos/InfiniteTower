using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public int health;
    public int own_damage;

    private float StartTime;
    public int damage;

    public float AttackSpeed = 2;
    public float attackdistance = 2;

        private Animator animator;
            private void Start()
        {

            animator = GetComponent<Animator>();

        }


    void Update()
    {

        transform.Translate((PlayerControl.main.transform.position - transform.position).normalized * speed * Time.deltaTime, Space.World);
        animator.SetBool("isMoving", true);
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
            Destroy(gameObject);
        }
    }
}
