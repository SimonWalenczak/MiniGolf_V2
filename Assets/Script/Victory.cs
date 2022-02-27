using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    public GameObject UIFin;
    public GameObject ball;
    public CameraController cameraController;
    public GameManager gameManager;
    public Vise_Tir vise_Tir;

    public int intStar1 = 3;
    public int intStar2 = 2;
    public int intStar3 = 1;

    public GameObject Star1;
    public GameObject Star2;
    public GameObject Star3;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Bravo !!!");
        UIFin.SetActive(true);
        Cursor.visible = true;
        cameraController.canRotate = !cameraController.canRotate;
        ball.SetActive(!ball.activeSelf);
        gameManager.can_paused = false;

        StartCoroutine(Wait());
        InitStar();
    }

    public void InitStar()
    {
        if(vise_Tir.count <= intStar3)
        {
            Star1.SetActive(true);
            StartCoroutine(Wait());
            Star2.SetActive(true);
            StartCoroutine(Wait());
            Star3.SetActive(true);
        }

        if (vise_Tir.count > intStar3 && vise_Tir.count <= intStar2)
        {
            Star1.SetActive(true);
            StartCoroutine(Wait());
            Star2.SetActive(true);
        }

        if (vise_Tir.count > intStar2 && vise_Tir.count <= intStar1)
            Star1.SetActive(true);
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
    }
}
