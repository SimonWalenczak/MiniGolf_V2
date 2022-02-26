using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Flag : MonoBehaviour
{
    private bool can_move = false;
    private bool active = false;

    public float speed = 2.5f;
    void Update()
    {
        if (can_move == false && active == false)
        {
            active = true;
            StartCoroutine(ChangeColor2());
        }

        else if (can_move == true && active == false)
        {
            active = true;
            StartCoroutine(ChangeColor1());
        }
    }

    IEnumerator ChangeColor1()
    {
        transform.DOMoveY(0.5f, speed);
        yield return new WaitForSeconds(speed);
        active = false;
        can_move = false;
    }
    IEnumerator ChangeColor2()
    {
        transform.DOMoveY(0.06f, speed);
        yield return new WaitForSeconds(speed);
        active = false;
        can_move = true;
    }
}
