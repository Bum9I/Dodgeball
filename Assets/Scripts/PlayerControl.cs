using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float _forceValue;
    [SerializeField] private LayerMask _layer;

    private const string PLANE_TAG = "Plane";
    private const string CYLINDER_TAG = "Cylinder";
    private const string SPHERE_TAG = "Sphere";

    private void Update()
    {
        if (!Input.GetMouseButtonDown(0)) return;
        Vector3 clickPosition = GetMouseWorldPosition();
        if (clickPosition == Vector3.zero) return;
        Vector3 direction = clickPosition - transform.position;
        direction.Normalize();

        Vector3 force = direction * _forceValue;

        gameObject.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag(PLANE_TAG))
        {
            transform.position = new Vector3(0, 0.5f, 0);
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(CYLINDER_TAG))
        {
            if (collision.gameObject.GetComponent<Renderer>().material.color == GetComponent<Renderer>().material.color)
            {
                Destroy(collision.gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag(SPHERE_TAG))
        {
            GetComponent<Renderer>().material.color = collider.gameObject.GetComponent<Renderer>().material.color;
            collider.GetComponent<Sphere>().ChangeColorAndMove();
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, 50f, _layer))
        {
            return hitInfo.point;
        }

        return Vector3.zero;
    }
}