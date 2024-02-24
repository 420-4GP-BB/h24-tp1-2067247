using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GestionnaireJeu : MonoBehaviour
{
    [SerializeField] private GameObject balle; // La balle
   // [SerializeField] private TMP_Text champPoints; // Le champs de points qu'on doit mettre à jour
    [SerializeField] private trou1_sujet trou1; // la zone d'arrivée qu'on observe
    private bool piste1Finie = false;
   [SerializeField] private Camera mouvementCamera;

    // Start is called before the first frame update
    void Start()
    {
        trou1.ZoneAtteinteHandler += replacerBalle;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void replacerBalle()
    {
        Rigidbody rb = balle.GetComponent<Rigidbody>();
        piste1Finie = true;
        // Verification du component rigidbody
        if (rb != null)
        {
            // arreter le mouvemnt de la balle
            rb.velocity = Vector3.zero;

            // arretre la rotation de la balle
            rb.angularVelocity = Vector3.zero;
        }

        //Replacer à la prochaine piste

        balle.transform.position = new Vector3(-4.14f, 0.27f, -5.4f);
        mouvementCamera.transform.position = new Vector3(0.03f,16.11f,-0.25f);

    }

    public bool getEtatPiste1()
    {
        return piste1Finie;
    }

}
