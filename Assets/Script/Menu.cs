using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject Panel;

    public void OnClickPlay()
    {
        SceneManager.LoadScene(1);
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }
    public void OnClickCredit()
    {
        Panel.SetActive(!Panel.activeSelf);
    }
}
