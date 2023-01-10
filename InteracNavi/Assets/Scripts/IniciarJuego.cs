using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IniciarJuego : MonoBehaviour
{
    public GameObject _GameController;
public void OnPointerClick()
    {

        Instantiate(_GameController);
    }
}
