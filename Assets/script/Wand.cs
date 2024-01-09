using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Wand : Weapon
{
    public GameObject bullet;
    public Transform shotPoint;
    public override void Attack()
    {
        Instantiate(bullet, shotPoint.position, transform.rotation);
    }
}