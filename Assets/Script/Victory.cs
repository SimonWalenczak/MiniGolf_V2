using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    public GameObject pointVert;
    public Fade fade;
    public GameObject text;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Bravo !!!");
        text.SetActive(true);
        fade.fadeOut = true;
        StartCoroutine(NextLevel());
    }

    IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
