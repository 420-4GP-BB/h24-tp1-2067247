using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class animationTitre : MonoBehaviour
{

    public TextMeshProUGUI textElement; 
    public float dure = 3.0f;

    void Start()
    {
        //le texte est complètement transparent au début
        textElement.color = new Color(textElement.color.r, textElement.color.g, textElement.color.b, 0);
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
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }
        textElement.color = new Color(textElement.color.r, textElement.color.g, textElement.color.b, 0);
        Camera.main.GetComponent<CameraJeu>().ActiverScriptCamera(true);
    }

    void Update()
    {
       //arreter l'annimation si on appuie sur un bouton
        if (Input.anyKeyDown || Input.GetMouseButtonDown(0))
        {
            StopAllCoroutines(); 
            //le texte devient transparent directement
            textElement.color = new Color(textElement.color.r, textElement.color.g, textElement.color.b, 0);
            Camera.main.GetComponent<CameraJeu>().ActiverScriptCamera(true);                                                                                                 // Find the camera follow script and enable it

        }
        
    }
}
