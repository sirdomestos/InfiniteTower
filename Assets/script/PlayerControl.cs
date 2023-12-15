using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // Start is called before the first frame update

    public static PlayerControl main;
    public float speed;

    public  int health;
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
    private void Start()
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



    private  void Update(){
        Dash();
    }


    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }


    private IEnumerator Dashing(){
        yield return new WaitForSeconds(0.5f);
        speed /= 5;
        isDash = false;
    }

    private void Dash(){
            if(Input.GetKeyDown(KeyCode.LeftShift) && !isDash){
                speed*=5;
                isDash = true;
                StartCoroutine(Dashing());
            }
    }
}

