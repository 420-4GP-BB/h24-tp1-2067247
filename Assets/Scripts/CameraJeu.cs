using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraJeu : MonoBehaviour
{
    public GameObject pointeur;
    public Transform target; // la position de la balle
    public GameObject Plancher;
    private Vector3 offset= new Vector3(0, 1, -2); // distance entre camera et balle
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
        
       
        transform.LookAt(target);
       
       
       
    }
    public void ActiverScriptCamera(bool enable)
    {
        this.enabled = enable; 
        pointeur.SetActive(false);
    }

    public void activerOveriew (){
        Vector3 nvPosition = new Vector3(-20.3f, 25.9f, -1.2f);
        transform.LookAt(Plancher.transform.position);
        transform.position = nvPosition;
       
       
    
}
}

