using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Homer Simpson : C'est nul !");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
