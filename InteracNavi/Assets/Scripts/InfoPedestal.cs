using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfoPedestal : MonoBehaviour
{
    // Start is called before the first frame update

    private TMPro.TextMeshProUGUI texto;
    void Start()
    {
        texto = GetComponent<TMPro.TextMeshProUGUI>();
    }

    
    public void OnPointerClick()
    {
        
        StartCoroutine(CargarTexto());
    }

    public void OnPointerExit()
    {
        texto.text = "Más";
    }

    
    IEnumerator CargarTexto()
    {
       
        if (this.gameObject.name == "CanvasT1")
            texto.text = "Escene con mini juego para aprender a usar el Gaze y las coroutinas";
        if (this.gameObject.name == "CanvasP2")
            texto.text = "Escena con navegacion mediante teleporting utilizando marcadores y desplazandose";
        if (this.gameObject.name == "CanvasP3")
            texto.text = "Escena con navegacion mediante mirar y moverse. Desplazamiento continuo en la escena";
        yield return null;
    }
}
