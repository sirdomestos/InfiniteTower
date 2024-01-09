using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    public float speed;
    public float lifetime;
    public Rigidbody2D rb;

    public LayerMask whatIsSolid;

    public void Start()
    {
        UnityEngine.Debug.Log("����");
        rb = GetComponent<Rigidbody2D>();
        Invoke("DestroyBullet", lifetime);


        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        transform.localEulerAngles = new Vector3(0, 0, Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg);

        rb.velocity = transform.right * speed;

    }
    public void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, 0, whatIsSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.TryGetComponent<Enemy>(out var a))
            {
                a.TakeDamage(damage);
            }
            if (hitInfo.collider.TryGetComponent<Boss>(out var b))
            {
                b.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
    private void DestroyBullet()
    {
        Destroy(gameObject);
    }

}
