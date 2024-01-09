using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
//using System.Numerics;
using UnityEngine;
using System.Security.Cryptography;
/*
delegate void ActionDelegate();
public class WeaponLogic 
{
    public static ActionDelegate action;
    public int damage;
    public float distance;
    public LayerMask whatIsSolid;

    
    public float timeAttack;
    public float startTimeAttack;
    public void Start()
    {
    }
    public void Update()
    {
        // ��� ��� �������� ������, �� ���� �� ��������������, �� shotPoint ��������� ��������
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotz = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        Vector3 target = new Vector3(0, 0, Mathf.LerpAngle(transform.localEulerAngles.z, Mathf.Clamp(rotz - 90, -45, 45), 3 * Time.deltaTime));
        transform.localEulerAngles = target;
        {
            if (timeAttack <= 0)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {

                    action();
                    timeAttack = startTimeAttack;
                }
            }
            else
            {
                timeAttack -= Time.deltaTime;
            }
        }
    }
}
*/




public abstract class Weapon : MonoBehaviour
{
    public int damage;
    public float distance;


    public float timeAttack;
    public float startTimeAttack;
    public abstract void Attack();

    public virtual void Start()
    {
    }
    public void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotz = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        Vector3 target = new Vector3(0, 0, Mathf.LerpAngle(transform.localEulerAngles.z, Mathf.Clamp(rotz - 90, -45, 45), 3 * Time.deltaTime));
        transform.localEulerAngles = target;
        {
            if (timeAttack <= 0)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    Attack();
                    timeAttack = startTimeAttack;
                }
            }
            else
            {
                timeAttack -= Time.deltaTime;
            }
        }
    }
}