using UnityEngine;

public class ControleBalle1 : MonoBehaviour
{
    public GameObject pointeur; // Assignez la balle indicateur dans l'inspecteur
    private float puissanceTir = 12f; // Ajustez selon le besoin
    private float vitesseRotation = 20f; // Ajustez selon le besoin
    private Rigidbody rb;
    private float seuilVitesse = 2f;
    public float distancePointeur = 2f;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
       
       

    }

    void Update()
    {
        // Active le pointeur seulement si la balle est immobile
        if (rb.velocity.magnitude < seuilVitesse)
        {
            pointeur.SetActive(true);
            // Ajuster la position du pointeur pour qu'il suive la rotation de la balle
            pointeur.transform.position = transform.position + transform.forward * distancePointeur;

            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
            {
                // Rotation de l'indicateur pour viser
                float rotation = Input.GetKey(KeyCode.RightArrow) ? vitesseRotation : -vitesseRotation;
                rb.transform.Rotate(Vector3.up, rotation * Time.deltaTime);
            }
        }
        else
        {
            pointeur.SetActive(false); // Cache le pointeur lorsque la balle est en mouvement
            Camera.main.GetComponent<CameraJeu>().activerOveriew();
        }

        // Frapper la balle
        if (Input.GetKeyDown(KeyCode.Space) && rb.velocity.magnitude < seuilVitesse)
        {
            rb.AddForce(transform.forward * puissanceTir, ForceMode.VelocityChange);
            Camera.main.GetComponent<CameraJeu>().ActiverScriptCamera(true);
            rb.rotation = Quaternion.identity;
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



}


