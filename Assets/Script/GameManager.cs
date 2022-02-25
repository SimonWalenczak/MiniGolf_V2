using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject ball;
    public GameObject UI;
    public GameObject PauseMenu;
    public CameraController cameraController;

    private void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            Cursor.visible = true;
            cameraController.canRotate = !cameraController.canRotate;
            UI.SetActive(!UI.activeSelf);
            PauseMenu.SetActive(!PauseMenu.activeSelf);
            ball.SetActive(!ball.activeSelf);
        }
    }
    public void Continue()
    {
        cameraController.canRotate = !cameraController.canRotate;
        UI.SetActive(!UI.activeSelf);
        PauseMenu.SetActive(!PauseMenu.activeSelf);
        ball.SetActive(!ball.activeSelf);
    }

    public void Quit()
    {

    #if UNITY_STANDALONE
        Application.Quit();
    #endif

    #if UNITY_EDITOR

        UnityEditor.EditorApplication.isPlaying = false;
    #endif
    }
}