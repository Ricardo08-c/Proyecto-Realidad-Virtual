using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CerrarPuerta : MonoBehaviour
{
    public Animator _aniControPuerta;

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(Pausa());
        _aniControPuerta.SetTrigger("Cerrar");
    }


    IEnumerator Pausa()
    {
        yield return new WaitForSeconds(4);
    }
}
