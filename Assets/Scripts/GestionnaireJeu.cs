using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private GameObject balle; // La balle
   // [SerializeField] private TMP_Text champPoints; // Le champs de points qu'on doit mettre à jour
    [SerializeField] private trou1_sujet trou1; // la zone d'arrivée qu'on observe
    // Start is called before the first frame update
    void Start()
    {
        trou1.ZoneAtteinteHandler += baisserBalle;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void baisserBalle()
    {
        Rigidbody rb = balle.GetComponent<Rigidbody>();

        // Verification du component rigidbody
        if (rb != null)
        {
            // arreter le mouvemnt de la balle
            rb.velocity = Vector3.zero;

            // arretre la rotation de la balle
            rb.angularVelocity = Vector3.zero;
        }
        //baisser la balle
        Vector3 positionBalle = balle.transform.position;
        balle.transform.position = new Vector3(positionBalle.x, -0.05f, positionBalle.z);
       
    }
}
