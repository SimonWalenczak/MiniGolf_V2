using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;   

public class Vise_Tir : MonoBehaviour
{
    [SerializeField] private float shotPower;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private float stopVelocity = 0.05f;

    public CameraController cameraController;

    public float maxPower = 1.2f;
    public bool isIdle;
    public bool isAiming;
   
    private Rigidbody rigidbodyA;

    public Image barre;

    public float actualPower;
    public float diffDistance;

    [DllImport("user32.dll")]
    public static extern bool SetCursorPos(int X, int Y);

    private void Awake()
    {
        Cursor.visible = false;

        rigidbodyA = GetComponent<Rigidbody>();

        isAiming = false;
        lineRenderer.enabled = false;
    }

    private void ProccesAim()
    {
        if (!isAiming || !isIdle)
        {
            return;
        }

        Vector3? worldPoint = CastMouseClickRay();
        Vector3 temp = Vector3.zero;

        if(worldPoint != null)
        {
            temp = (Vector3)worldPoint;
        }

        if (!worldPoint.HasValue)
        {
            return;
        }

        DrawLine(worldPoint.Value);

        diffDistance = Vector3.Distance(temp, transform.position);

        if (Input.GetMouseButtonUp(0))
        {
            Shoot(worldPoint.Value);
            cameraController.canRotate = true;
        }


    }

    private void Shoot(Vector3 worldPoint)
    {
        
        isAiming = false;
        lineRenderer.enabled = false;

        Vector3 horizontalWorldPoint = new Vector3(worldPoint.x, transform.position.y, worldPoint.z);

        Vector3 direction = (horizontalWorldPoint - transform.position).normalized;
        float strength = Vector3.Distance(transform.position, horizontalWorldPoint);
        if (strength >= maxPower)
        {
            strength = maxPower;
        }
        actualPower = strength * 1.25f;

        rigidbodyA.AddForce(direction * strength * shotPower);
        isIdle = false;
    }

    private void DrawLine(Vector3 worldPoint)
    {
        Vector3[] positions = { transform.position, worldPoint };
        lineRenderer.SetPositions(positions);
        lineRenderer.enabled = true;
    }

    private Vector3? CastMouseClickRay()
    {
        Vector3 screenMousePosFar = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.farClipPlane);
        Vector3 screenMousePosNear = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);
        Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosFar);
        Vector3 worldMouseNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);
        RaycastHit hit;
        if (Physics.Raycast(worldMouseNear, worldMousePosFar - worldMouseNear, out hit, float.PositiveInfinity))
        {
            return hit.point;
        }
        else
        {
            return null;
        }
    }

    private void Stop()
    {
        rigidbodyA.velocity = Vector3.zero;
        rigidbodyA.angularVelocity = Vector3.zero;
        isIdle = true;
    }
    void Update()
    {
        //Debug.Log(diffDistance);
        barre.fillAmount = diffDistance/4;

        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene(0);
        }

        if (Input.GetKeyDown("escape"))
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }

        if (!isAiming)
        {
            SetCursorPos(Screen.width / 2, Screen.height / 2);
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (isIdle)
            {
                isAiming = true;
                cameraController.canRotate = false;
            }
        }

        if (rigidbodyA.velocity.magnitude < stopVelocity)
        {
            Stop();
        }
        else
        {
            isIdle = false;
        }
        
        ProccesAim();
    }
}
