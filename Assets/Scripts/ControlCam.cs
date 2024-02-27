using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ControlCam : MonoBehaviour
{
    private Camera mainCamera; // Référence à la caméra principale
    private Camera mouvementCamera; // Référence à la caméra de mouvement
    private Camera camBalle;// referebce à la camera qui suit la balle
    private GameObject balle;//le joueur
    private Rigidbody balle_rb;//rb de la balle
    private MouvementBalle mouvementBalleScript;//instance du script mouvement balle, pour controller l'apparition du pointeur et de la barre de force
    [SerializeField] private float moveSpeed = 5f; // Vitesse de déplacement de la caméra
    [SerializeField] private TMP_Text pisteCoup;
    // Vecteurs de déplacement pour deplacer la camera
    private Vector3 upVector = new Vector3(1, 0, 1); //  pour le mouvement vers le haut
    private Vector3 downVector = new Vector3(-1, 0, -1); // Pour le mouvement vers le bas
    private GameObject pointeur;

    // Start is called before the first frame update
    void Start()
    {
        //initialisation des variables pour eviter de les rentrer dans l'inspecteur, j'ai utilisé des tag
        mainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        mouvementCamera = GameObject.FindWithTag("CameraPiste").GetComponent<Camera>();
        camBalle = GameObject.FindWithTag("CameraChildBalle").GetComponent<Camera>();
        balle = GameObject.FindWithTag("BalleJoueur");
        pointeur = GameObject.FindWithTag("pointeur");
        balle_rb = balle.GetComponent<Rigidbody>();
        mouvementBalleScript = GameObject.FindObjectOfType<MouvementBalle>();
        pisteCoup.gameObject.SetActive(false);

        //initialisation des cameras et cacher le pointeur et la barre de force
        pointeur.SetActive(false);
        mainCamera.enabled = true;
        camBalle.enabled = false;
        mouvementCamera.enabled = false;


    }

    // Update is called once per frame
    void Update()
    {


        if (balle.transform.position.y < 0.2f)
        {// la camera regrade d'en haut quand la balle tombe
            OverviewPiste();
        }
        // Vérifiez si la balle est en mouvement
        else if (balle_rb.velocity.magnitude > 0.1f && animationTitre.getAnimation()) // Utilisez un petit seuil pour déterminer "en mouvement"
        {
            OverviewPiste();
        }
        else if (animationTitre.getAnimation() && balle_rb.velocity.magnitude < 0.1f)
        {
            pisteCoup.gameObject.SetActive(true);
            // si la balle est immobile,la caméra principale est activée
            SuivreBalle();
            mouvementBalleScript.activerModeTir();
            //deplacer la camera avec la fleche vers le haut ou fleche vers le bas
            if (Input.GetKey(KeyCode.UpArrow))
            {
                MoveCamera(upVector);

            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                MoveCamera(downVector);
            }
        }
        else
        {//activation de l'animation
            AnimationTitre();
            mouvementBalleScript.desactiverModeTir();
        }




    }
    void MoveCamera(Vector3 direction)
    {
        // Déplace la caméra dans la direction spécifiée
        camBalle.transform.localPosition += direction.normalized * moveSpeed * Time.deltaTime;
    }
    /// <summary>
    /// La camera qui suit la balle est activée
    /// </summary>
    private void SuivreBalle()
    {
        mouvementCamera.enabled = false;
        mainCamera.enabled = false;
        pointeur.SetActive(true);
        camBalle.enabled = true;
    }
    /// <summary>
    /// La camera d'en haut est activée
    /// </summary>
    private void OverviewPiste()
    {

        mouvementCamera.enabled = true;
        mainCamera.enabled = false;
        mouvementBalleScript.desactiverModeTir();
    }
    /// <summary>
    /// La camera du début est activée pour l'animation
    /// </summary>
    public void AnimationTitre()
    {
        mouvementCamera.enabled = false;
        mainCamera.enabled = true;
        camBalle.enabled = false;
    }

}
