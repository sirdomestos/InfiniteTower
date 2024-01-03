using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
public Direction direction;
public enum Direction{
    Top,
    Bot,
    Left,
    Right,
    None
}


private RoomVars vars;

public int rand;
System.Random rand1 = new System.Random();
private void Awake() {
    rand = rand1.Next(1,4);
 }
private bool spawned = false;
private float waitTime = 3f;
private void Start(){
    vars = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomVars>();
    Destroy(gameObject, waitTime);
    Invoke("Spawn", 0.2f);
}
public void Spawn(){
    if(spawned){
        return;
    }
    if(direction == Direction.Top){
            Instantiate(vars.topRooms[rand], transform.position, vars.topRooms[rand].transform.rotation);
        }
    else if(direction == Direction.Bot){
            Instantiate(vars.botRooms[rand], transform.position, vars.botRooms[rand].transform.rotation);
        }
    else if(direction == Direction.Left){
            Instantiate(vars.leftRooms[rand], transform.position, vars.leftRooms[rand].transform.rotation);
        }
    else if(direction == Direction.Right){
            Instantiate(vars.rightRooms[rand], transform.position, vars.rightRooms[rand].transform.rotation);
        }
        spawned = true;
}
private void OnTriggerStay2D(Collider2D other) {
    if(other.CompareTag("RoomPoint") && other.GetComponent<RoomSpawner>().spawned){
        Destroy(gameObject);
    }
}
}    
