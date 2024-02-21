using UnityEngine;

public class ControleBalle : MonoBehaviour
{
    public GameObject pointeur; // Assignez la balle indicateur dans l'inspecteur
    private float puissanceTir = 12f; // Ajustez selon le besoin
    private float vitesseRotation = 20f; // Ajustez selon le besoin
    private Rigidbody rb;
    private float distancePointeur = 2f;
    private float seuilVitesse = 2f;
    
   

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        pointeur.SetActive(false);
        AjusterPositionPointeur();

    }

    void Update()
    {
        // Active le pointeur seulement si la balle est immobile
        if (rb.velocity.magnitude < seuilVitesse)
        {
            pointeur.SetActive(true);
            AjusterPositionPointeur();
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
            {

                // Rotation de l'indicateur pour viser
                float rotation = Input.GetKey(KeyCode.RightArrow) ? vitesseRotation : -vitesseRotation;
                pointeur.transform.RotateAround(transform.position, Vector3.up, rotation * Time.deltaTime);
              
            }

        }
        else
        {
           // Camera.main.GetComponent<CameraJeu>().activerOveriew();
            pointeur.SetActive(false); // Cache le pointeur lorsque la balle est en mouvement
           
        }
        
        // Frapper la balle
        if (Input.GetKeyDown(KeyCode.Space) && rb.velocity.magnitude < seuilVitesse) // Assure que la balle est immobile avant de tirer
        {
            
            Vector3 direction = pointeur.transform.position - transform.position;
            rb.AddForce(direction.normalized * puissanceTir, ForceMode.VelocityChange);
            
            Camera.main.GetComponent<CameraJeu>().ActiverScriptCamera(true);
        }
    }

    void FixedUpdate()
    {
        // Vérifiez si la vitesse de la balle est inférieure au seuil
        if (rb.velocity.magnitude < seuilVitesse && rb.velocity.magnitude > 0)
        {
            rb.velocity = Vector3.zero; // Arrête complètement la balle
            rb.angularVelocity = Vector3.zero; // Arrête également toute rotation de la balle
        }
    }
    void AjusterPositionPointeur()
    {
        // Ajuste la position de l'indicateur pour qu'il soit toujours à une distance fixe devant la balle
        Vector3 direction = (pointeur.transform.position - transform.position).normalized;
        pointeur.transform.position = transform.position + direction * distancePointeur;
    }
}


