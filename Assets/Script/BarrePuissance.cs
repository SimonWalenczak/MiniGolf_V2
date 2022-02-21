using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarrePuissance : MonoBehaviour
{
    public Vise_Tir vise_Tir;
    public Image barre;

    private void Update()
    {
        barre.fillAmount = vise_Tir.actualPower;
    }
}