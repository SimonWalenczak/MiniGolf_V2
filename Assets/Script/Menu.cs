using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject Panel;
    public GameObject Fader;

    private void Awake()
    {
        Cursor.visible = true;
    }
    private void Start()
    {
        StartCoroutine(Fade());
        Fader.SetActive(false);
    }
    IEnumerator Fade()
    {
        yield return new WaitForSeconds(2);  
    }
    public void OnClickPlay()
    {
        SceneManager.LoadScene(1);
    }

    public void OnClickQuit()
    {
        #if UNITY_STANDALONE
                Application.Quit();
        #endif
        
        #if UNITY_EDITOR
        
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
    public void OnClickCredit()
    {
        Panel.SetActive(!Panel.activeSelf);
    }
}
