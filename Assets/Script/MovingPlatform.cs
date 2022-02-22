using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MovingPlatform : MonoBehaviour
{
    #region Initialisation Variables

    public int azerty = 0;
    //public float time = 10f;

    #endregion

    void Update()
    { 
        transform.DOMove(new Vector3(0.5f, 0, 0), 5);
        transform.DOMove(new Vector3(-1.5f, 0, 0), 5);
    }
}
