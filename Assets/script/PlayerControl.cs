using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;


public class PlayerControl : MonoBehaviour
{

    public GameObject keyIcon;
    private bool keyButtonPushed;
    public GameObject wallEffect;

    public static PlayerControl main;
    public float speed;
    public static int maxHealth = 85;

    public int startdamage = 15;
    public int health{
        get{
        return hp;
    }
    set{
        hp = value;
        onHPchange?.Invoke(value);
    }
    }

    private int hp = maxHealth;
    public int exp = 0;

#region LvL
    public int xp
    {
        get => exp; set{
            if (value >= 50){
                LvlUp();
            }
            exp = value%50;
            onXPchange?.Invoke(exp);
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Key")){
            keyIcon.SetActive(true);
            Destroy(other.gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D other){
        if(other.CompareTag("Door") && keyButtonPushed && keyIcon.activeInHierarchy){
            Instantiate(wallEffect, other.transform.position, Quaternion.identity);
            keyIcon.SetActive(false);
            other.gameObject.SetActive(false);
            keyButtonPushed = false;
        }
    }

    public void OnKeyButtonPushed(){
        keyButtonPushed = !keyButtonPushed;
    }

    public void LvlUp()
    {
        lvl ++;
        health += 15;
        startdamage += 5;
        onLVLchange?.Invoke(lvl);
    }
#endregion

    public Action<int> onXPchange;
    public Action<int> onLVLchange;
    public Action<int> onHPchange;

    public int lvl = 0;
    public Sprite HeadFront;
    public Sprite BodyFront;
    public Sprite HeadBack;
    public Sprite BodyBack;
    public Sprite WeaponBack;
    public Sprite WeaponFront;

    public SpriteRenderer HeadRender;
    public SpriteRenderer BodyRender;
    public SpriteRenderer WeaponRender;

    private float moveInputV;
    private float moveInputH;
    private Rigidbody2D rb;
    private bool isDash = false;
    private Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        main = this;
    }
    

    private void FixedUpdate()
    {
        moveInputV = Input.GetAxis("Vertical");
        moveInputH = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInputH * speed, moveInputV * speed);
        animator.SetBool("IsMoving", moveInputV != 0 || moveInputH != 0);
        if(moveInputV > 0){
            HeadRender.sprite = HeadBack;
            BodyRender.sprite = BodyBack;
            WeaponRender.sprite = WeaponBack;
            WeaponRender.sortingOrder = -1;
        }
        else if (moveInputV < 0){
            HeadRender.sprite = HeadFront;
            BodyRender.sprite = BodyFront;
            WeaponRender.sprite = WeaponFront;
            WeaponRender.sortingOrder = 2;
        }
        
        
    }

    private  void Update()
    {
        Dash();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }


    private IEnumerator Dashing(){
        yield return new WaitForSeconds(0.5f);
        speed /= 3;
        isDash = false;
    }

    private void Dash(){
            if(Input.GetKeyDown(KeyCode.LeftShift) && !isDash){
                speed*=3;
                isDash = true;
                StartCoroutine(Dashing());
            }
    }
}

