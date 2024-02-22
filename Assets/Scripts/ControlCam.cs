using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCam : MonoBehaviour
{
    public Camera mainCamera; // Référence à la caméra principale
    public Camera mouvementCamera; // Référence à la caméra de mouvement
    public Camera camBalle;
    public Rigidbody ball;
    public GameObject pointeur;
   
    // Start is called before the first frame update
    void Start()
    {
        pointeur.SetActive(false);
        mainCamera.enabled = true;
        camBalle.enabled = false;
        mouvementCamera.enabled = false;
        
        
    }

    // Update is called once per frame
    void Update()
    {
       
        // Vérifiez si la balle est en mouvement
        if (ball.velocity.magnitude > 0.1f && animationTitre.getAnimation()) // Utilisez un petit seuil pour déterminer "en mouvement"
        {
            // La balle est en mouvement, activez la caméra de mouvement
            mouvementCamera.enabled = true;
            mainCamera.enabled = false;
        }
         else if(animationTitre.getAnimation() && ball.velocity.magnitude < 0.1f)
        { 
            // La balle est immobile, activez la caméra principale
            mouvementCamera.enabled = false;
            mainCamera.enabled = false;
            camBalle.enabled = true;

            
           
        }else
        {
            mouvementCamera.enabled = false;
            mainCamera.enabled = true;
            camBalle.enabled = false;
        }

    }
   
}
