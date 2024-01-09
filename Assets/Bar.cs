using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Bar : MonoBehaviour
{
    public Image HpBar;
    public Image XpBar;

    // Start is called before the first frame update
    void Start()
    {
        PlayerControl.main.onHPchange += (a) => {HpBar.fillAmount = (float)a/PlayerControl.maxHealth;};     
        PlayerControl.main.onXPchange += (a) => {XpBar.fillAmount = (float)a/50;};
    }

}
