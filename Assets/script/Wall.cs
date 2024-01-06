using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Wall : MonoBehaviour
{
    public GameObject block;
    private void OnTriggerStay2D(Collider2D other){
        if(other.CompareTag("Block")){
            Instantiate(block, transform.GetChild(0).position, Quaternion.identity);
            Instantiate(block, transform.GetChild(1).position, Quaternion.identity);      
            Destroy(gameObject);
        }
    }
}
