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
        textElement.color = new Color(textElement.color.r, textElement.color.g, textElement.color.b, 0);
        StartCoroutine(FadeTextToFullAlpha(dure, textElement));
        
    }

    public IEnumerator FadeTextToFullAlpha(float t, TextMeshProUGUI i)
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
        // Skip the animation if any key is pressed or the mouse is clicked
        if (Input.anyKeyDown || Input.GetMouseButtonDown(0))
        {
            StopAllCoroutines(); // Stop the fading coroutine
            textElement.color = new Color(textElement.color.r, textElement.color.g, textElement.color.b, 0);
            Camera.main.GetComponent<CameraJeu>().ActiverScriptCamera(true);                                                                                                 // Find the camera follow script and enable it

        }
        
    }
}
