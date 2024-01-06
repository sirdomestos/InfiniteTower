using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] walls;
    public GameObject WallEffect;
    public GameObject[] enemyTypes;
    public List<GameObject> enemies;
    private bool spawned;
    private bool WallDestroyed;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player") && !spawned){
            spawned = true;
            int rand = Random.Range(3, 5);
            for(int i = 0; i <= rand; i++ ){ 
                GameObject enemyType = enemyTypes[Random.Range(0, enemyTypes.Length)];
                GameObject enemy = Instantiate(enemyType, transform.position + new Vector3(Random.Range(-5,5),Random.Range(-3,3),0), Quaternion.identity, transform);
                enemies.Add(enemy);
            }
            StartCoroutine(CheckEnemies());
        }
    } 
    IEnumerator CheckEnemies(){
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => enemies.Count == 0);
        DestroyWalls();
    }
    public void DestroyWalls(){
        foreach(GameObject wall in walls){
            if(wall != null && wall.transform.childCount != 0){
                Instantiate(WallEffect, wall.transform.position, Quaternion.identity);
                Destroy(wall);
            }
        }
        WallDestroyed = true;
    }
    private void OnTriggerStay2D(Collider2D other){
        if(WallDestroyed && other.CompareTag("Wall")){
            Destroy(other.gameObject);
        }
    }
}
