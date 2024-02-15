using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptPointeur : MonoBehaviour
{
    [SerializeField] private Rigidbody balle; 
   // private Rigidbody _rbody;    // Le Rigidbody de la balle pointeur
    private float _horizontal;   // La valeur de la force à appliquer en horizontal
    Vector3 deplacement;
    private float distanceDeBalle = 3.0f;

    void Start()
    {

        deplacement = (transform.position - balle.position).normalized * distanceDeBalle ;
        SetVisibility(false); // Initially make the pointer invisible
    }

    void Update()
    {
        _horizontal= Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(_horizontal, 0.0f, 0.0f);

       deplacement += movement * 1 * Time.deltaTime;
       deplacement = deplacement.normalized * distanceDeBalle;

        // Update position based on "rb" position and offset
        transform.position = balle.position + deplacement;
    }

    public void SetVisibility(bool isVisible)
    {
        // Enable or disable the Renderer component to show/hide the pointer
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.enabled = isVisible;
        }
    }
}
