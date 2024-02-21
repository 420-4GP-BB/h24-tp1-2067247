using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraJeu : MonoBehaviour
{
    public GameObject pointeur;
    public Transform target; // la position de la balle
    public GameObject Plancher;
    private Vector3 offset= new Vector3(0, 1, -1.5f); // distance entre camera et balle
    private float smoothSpeed = 0.125f; // How smoothly the camera catches up to its target position

    void Start()
    {
        pointeur.SetActive(false);
        ActiverScriptCamera(false); // Disable camera follow at the start
        
    }

    void LateUpdate()
    {
        
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
        
       
        transform.LookAt(target);
       
       
       
    }
    public void ActiverScriptCamera(bool enable)
    {
        this.enabled = enable; 
        pointeur.SetActive(false);
    }


}

