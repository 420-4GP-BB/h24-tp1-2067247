using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ControlCam : MonoBehaviour
{
    private  Camera mainCamera; // Référence à la caméra principale
    private Camera mouvementCamera; // Référence à la caméra de mouvement
    private Camera camBalle;
    private GameObject balle;
    private Rigidbody balle_rb;
    MouvementBalle mouvementBalleScript;
    // [SerializeField] private  GameObject pointeur;
    private GameObject pointeur;
   
    // Start is called before the first frame update
    void Start()
    {
         mainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
         mouvementCamera = GameObject.FindWithTag("CameraPiste1").GetComponent<Camera>();
         camBalle= GameObject.FindWithTag("CameraChildBalle").GetComponent<Camera>();
         balle = GameObject.FindWithTag("BalleJoueur");
        pointeur = GameObject.FindWithTag("pointeur");
        balle_rb = balle.GetComponent<Rigidbody>();
        mouvementBalleScript = GameObject.FindObjectOfType<MouvementBalle>();

        pointeur.SetActive(false);
        mainCamera.enabled = true;
        camBalle.enabled = false;
        mouvementCamera.enabled = false;
        
        
    }

    // Update is called once per frame
    void Update()
    {
       
        // Vérifiez si la balle est en mouvement
        if (balle_rb.velocity.magnitude > 0.1f && animationTitre.getAnimation()) // Utilisez un petit seuil pour déterminer "en mouvement"
        {
            // La balle est en mouvement, activez la caméra de mouvement
            mouvementCamera.enabled = true;
            mainCamera.enabled = false;
            //pointeur.SetActive(false);
            mouvementBalleScript.desactiverModeTir();
        }
         else if(animationTitre.getAnimation() && balle_rb.velocity.magnitude < 0.1f)
        { 
            // La balle est immobile, activez la caméra principale
            mouvementCamera.enabled = false;
            mainCamera.enabled = false;
            pointeur.SetActive(true);
            camBalle.enabled = true;
            
            mouvementBalleScript.activerModeTir();



        }
        else
        {
            mouvementCamera.enabled = false;
            mainCamera.enabled = true;
            camBalle.enabled = false;
            //pointeur.SetActive(false);
            mouvementBalleScript.desactiverModeTir();
        }

    }
   
}
