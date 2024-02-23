using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trou1_sujet : MonoBehaviour
{
    public event Action ZoneAtteinteHandler;
    [SerializeField] private GameObject balleActive; // variable pour la balle active
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == balleActive)
        {
            // Si la zone n'est pas observée, il ne faut pas déclencher l'événement
            if (ZoneAtteinteHandler != null)
            {
                ZoneAtteinteHandler();
            }
        }
    }

}
