using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GestionnaireJeu : MonoBehaviour
{
    [SerializeField] private GameObject balle; // La balle
    [SerializeField] private TMP_Text message; // Le champs de points qu'on doit mettre à jour
    [SerializeField] private trou1_sujet trou1; // la zone d'arrivée qu'on observe
    [SerializeField] private trou2_sujet trou2; // la zone d'arrivée qu'on observe
    [SerializeField] private Camera mouvementCamera;
    private MouvementBalle mouvementBalle;

    // Start is called before the first frame update
    void Start()
    {
        message.gameObject.SetActive(false);
        mouvementBalle = balle.GetComponent<MouvementBalle>();
        trou1.ZoneAtteinteHandler += replacerBalle;
        trou2.ZoneAtteinteHandler += replacerBalle;

    }
    private void Update()
    {
        if  (mouvementBalle.getNbCoups() == 6)
        {
            balle.transform.position = new Vector3(-4.14f, 0.27f, -5.4f);
            mouvementCamera.transform.position = new Vector3(0.03f, 16.11f, -0.25f);
        }
    }

    /// <summary>
    /// methode pour replacer la balle après avoir heurter un trou
    /// </summary>
    /// <param name="sender">le sujet qui a été triggered</param>
    /// <param name="e"></param>
    public void replacerBalle(object sender, EventArgs e)
    {
       arreterBalle();
      
        //Replacer à la prochaine piste dépendamment du sujet
        if (sender == trou1) {
           
            balle.transform.position = new Vector3(-4.14f, 0.27f, -5.4f);
            mouvementCamera.transform.position = new Vector3(0.03f, 16.11f, -0.25f);
          
        }
        else if (sender == trou2)
        {
            balle.transform.position = new Vector3(18.2f, 0.27f, -6.08f);
            mouvementCamera.transform.position = new Vector3(18f, 14.68f, 0.69f);
        }

        if (mouvementBalle.getNbCoups() == 1)
        {
            StartCoroutine(AffichageMessage("TROU D'UN COUP !!!"));
        }

    }

    /// <summary>
    /// arreter la balle
    /// </summary>
    private void arreterBalle()
    {
        Rigidbody rb = balle.GetComponent<Rigidbody>();

        // Verification du component rigidbody
        if (rb != null)
        {
            // arreter le mouvemnt de la balle
            rb.velocity = Vector3.zero;

            // arretre la rotation de la balle
            rb.angularVelocity = Vector3.zero;

            rb.rotation = Quaternion.identity;
        }
    }

    IEnumerator AffichageMessage(string texte)
    {
        
        message.text = texte;
        // activer le message
        message.gameObject.SetActive(true);
        Debug.Log("Yaaaaaay");
        // afficher pour2 secondes
        yield return new WaitForSeconds(2);

        // desactiver message
        message.gameObject.SetActive(false);
    }

}
