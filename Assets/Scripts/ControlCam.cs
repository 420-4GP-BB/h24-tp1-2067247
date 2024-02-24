using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ControlCam : MonoBehaviour
{
    private Camera mainCamera; // Référence à la caméra principale
    private Camera mouvementCamera; // Référence à la caméra de mouvement
    private Camera camBalle;
    private GameObject balle;
    private Rigidbody balle_rb;
    private MouvementBalle mouvementBalleScript;
    private GestionnaireJeu gestionnaireJeu;
    // [SerializeField] private  GameObject pointeur;
    private GameObject pointeur;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        mouvementCamera = GameObject.FindWithTag("CameraPiste").GetComponent<Camera>();
        camBalle = GameObject.FindWithTag("CameraChildBalle").GetComponent<Camera>();
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
        

            if (balle.transform.position.y < 0.2f)
            {
                OverviewPiste();
            }
            // Vérifiez si la balle est en mouvement
            else if (balle_rb.velocity.magnitude > 0.1f && animationTitre.getAnimation()) // Utilisez un petit seuil pour déterminer "en mouvement"
            {
                OverviewPiste();
            }
            else if (animationTitre.getAnimation() && balle_rb.velocity.magnitude < 0.1f)
            {
                // La balle est immobile, activez la caméra principale
                SuivreBalle();
                mouvementBalleScript.activerModeTir();
            }
            else
            {
                AnimationTitre();
                mouvementBalleScript.desactiverModeTir();
            }
        
    }

    private void SuivreBalle()
    {
        mouvementCamera.enabled = false;
        mainCamera.enabled = false;
        pointeur.SetActive(true);
        camBalle.enabled = true;
    }
    private void OverviewPiste()
    {

        mouvementCamera.enabled = true;
        mainCamera.enabled = false;
        mouvementBalleScript.desactiverModeTir();
    }
    private void AnimationTitre()
    {
        mouvementCamera.enabled = false;
        mainCamera.enabled = true;
        camBalle.enabled = false;
    }

}
