using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnimationFin : MonoBehaviour
{
    [SerializeField] private TMP_Text texteScore; // Référence au composant texte qui affiche le score
    [SerializeField] private GestionnaireJeu gestionnaireJeu;
    private int[] tableauScore;
    
    // Start is called before the first frame update
    void Start()
    {
         texteScore.gameObject.SetActive(false);
        tableauScore = gestionnaireJeu.getTabScore();
       
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
        int sommeScores = 0;
        for (int i = 0; i < tabScore.Length; i++)
        {
            sommeScores += tabScore[i];
         
        }
        texteScore.gameObject.SetActive(true);
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
        //afichage du messaage de fin
        if (sommeScores > 9)
        {
            texteScore.text += "\nPas terrible";
        }
        else if (sommeScores > 6)
        {
            texteScore.text += "\nPas mal";
        }
        else if (sommeScores > 3)
        {
            texteScore.text += "\nTrès Bien";
        }
        else 
        {
            texteScore.text += "\nExcellent";
        }
        yield return new WaitForSeconds(2f); // Attendre 2 secondes avant de cacher le score
        texteScore.gameObject.SetActive(false);
    }
}
