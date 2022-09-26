using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vortex : MonoBehaviour
{
    [SerializeField] private float vortexForce;

    private CapsuleCollider vortexCollider;
    private BallController ballController;

    private void Awake()
    {
        vortexCollider = GetComponent<CapsuleCollider>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Vector3 normal = other.transform.position - vortexCollider.bounds.center;
            other.attachedRigidbody.AddForce(normal * -vortexForce);
        }
    }
}
