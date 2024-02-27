using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class MouvementBalle : MonoBehaviour
{
    [SerializeField] private GameObject pointeur; // Assignez le pointeur dans l'inspecteur
    [SerializeField] private GameObject barreForce;
    [SerializeField] public float distancePointeur = 2f;
    [SerializeField] private float vitesseRotation = 50f; // Ajustez selon le besoin
    [SerializeField] private TMP_Text pisteCoup;

    private float puissanceTir; // Ajustez selon le besoin
    private Rigidbody rb;
    private float seuilVitesse = 2f;
    private bool _agrandissementActif;// pour la barre de force
    private Vector3 _vecteurCroissance = new Vector3(0f, 0.005f, 0f);
    private int nbCoups=0;
    private Vector3 dernierePos;




    void Start()
    {


        barreForce.SetActive(false);
        pointeur.SetActive(false);
        //acceder le rigid body de la balle
        rb = GetComponent<Rigidbody>();



    }

    void Update()
    {
        // Rotation de la balle pour viser

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {

            float rotation = Input.GetKey(KeyCode.RightArrow) ? vitesseRotation : -vitesseRotation;
            rb.transform.Rotate(Vector3.up, rotation * Time.deltaTime);

        }



        // Frapper la balle
        if (Input.GetKeyDown(KeyCode.Space) && rb.velocity.magnitude < seuilVitesse)
        {
            dernierePos = transform.position;

            rb.AddForce(transform.forward * puissanceTir, ForceMode.VelocityChange);

            nbCoups += 1;


        }
        arreterBalle();

    }
    private void FixedUpdate()
    {

        if (transform.position.y < -1)
        {
            
            transform.position = dernierePos;
            rb.velocity = Vector3.zero; // Arrête complètement la balle
            rb.angularVelocity = Vector3.zero; // Arrête également toute rotation de la balle
            rb.rotation = Quaternion.identity;
            nbCoups += 1;
        }
    }
    /// <summary>
    /// methode pour arreter la balle quand elle atteint un certain seuil
    /// </summary>
    public void arreterBalle()
    {
        if (rb.velocity.magnitude < seuilVitesse && rb.velocity.magnitude > 0)
        {

            rb.velocity = Vector3.zero; // Arrête complètement la balle
            rb.angularVelocity = Vector3.zero; // Arrête également toute rotation de la balle
            float rotationY = rb.transform.eulerAngles.y;
            rb.transform.eulerAngles = new Vector3(0, rotationY, 0);
        }
    }


    /// <summary>
    /// méthode pour varier la taille de la barre de force
    /// </summary>
    private void varier()
    {
        float scaleY = barreForce.transform.localScale.y;

        if (_agrandissementActif)
        {

            scaleY += _vecteurCroissance.y;
        }
        else
        {
            scaleY -= _vecteurCroissance.y;
        }
        barreForce.transform.localScale = new Vector3(0.2f, scaleY, 0.2f);
        puissanceTir = scaleY * 20;
        // On vérifie si il faut agrandir ou diminuer la taille 

        if (barreForce.transform.localScale.y >= 1.5f)
        {
            _agrandissementActif = false;
        }

        if (barreForce.transform.localScale.y <= 0.1f)
        {
            _agrandissementActif = true;
        }



    }

    //mode tir quand la balle ne bouge pas
    public void activerModeTir()
    {

        varier();

        barreForce.SetActive(true);
        pointeur.SetActive(true);


    }
    //quand la balle est en mouvement, animation debut, fin
    public void desactiverModeTir()
    {
        barreForce.SetActive(false);
        pointeur.SetActive(false);

    }
    public int getNbCoups()
    {
        return nbCoups;
    }

    public void reinitiliserCoups()
    {
       nbCoups=0;
    }
}


