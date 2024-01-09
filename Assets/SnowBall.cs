using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class SnowBall : MonoBehaviour
{
    public int damage;
    public float speed;
    public float lifetime;
    public Rigidbody2D rb;

    public LayerMask whatIsSolid;

    public void Start()
    {
        transform.localScale = new Vector3(1, 1, 0);
        rb = GetComponent<Rigidbody2D>();
        Invoke("DestroySnowBall", lifetime);


        transform.localScale = new Vector3(0.1f, 0.1f, 0f);

        //transform.localEulerAngles = new Vector3(0, 0, Mathf.Atan2(1, -1) * Mathf.Rad2Deg);
        //rb.velocity = transform.right * speed;

        rb.velocity = transform.right * speed;
    }

    public void Update()
    {
        //transform.Translate(Vector3.forward * speed * Time.deltaTime);
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, 0, whatIsSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.tag == "Player")
            {
                Debug.Log("ASd");
                //PlayerControl.main.TakeDamage(damage);
                hitInfo.collider.GetComponent<PlayerControl>().TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
    private void DestroySnowBall()
    {
        Destroy(gameObject);
    }

}
