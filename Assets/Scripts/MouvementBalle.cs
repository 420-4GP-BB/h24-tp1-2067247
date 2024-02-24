using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class MouvementBalle : MonoBehaviour
{
    [SerializeField] private GameObject pointeur; // Assignez la balle indicateur dans l'inspecteur
    [SerializeField] private GameObject barreForce;
    private float puissanceTir; // Ajustez selon le besoin
    [SerializeField] private float vitesseRotation = 50f; // Ajustez selon le besoin
    private Rigidbody rb;
    private float seuilVitesse = 2f;
    [SerializeField] public float distancePointeur = 2f;
    private bool _agrandissementActif;
    private Vector3 _vecteurCroissance = new Vector3(0f, 0.005f, 0f);




    void Start()
    {


        barreForce.SetActive(false);
        pointeur.SetActive(false);
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
        Debug.Log(puissanceTir);

        // Frapper la balle
        if (Input.GetKeyDown(KeyCode.Space) && rb.velocity.magnitude < seuilVitesse)
        {

            rb.AddForce(transform.forward * puissanceTir, ForceMode.VelocityChange);

        }
        arreterBalle();
    }

    private void arreterBalle()
    {
        if (rb.velocity.magnitude < seuilVitesse && rb.velocity.magnitude > 0)
        {

            rb.velocity = Vector3.zero; // Arrête complètement la balle
            rb.angularVelocity = Vector3.zero; // Arrête également toute rotation de la balle
            float rotationY = rb.transform.eulerAngles.y;
            rb.transform.eulerAngles = new Vector3(0, rotationY, 0);
        }
    }



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
        // On regarde s'il faut agrandir ou diminuer la taille pour la prochain it�ration

        if (barreForce.transform.localScale.y >= 1.5f)
        {
            _agrandissementActif = false;
        }

        if (barreForce.transform.localScale.y <= 0.1f)
        {
            _agrandissementActif = true;
        }



    }


    public void activerModeTir()
    {

        varier();

        barreForce.SetActive(true);
        pointeur.SetActive(true);


    }
    public void desactiverModeTir()
    {
        barreForce.SetActive(false);
        pointeur.SetActive(false);

    }

}


