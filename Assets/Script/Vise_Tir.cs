using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
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


    public float actualPower;
    public float diffDistance;

    public GameObject sphereIndic;
    public int count = 0;
    public TextMeshProUGUI nb_coups;

    public Material sphere;
    private bool can_change = false;
    public float lerpDuration = 0.7f;
    public float WaitForSeconds1 = 2;
    public float WaitForSeconds2 = 1;

    static float PAS_TOUCHE = 3.65f;

    [DllImport("user32.dll")]
    public static extern bool SetCursorPos(int X, int Y);

    private void Awake()
    {
        Color color = sphere.color;
        color.a = 0;
        sphere.color = color;

        rigidbodyA = GetComponent<Rigidbody>();

        isAiming = false;
        lineRenderer.enabled = false;
    }

    private void ProccesAim()
    {
        Cursor.visible = false;

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
            count++;
            nb_coups.SetText(count.ToString());
            Color color = sphere.color;
            color.a = 0;
            sphere.color = color;
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
        sphereIndic.SetActive(true);
    }



    IEnumerator ChangeColor1()
    {
        Color color = sphere.color;
        color.a = Mathf.Lerp(sphere.color.a, 0f, Time.deltaTime * lerpDuration);
        sphere.color = color;
        if (color.a <= 0)
            color.a = 0;
        yield return new WaitForSeconds(WaitForSeconds1);
        can_change = false;
    }
    IEnumerator ChangeColor2()
    {
        Color color = sphere.color;
        color.a = Mathf.Lerp(sphere.color.a, 1.5f, Time.deltaTime * lerpDuration);
        sphere.color = color;
        if (color.a >= 1)
            color.a = 1;
        yield return new WaitForSeconds(WaitForSeconds2);
        can_change = true;
    }
    void Update()
    {
        if (can_change == false)
            StartCoroutine(ChangeColor2());

        else if(can_change == true)
            StartCoroutine(ChangeColor1());    
        
        if (isAiming)
        {
            float power = diffDistance / PAS_TOUCHE;

            if (power <= 0.165)
            {
                Debug.Log("1");
                lineRenderer.startColor = new Color32(42, 209, 13, 255);
            }
            else if (power <= 0.33)
            {
                Debug.Log("2");
                lineRenderer.startColor = new Color32(112, 209, 14, 255);
            }
            else if (power <= 0.495)
            {
                Debug.Log("3");
                lineRenderer.startColor = new Color32(186, 209, 14, 255);
            }
            else if (power <= 0.66)
            {
                Debug.Log("4");
                lineRenderer.startColor = new Color32(209, 196, 14, 255);
            }
            else if (power <= 0.765)
            {
                Debug.Log("5");
                lineRenderer.startColor = new Color32(209, 124, 14, 255);
            }

            else if (power >= 1)
            {
                Debug.Log("6");
                lineRenderer.startColor = new Color32(209, 43, 13, 255);
            }
        }

        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene(0);
        }

        if (Input.GetKeyDown("escape"))
        {
            UnityEditor.EditorApplication.isPlaying = false;
            //Application.Quit();
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
            sphereIndic.SetActive(false);
        }
        
        ProccesAim();
    }
}
