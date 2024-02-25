using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementBlocs : MonoBehaviour
{
    [SerializeField]private GameObject bloc1;
    [SerializeField] private GameObject bloc2;
    public float amplitude = 5f; // L'amplitude du mouvement (la distance maximale du mouvement de gauche à droite)
    public float vitesse = 2f; // La vitesse du mouvement
    // Start is called before the first frame update
    void Start()
    {
       // bloc1 = GameObject.FindGameObjectWithTag("MiniBloc1");
             bloc2 = GameObject.FindGameObjectWithTag("MiniBloc2");
    }

    // Update is called once per frame
    void Update()
    {
        while (true)
        {
            bougerBlocs();
        }
    }
    private void bougerBlocs()
    {
        float newPositionX = Mathf.Sin(Time.time * vitesse) * amplitude;

        // Mettre à jour la position de bloc1 en conservant les valeurs y et z actuelles
        bloc1.transform.position = new Vector3(newPositionX, bloc1.transform.position.y, bloc1.transform.position.z);
    }


}
