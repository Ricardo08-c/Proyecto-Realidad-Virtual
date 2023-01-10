using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class spawAnimals : MonoBehaviour
{
    // Start is called before the first frame update

    public int _numGatos;
    public int _numPajaros;
    public GameObject _miGato;
    public GameObject _miPajaro;
    bool _isGatoNuevo = false;
    bool _isPajaroNuevo = false;
    void Start()
    {
        _numGatos = 1;
        _numPajaros = 1;
        StartCoroutine(NuevoGato());
        StartCoroutine(NuevoPajaro());
    }

    // Update is called once per frame
    void Update()
    {
        if (_numGatos < 6 && !_isGatoNuevo)
            StartCoroutine(NuevoGato());
        if (_numPajaros < 6 && !_isPajaroNuevo)
            StartCoroutine(NuevoPajaro());

    }

    IEnumerator NuevoGato()
    {
        _isGatoNuevo=true;
        Instantiate(_miGato, new Vector3(RandomPosicion(-21, 20), 2.5f, RandomPosicion(-15, 15)),Quaternion.identity);
        _numGatos++;
        yield return new WaitForSeconds(10);
        _isGatoNuevo = false;
    }

    IEnumerator NuevoPajaro()
    {
        _isPajaroNuevo = true;
        Instantiate(_miPajaro, new Vector3(RandomPosicion(-21,20), 3, RandomPosicion(-15, 15)), Quaternion.identity);
        _numPajaros++;
        yield return new WaitForSeconds(5);
        _isPajaroNuevo = false;
    }

    float RandomPosicion(float min, float max)
    {
        float pos = Random.Range(min, max);
        return pos;
        
    }
}
