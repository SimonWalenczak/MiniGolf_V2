using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPause : MonoBehaviour
{
    public GameObject ball;
    public GameObject UI;
    public GameObject PauseMenu;
    public CameraController cameraController;

    public void Continue()
    {
        cameraController.canRotate = !cameraController.canRotate;
        UI.SetActive(!UI.activeSelf);
        PauseMenu.SetActive(!PauseMenu.activeSelf);
        ball.SetActive(!ball.activeSelf);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
