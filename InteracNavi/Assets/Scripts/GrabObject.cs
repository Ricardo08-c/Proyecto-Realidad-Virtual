using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObject : MonoBehaviour
{
    public GameObject _objetoGrabed;
    public GameObject _jugador;
    [SerializeField] AudioSource sourceEarth;
    [SerializeField] AudioSource sourceAir;
    [SerializeField] AudioSource wrongAudio;
    [SerializeField] AudioSource correctAudio;
    Dictionary<string, Vector3> myDict = new Dictionary<string, Vector3>();
    
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        



        if (other.gameObject.tag == "GrabNotGaze")
        {
            if (other.gameObject.name == "air") {
                sourceAir.Play();
            }
            if (other.gameObject.name == "earth")
            {
                sourceEarth.Play();

            }
            if (this._jugador.transform.childCount > 0)

            {
                _objetoGrabed.transform.SetParent(null);
                _objetoGrabed.gameObject.GetComponent<Rigidbody>().useGravity = false;
                _objetoGrabed.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                _objetoGrabed.gameObject.transform.localScale = other.transform.localScale;
                _objetoGrabed.gameObject.transform.position = myDict[_objetoGrabed.name];
                
                _objetoGrabed.gameObject.transform.rotation = other.transform.rotation;
                _objetoGrabed = null;
            }
            if(!myDict.ContainsKey(other.gameObject.name))
                myDict.Add(other.gameObject.name, other.gameObject.transform.position);
            

            other.gameObject.GetComponent<Rigidbody>().useGravity = false;
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            other.gameObject.transform.SetParent(_jugador.transform,false);
            other.gameObject.transform.localPosition = new Vector3(0f, 1f, 0f);
            _objetoGrabed = other.gameObject;
        }

    
        if (other.gameObject.tag == "UngrabNotGaze" && _objetoGrabed != null)
        {
            if (other.name != _objetoGrabed.name) {
                wrongAudio.Play();
                return;
            }
            GameObject cam = GameObject.FindGameObjectWithTag("MainCamera");
            cam?.SendMessage("CountObj", null, SendMessageOptions.DontRequireReceiver);

            _objetoGrabed.transform.SetParent(null);
            _objetoGrabed.gameObject.GetComponent<Rigidbody>().useGravity = true;
            _objetoGrabed.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            _objetoGrabed.gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            _objetoGrabed.gameObject.transform.position = new Vector3(other.transform.position.x, 1.0f, other.transform.position.z);
            _objetoGrabed.gameObject.transform.rotation = Quaternion.identity;
            _objetoGrabed = null;
            correctAudio.Play();
        }
    }
}
