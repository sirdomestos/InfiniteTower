using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int SelectedHero = 0;
    public PlayerControl[] heroes;

    public DifficultObject currentDff;

    void Awake()
    {
        heroes[SelectedHero].gameObject.SetActive(true);
    }


}
