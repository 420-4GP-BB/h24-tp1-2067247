using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementBalle : MonoBehaviour
{
    public ScriptPointeur pointerController; // Assign your PointerController3D script here
    public Rigidbody pointeur; // Assign your pointer object here
    public float launchPower = 10.0f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // When the space bar is pressed
        {
            pointerController.SetVisibility(true); // Make the pointer visible
        }

        if (Input.GetKeyUp(KeyCode.Space)) // When the space bar is released
        {
            LaunchTowardsPointer();
            pointerController.SetVisibility(false); // Hide the pointer after launching
        }
    }

    void LaunchTowardsPointer()
    {
        Vector3 direction = pointeur.position - transform.position;
        direction.Normalize();
        rb.velocity = direction * launchPower;
    }

}
