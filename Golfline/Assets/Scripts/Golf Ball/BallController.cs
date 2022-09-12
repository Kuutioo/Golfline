using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BallController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private Slider powerSlider;
    [SerializeField] private TextMeshProUGUI strokeCountLabel;

    [Header("Values")]
    [SerializeField] private float stopVelocity = 0.05f;
    [SerializeField] private float shotPower = 100f;
    [SerializeField] private float maxLineLength = 5f;

    private int strokes;

    private Rigidbody rb;
    private Vector3 lastPosition;

    private SphereCollider ballCollider;

    private bool isIdle;
    private bool isAiming;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        isAiming = false;
        lineRenderer.enabled = false;

        ballCollider = GetComponent<SphereCollider>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isIdle)
            {
                isAiming = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (rb.velocity.magnitude < stopVelocity && isGrounded())
        {
            Stop();
        }

        ProcessAim();
    }

    private void ProcessAim()
    {
        if (!isAiming || !isIdle)
        {
            return;
        }

        Vector3? worldPoint = CastMouseClickRay();

        if (!worldPoint.HasValue)
        {
            return;
        }

        DrawLine(worldPoint.Value);

        if (Input.GetMouseButtonUp(0))
        {
            Shoot(worldPoint.Value);
        }
    }

    private void Shoot(Vector3 worldPoint)
    {
        lastPosition = transform.position;
        isAiming = false;
        lineRenderer.enabled = false;

        powerSlider.value = 0f;

        strokes++;
        strokeCountLabel.text = strokes.ToString();

        Vector3 horizontalWorldPont = new Vector3(worldPoint.x, transform.position.y, worldPoint.z);

        Vector3 direction = (horizontalWorldPont - transform.position).normalized;
        float strength = Mathf.Clamp(Vector3.Distance(transform.position, horizontalWorldPont), 0, maxLineLength);

        rb.AddForce(direction * strength * shotPower);
        isIdle = false;
    }

    private void Stop()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        isIdle = true;
    }

    private void DrawLine(Vector3 worldPoint)
    {
        Vector3[] positions =
        {
            transform.position,
            worldPoint
        };

        Vector3 dir = positions[1] - positions[0];
        float dist = Mathf.Clamp(Vector3.Distance(positions[0], positions[1]), 0, maxLineLength);
        positions[1] = positions[0] + (dir.normalized * dist);

        powerSlider.value = dist;

        lineRenderer.SetPositions(positions);
        lineRenderer.enabled = true;
    }

    private Vector3? CastMouseClickRay()
    {
        Vector3 screenMousePosFar = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.farClipPlane);
        Vector3 screenMousePosNear = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);

        Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosFar);
        Vector3 worldMousePosNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);

        RaycastHit hit;
        if (Physics.Raycast(worldMousePosNear, worldMousePosFar - worldMousePosNear, out hit, float.PositiveInfinity))
        {
            if (hit.collider.CompareTag("Bounding Box"))
            {
                return null;
            }
            return hit.point;
        } 
        else
        {
            return null;
        }
    }

    private bool isGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, ballCollider.transform.position.y);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hole"))
        {
            Debug.Log("Ball in hole");
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.collider.CompareTag("Bounds"))
        {
            transform.position = lastPosition;
            Stop();
        }
        if (col.collider.CompareTag("Bounding Box"))
        {
            transform.position = lastPosition;
            Stop();
        }
    }
}
