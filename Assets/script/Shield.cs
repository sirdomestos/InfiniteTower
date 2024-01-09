using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : Weapon
{

    public LayerMask whatIsSolid;

    public override void Attack()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position, distance, whatIsSolid);

        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.tag == "Enemy")
            {
                hitInfo.collider.GetComponent<Enemy>().TakeDamage(damage);
            }
            if (hitInfo.collider.tag == "Boss")
            {
                hitInfo.collider.GetComponent<Boss>().TakeDamage(damage);
            }
        }
    }
}
