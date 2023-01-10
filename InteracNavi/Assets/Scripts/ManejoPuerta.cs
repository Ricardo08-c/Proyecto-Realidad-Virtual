using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManejoPuerta : MonoBehaviour
{
    public Animator _aniControPuerta;


    private void OnTriggerEnter(Collider other)
    {
        _aniControPuerta.SetTrigger("Abrir");
    }

}
