using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using Random = UnityEngine.Random;

public class GestionnaireJeu : MonoBehaviour
{
    [SerializeField] private GameObject balle; // La balle
    [SerializeField] private TMP_Text message; // Le champs de points qu'on doit mettre à jour
    [SerializeField] private trou1_sujet trou1; // la zone d'arrivée qu'on observe
    [SerializeField] private trou2_sujet trou2; // la zone d'arrivée qu'on observe
    [SerializeField] private trou3_sujet trou3; // la zone d'arrivée qu'on observe
    [SerializeField] private Camera mouvementCamera;
    [SerializeField] private TMP_Text pisteCoup;
    private AnimationFin animationFin;
    private int piste;
    private int[] tabNbCoup = { 0, 0, 0 };
    private MouvementBalle mouvementBalle;
    private Rigidbody rb;
    private bool fin = false;
    // Start is called before the first frame update
    void Start()
    {
        piste = 1;
        rb = balle.GetComponent<Rigidbody>();
        message.gameObject.SetActive(false);
        pisteCoup.gameObject.SetActive(false);
        mouvementBalle = balle.GetComponent<MouvementBalle>();
        trou1.ZoneAtteinteHandler += replacerBalle;
        trou2.ZoneAtteinteHandler += replacerBalle;
        trou3.ZoneAtteinteHandler += replacerBalle;

    }
    private void Update()
    {
        tabNbCoup[piste - 1] = mouvementBalle.getNbCoups();
        pisteCoup.text = $"Piste : {piste} Coup : {tabNbCoup[piste - 1]}";
        if (mouvementBalle.getNbCoups() == 6)
        {
            deplacerApresSix();
        }
        if (Input.GetKey(KeyCode.Alpha1) || Input.GetKey(KeyCode.Keypad1))
        {
            deplacerDebutPiste1();

        }
        if (Input.GetKey(KeyCode.Alpha2) || Input.GetKey(KeyCode.Keypad2))
            {
            deplacerDebutPiste2();
        }
        if (Input.GetKey(KeyCode.Alpha3) || Input.GetKey(KeyCode.Keypad3))
        {
            deplacerDebutPiste3();
        }
        if (balle.transform.position.y < -1)
        {
            StartCoroutine(AffichageMessage("BALLE HORS TERRAIN! PÉNALITÉ DE +1"));
        }
        if (Input.GetKey(KeyCode.Alpha0) || Input.GetKey(KeyCode.Keypad0))
        {
            deplacerPresTrou();
        }

    }

    private void deplacerPresTrou()
    {
        // Angle aléatoire entre 0 et 2 * PI
        float angle = Random.Range(0f, 2f * Mathf.PI);
        Vector3 positionTrou = Vector3.zero;
        float rayon = 0;
        Vector3 nouvellePosition= Vector3.zero;
        if (piste == 1)
        {
            positionTrou = trou1.transform.position;
             rayon = trou1.transform.localScale.x;
        }
        else if (piste == 2)
        {
            positionTrou = trou2.transform.position;
            rayon = trou2.transform.localScale.x;
        }
        else if (piste == 3)
        {
            positionTrou = trou3.transform.position;
            rayon = trou3.transform.localScale.x;
        }
        
        float distanceX = Mathf.Cos(angle) * 2 * rayon; // 2 fois le rayon du trou
        float distanceZ = Mathf.Sin(angle) * 2 * rayon; // 2 fois le rayon du trou
        if(piste ==1 || piste == 2)
        {
           nouvellePosition = new Vector3(positionTrou.x + distanceX, 0.2f, positionTrou.z + distanceZ);
        }
        else
        {
             nouvellePosition = new Vector3(positionTrou.x + distanceX, 2.13f, positionTrou.z + distanceZ);
        }
        
        balle.transform.position = nouvellePosition;
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
        if (sender == trou1)
        {

            deplacerDebutPiste2();


        }
        else if (sender == trou2)
        {
            deplacerDebutPiste3();

        }
        else if (sender == trou3)
        {
            fin = true;
            
            animationFin.AfficherScoreFinal();

            deplacerDebutPiste1();
        }
        if (piste == 1)
        {

        } else if (tabNbCoup[piste-2] == 1)
        {
            StartCoroutine(AffichageMessage("TROU D'UN COUP !!!"));
        }
        
        mouvementBalle.reinitiliserCoups();
      

    }
    /// <summary>
    /// methode qui deplace la balle sur le trou si le joueur fait 6 coups sans la rentrer + incremenation du nombre de coups
    /// </summary>
    private void deplacerApresSix()
    {
        if (piste == 1)
        {
            rb.transform.position = new Vector3(-22.5f, 0.27f, 4.77f);

        }
        if (piste == 2)
        {
            rb.transform.position = new Vector3(4.22f, 0.27f, -4.4f);

        }
        StartCoroutine(AffichageMessage("Trop de coups! On passe à la prochaine piste..."));
        tabNbCoup[piste - 1] += 1;
    }
    
    /// <summary>
    /// arreter la balle
    /// </summary>
    private void arreterBalle()
    {


        // arreter le mouvemnt de la balle
        rb.velocity = Vector3.zero;

        // arretre la rotation de la balle
        rb.angularVelocity = Vector3.zero;

        rb.rotation = Quaternion.identity;

    }

    private IEnumerator AffichageMessage(string texte)
    {

        message.text = texte;
        // activer le message
        message.gameObject.SetActive(true);
        // afficher pour2 secondes
        yield return new WaitForSeconds(2);

        // desactiver message
        message.gameObject.SetActive(false);
    }
    private void deplacerDebutPiste1()
    {
        arreterBalle();
        balle.transform.position = new Vector3(-20.03f, 0.26f, -6.08f);
        mouvementCamera.transform.position = new Vector3(-19.44f, 14.35f, -0.26f);
        piste = 1;
        mouvementBalle.reinitiliserCoups();
        
    }
    private void deplacerDebutPiste2()
    {
        arreterBalle();
        balle.transform.position = new Vector3(-4.14f, 0.26f, -5.4f);
        mouvementCamera.transform.position = new Vector3(0.03f, 16.11f, -0.25f);
        piste = 2;
        mouvementBalle.reinitiliserCoups();
    }
    private void deplacerDebutPiste3()
    {
        arreterBalle();
        balle.transform.position = new Vector3(18.2f, 0.27f, -6.08f);
        mouvementCamera.transform.position = new Vector3(18f, 14.68f, 0.69f);
        piste = 3;
        mouvementBalle.reinitiliserCoups();
    }
    public int[] getTabScore()
    {
        return tabNbCoup;
    }
    public bool getFin()
    {
        return fin ;
    }
}



