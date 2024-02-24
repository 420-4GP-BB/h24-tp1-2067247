using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trou2_sujet : MonoBehaviour
{
    public event Action<object, EventArgs> ZoneAtteinteHandler;

    [SerializeField] private GameObject balleActive; // variable pour la balle active
                                                     // Start is called before the first frame update


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == balleActive)
        {
            ZoneAtteinteHandler?.Invoke(this, EventArgs.Empty);
        }
    }


}
