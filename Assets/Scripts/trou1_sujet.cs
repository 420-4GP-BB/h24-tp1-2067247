using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trou1_sujet : MonoBehaviour
{
   
    public event Action<object, EventArgs> ZoneAtteinteHandler;
    [SerializeField] private GameObject balleActive; 

   

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == balleActive)
        {
            ZoneAtteinteHandler?.Invoke(this, EventArgs.Empty);
        }
    }

}
