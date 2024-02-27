using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnimationFin : MonoBehaviour
{
    [SerializeField] private TMP_Text texteScore; // Référence au composant texte qui affiche le score
    private GestionnaireJeu gestionnaireJeu;
    private int[] tableauScore;
    
    // Start is called before the first frame update
    void Start()
    {
         texteScore.gameObject.SetActive(false);

       
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }

   

    // Méthode pour démarrer l'animation du score final
    public void AfficherScoreFinal()
    {
        texteScore.gameObject.SetActive(true);
        StartCoroutine(AnimationScoreFinal(tableauScore));
        Debug.Log("afficher fonctionne");
    }

    IEnumerator AnimationScoreFinal(int[] tabScore)
    {
        Debug.Log("la coroutine roule ");
        // Afficher le titre « Score final »
        texteScore.text = "SCORE FINAL";
        yield return new WaitForSeconds(1f); // Attendre 1 seconde

        // Afficher le score de la piste 1
        texteScore.text += $"\n {tabScore[0]}";
        yield return new WaitForSeconds(1f); // Attendre 1 seconde

        // Afficher le score de la piste 2
        texteScore.text += $"  {tabScore[1]}";
        yield return new WaitForSeconds(1f); // Attendre 1 seconde

        // Afficher le score de la piste 3
        texteScore.text += $"  {tabScore[2]}";
        yield return new WaitForSeconds(1f); // Attendre 1 seconde
        texteScore.text += $"\n Pas Mal";
        yield return new WaitForSeconds(2f); // Attendre 1 seconde
        texteScore.gameObject.SetActive(false) ;
    }
}
