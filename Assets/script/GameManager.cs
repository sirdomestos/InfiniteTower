using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int SelectedHero = 0;
    public PlayerControl[] heroes;

    public DifficultObject currentDff;

    void Start()
    {
        foreach (Enemy enemy in currentDff.enemies){
            //создаем что, где, поворот
            Instantiate(enemy, new Vector3(Random.Range(-5,5),Random.Range(-3,3),0), Quaternion.identity);
        }
        heroes[SelectedHero].gameObject.SetActive(true);
    }


}
