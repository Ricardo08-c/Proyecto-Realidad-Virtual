using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ComportamientoPedestal : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource _audio;


    private void Start()
    {
        _audio = this.GetComponent<AudioSource>();
    }


    public void OnPointerClick()
    {
        if (this.gameObject.name == "Pedestal")
            StartCoroutine(CargarEscena(2));
    }

    IEnumerator CargarEscena(int numescena)
    {
        _audio.Play();
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(numescena);
    }

}
