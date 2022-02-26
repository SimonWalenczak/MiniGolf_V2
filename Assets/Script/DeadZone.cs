using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadZone : MonoBehaviour
{
    public Vise_Tir vise_Tir;

    public void OnTriggerEnter(Collider other)
    {
        vise_Tir.rigidbodyA.transform.position = vise_Tir.previousPos;
        vise_Tir.rigidbodyA.velocity = Vector3.zero;
        vise_Tir.rigidbodyA.angularVelocity = Vector3.zero;
    }
}
