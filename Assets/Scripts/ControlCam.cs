using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCam : MonoBehaviour
{
    public Camera mainCamera; // Référence à la caméra principale
    public Camera movementCamera; // Référence à la caméra de mouvement
    public Rigidbody ball;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera.enabled = true;
        movementCamera.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Vérifiez si la balle est en mouvement
        if (ball.velocity.magnitude > 0.1f) // Utilisez un petit seuil pour déterminer "en mouvement"
        {
            // La balle est en mouvement, activez la caméra de mouvement
            movementCamera.enabled = true;
            mainCamera.enabled = false;
        }
        else
        {
            // La balle est immobile, activez la caméra principale
            mainCamera.enabled = true;
            movementCamera.enabled = false;
        }

    }
}
