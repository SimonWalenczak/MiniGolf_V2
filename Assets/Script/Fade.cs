using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Fade : MonoBehaviour
{
    public Image image;
    public bool fadeOut = false;

    private void Start()
    {
        image.DOFade(0, 2);
    }
    void Update()
    {
        if (fadeOut == true)
            image.DOFade(1, 2);
    }
}
