using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Bravo !!!");
        SceneManager.LoadScene(0);
    }
}
