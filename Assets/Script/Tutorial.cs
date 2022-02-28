using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public Vise_Tir vise_Tir;
    public GameObject UI_Tuto_1;
    public GameObject UI_Tuto_2;

    private void Update()
    {
        if(vise_Tir.count == 1)
        {
            UI_Tuto_1.SetActive(false);
            UI_Tuto_2.SetActive(true);
        }

        else if (vise_Tir.count == 2)
        {
            UI_Tuto_2.SetActive(false);
        }
    }
}
