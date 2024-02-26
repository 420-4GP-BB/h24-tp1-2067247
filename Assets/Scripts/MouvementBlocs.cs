using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementBlocs : MonoBehaviour
{
    [SerializeField] private GameObject bloc1;
    [SerializeField] private GameObject bloc2;
    [SerializeField] private float amplitude = 5f; // L'amplitude du mouvement (la distance maximale du mouvement de gauche à droite)
    [SerializeField] private float vitesse = 2f; // La vitesse du mouvement
    

    // Update is called once per frame
    void Update()
    {
        
            bougerBlocs();
        
    }
    private void bougerBlocs()
    {
        //j'ai utilisé chat gpt pour m'aider dans cette partie
        // Calculer une valeur entre -1 et 1 en utilisant la fonction sinus
        float sinValue = Mathf.Sin(Time.time * vitesse);
        float minZ = 14.23f;
        float maxZ = 19.5f;
        // Convertir la plage de sinValue de [-1, 1] à [0, 1] pour faciliter le mapping
        float normalizedSinValue = (sinValue + 1) / 2;
        // Mapper la valeur sinusoïdale normalisée à la plage cible
        float newPositionZ = Mathf.Lerp(minZ, maxZ, normalizedSinValue);

        // Mettre le bloc1 à la nouvelle position Z
        bloc1.transform.localPosition = new Vector3(bloc1.transform.localPosition.x, bloc1.transform.localPosition.y, newPositionZ);

        // Calculer la nouvelle position Z pour bloc2 en inversant le mapping pour qu'il se déplace dans la direction opposée
        float newPositionZBloc2 = Mathf.Lerp(minZ, maxZ, 1 - normalizedSinValue);

        // Mettre le bloc2 à la nouvelle position Z
        bloc2.transform.localPosition = new Vector3(bloc2.transform.localPosition.x, bloc2.transform.localPosition.y, newPositionZBloc2);
    }


}
