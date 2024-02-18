using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraJeu : MonoBehaviour
{
    public GameObject pointeur;
    public Transform target; // la position de la balle
    public Vector3 offset; // distance entre camera et balle
    private float smoothSpeed = 0.125f; // How smoothly the camera catches up to its target position

    void Start()
    {
        ActiverScriptCamera(false); // Disable camera follow at the start
        pointeur.SetActive(false);
    }

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Optionally, make the camera always look at the ball
         transform.LookAt(target);
        //transform.LookAt(pointeur.transform.position);
    }
    public void ActiverScriptCamera(bool enable)
    {
        this.enabled = enable; // Enable or disable this camera follow script
        pointeur.SetActive(false);
    }

    public void activerOveriew (){
        Vector3 nvPosition = new Vector3(-20.3f, 14.9f, -1.2f);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, nvPosition, 1f);
        transform.position = smoothedPosition;
    }
}
