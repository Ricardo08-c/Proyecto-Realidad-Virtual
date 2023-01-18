using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manejoAudio : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] AudioSource audioFuente;

    /*
    public float speed = 2;
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(x, 0, z);
        transform.Translate(movement * speed * Time.deltaTime);
    }**/

    public void OnPointerEnter()
    {
        audioFuente.Play();
    }

    public void OnPointerExit()
    {
        audioFuente.Stop();
    }

    public void OnPointerClick()
    {
        //
    }
}
