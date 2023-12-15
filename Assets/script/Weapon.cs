using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int damage;
    public float distance;
    public LayerMask whatIsSolid;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.DrawRay(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition)- transform.position, Color.red, 2);
            RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition)- transform.position, distance, whatIsSolid);
            if (hitInfo.collider != null)
            {
                if (hitInfo.collider.tag == "Enemy")
                {
                    hitInfo.collider.GetComponent<Enemy>().TakeDamage(damage);
                }
            }
        }
    }
}
