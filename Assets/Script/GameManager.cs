using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public GameObject ball;
    public GameObject UIFin;
    public GameObject PauseMenu;
    public CameraController cameraController;
    public Fade fade;
    public bool can_paused = true;

    private void Update()
    {
        if (Input.GetKeyDown("p") && can_paused == true)
        {
            Cursor.visible = true;
            cameraController.canRotate = !cameraController.canRotate;
            PauseMenu.SetActive(!PauseMenu.activeSelf);
            ball.SetActive(!ball.activeSelf);
        }
    }
    public void Continue()
    {
        cameraController.canRotate = !cameraController.canRotate;
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

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Next()
    {
        fade.fadeOut = true;
        UIFin.transform.DOScale(new Vector3 (0f, 0f, 0f), 0.5f);
        StartCoroutine(NextLevel());
    }
    IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}