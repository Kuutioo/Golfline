using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vortex : MonoBehaviour
{
    [SerializeField] private float vortexForce;

    private BoxCollider boxCollider;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Vector3 normal = other.transform.position - boxCollider.bounds.center;
            other.attachedRigidbody.AddForce(normal * -vortexForce);
        }
    }
}
