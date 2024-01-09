using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Boss : MonoBehaviour
{
    // Start is called before the first frame update
    private EnemySpawner spawner;


    public int health;
    public int own_damage;

    private float StartTime;
    public int damage;

    public bool isMoving;
    public float AttackSpeed = 1;
    public float attackdistance = 2;

    private Animator animator;

    public bool isShooting = true;

    private IEnumerator ChangeMode()
    {
        while (true)
        {
            isShooting = !isShooting;

            yield return new WaitForSeconds(5f);
        }
    }

    private void Start()
    {

        animator = GetComponent<Animator>();
        spawner = GetComponentInParent<EnemySpawner>();
        StartCoroutine(ChangeMode());
        InvokeRepeating("Shoot", 0f, 1f);
    }

    public void startMove()
    {
        isMoving = true;
    }
    public void endMove()
    {
        isMoving = false;
    }
    private void Move()
    {
        animator.SetBool("isMoving", true);

        if (isMoving)
        {
            transform.Translate((PlayerControl.main.transform.position - transform.position).normalized * speed * Time.deltaTime, Space.World);
        }


        if (Vector2.Distance(transform.position, PlayerControl.main.transform.position) < attackdistance && Time.time - StartTime > AttackSpeed)
        {
            PlayerControl.main.TakeDamage(damage);
            StartTime = Time.time;
        }
    }
    //public GameObject snowball;
    public Transform snowball_shotPoint;
    // —сылки на точки спавна пуль

    public GameObject bullet;
    public int bulletSpeed;

    private bool isHorizontalShot;

    private void Shoot()
    {
        if (!isShooting) return;
        GameObject bulletUp = Instantiate(bullet, snowball_shotPoint.position, snowball_shotPoint.rotation);
        GameObject bulletDown = Instantiate(bullet, snowball_shotPoint.position, snowball_shotPoint.rotation);
        GameObject bulletRight = Instantiate(bullet, snowball_shotPoint.position, snowball_shotPoint.rotation);
        GameObject bulletLeft = Instantiate(bullet, snowball_shotPoint.position, snowball_shotPoint.rotation);
        if (isHorizontalShot)
        {
            bulletUp.transform.localEulerAngles = new Vector3(0, 0, Mathf.Atan2(1, 0) * Mathf.Rad2Deg);
            bulletDown.transform.localEulerAngles = new Vector3(0, 0, Mathf.Atan2(-1, 0) * Mathf.Rad2Deg);
            bulletRight.transform.localEulerAngles = new Vector3(0, 0, Mathf.Atan2(0, 1) * Mathf.Rad2Deg);
            bulletLeft.transform.localEulerAngles = new Vector3(0, 0, Mathf.Atan2(0, -1) * Mathf.Rad2Deg);
        } else
        {
            bulletUp.transform.localEulerAngles = new Vector3(0, 0, Mathf.Atan2(1, -1) * Mathf.Rad2Deg);
            bulletDown.transform.localEulerAngles = new Vector3(0, 0, Mathf.Atan2(-1, -1) * Mathf.Rad2Deg);
            bulletRight.transform.localEulerAngles = new Vector3(0, 0, Mathf.Atan2(1, 1) * Mathf.Rad2Deg);
            bulletLeft.transform.localEulerAngles = new Vector3(0, 0, Mathf.Atan2(-1, 1) * Mathf.Rad2Deg);
        }
        
        isHorizontalShot = !isHorizontalShot;
    }
    void Update()
    {
        if (isShooting)
        {
        } else
        {
            Move();
        }

    }
    public int speed;
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
            spawner.enemies.Remove(gameObject);
            PlayerControl.main.xp += 15;
        }
    }

    private void HandleXpChanged(int newXP)
    {
        // чЄта делаем
    }
}