using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class animationTitre : MonoBehaviour
{
   [SerializeField] private GameObject pointeur;
   [SerializeField] private TextMeshProUGUI textElement;
   [SerializeField] private float dure = 3.0f;
   private static bool animation =false;

    void Start()
    {
        
        pointeur.SetActive(false);
        //le texte est complètement transparent au début
        textElement.color = new Color(textElement.color.r, textElement.color.g, textElement.color.b, 0);
        //debut de l'animation
        StartCoroutine(AnimerTexte(dure, textElement));
        
    }
    /// <summary>
    /// Coroutine pour l'animation du texte
    /// </summary>
    /// <param name="t">dure</param>
    /// <param name="i">texte</param>
    public IEnumerator AnimerTexte(float t, TextMeshProUGUI i)
    {
        while (i.color.a < 1.0f)
        {
            //J'ai utilisé chat gpt pour m'aider avec cette partie
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }
        textElement.color = new Color(textElement.color.r, textElement.color.g, textElement.color.b, 0);
        animation = true;
    }

    void Update()
    {
       //arreter l'annimation si on appuie sur un bouton
        if (Input.anyKeyDown || Input.GetMouseButtonDown(0))
        {
            StopAllCoroutines(); 
            //le texte devient transparent directement
            textElement.color = new Color(textElement.color.r, textElement.color.g, textElement.color.b, 0);                                                                    
            animation = true;
        }
    }
    //boolean pour controller les cameras
    public static bool getAnimation()
    {
        return animation;
    }
}
