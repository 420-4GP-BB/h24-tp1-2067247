using System.Collections;
using UnityEngine;

public class MouvementBalle : MonoBehaviour
{
    [SerializeField] private GameObject pointeur; // Assignez la balle indicateur dans l'inspecteur
    [SerializeField] private GameObject barreForce;
    private float puissanceTir; // Ajustez selon le besoin
    [SerializeField] private float vitesseRotation = 20f; // Ajustez selon le besoin
    private Rigidbody rb;
    private float seuilVitesse = 2f;
    [SerializeField] public float distancePointeur = 2f;
    private float tailleMin =2;
    private float tailleMax=12f;
    private float dure = 2f;
    
    
    

    void Start()
    {

        
        barreForce.SetActive(false);
        pointeur.SetActive(false);
        rb = GetComponent<Rigidbody>();
       
       

    }

    void Update()
    {
        
        // Active le pointeur seulement si la balle est immobile
        if (rb.velocity.magnitude < seuilVitesse)
        {
            

            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
            {
                activerModeTir();
               
                // Rotation de l'indicateur pour viser
                float rotation = Input.GetKey(KeyCode.RightArrow) ? vitesseRotation : -vitesseRotation;
                rb.transform.Rotate(Vector3.up, rotation * Time.deltaTime);

                
                // Ajuster la position du pointeur pour qu'il suive la rotation de la balle
                pointeur.transform.position = transform.position + transform.forward * distancePointeur;
            }
        }
        else
        {
            desactiverModeTir();
        }

        
        // Frapper la balle
        if (Input.GetKeyDown(KeyCode.Space) && rb.velocity.magnitude < seuilVitesse)
        {
            rb.AddForce(transform.forward * puissanceTir, ForceMode.VelocityChange);
            
            // Vérifiez si la vitesse de la balle est inférieure au seuil
            
                arreterBalle();

            
        }
    }

    void FixedUpdate()
    {
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

    private IEnumerator VarierEnBoucle()
    {
        while (true) // Infinite loop to continuously change Y scale
        {
            // Scale Y up
            yield return StartCoroutine(varier(tailleMin, tailleMax, dure));

            // Scale Y down
            yield return StartCoroutine(varier(tailleMax, tailleMin, dure));
        }
    }

    private IEnumerator varier(float valDebut, float valFin, float dure)
    {
        float tempsEcoule = 0f;
        Vector3 tailleDebut = barreForce.transform.localScale;
        while (tempsEcoule < dure)
        {
            tempsEcoule += Time.deltaTime;
            float t = tempsEcoule / dure;
            // 
            float nouvelleTaille = Mathf.Lerp(valDebut/10, valFin/10, t);
            barreForce.transform.localScale = new Vector3(tailleDebut.x, nouvelleTaille, tailleDebut.z); // Apply the new scale, keeping X and Z constant
            puissanceTir = Mathf.Lerp(2f, 20f, t);
            yield return null; // 
        }
        barreForce.transform.localScale = new Vector3(tailleDebut.x, valFin, tailleDebut.z);
        puissanceTir = (valFin == tailleMax) ? 20f : 2f;
    }
    private void activerModeTir()
    {
        barreForce.SetActive(true);
        pointeur.SetActive(true);
        StartCoroutine(VarierEnBoucle());

    }
    private void desactiverModeTir()
    {
        barreForce.SetActive(false);
        pointeur.SetActive(false);
        StopCoroutine(VarierEnBoucle());
    }

}


