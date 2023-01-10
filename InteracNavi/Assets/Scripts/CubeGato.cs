using System.Collections;
using UnityEngine;

public class CubeGato : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource _audio;



    public void OnPointerClick()
    {
       if (!_audio.isPlaying)
            _audio.Play();
       else
            _audio.Stop();
        
       if (this.name == "Cube Gato(Clone)")
        {
            int _gatosActuales = GameObject.Find("GameController(Clone)").GetComponent<spawAnimals>()._numGatos;
            _gatosActuales--;
            GameObject.Find("GameController(Clone)").GetComponent<spawAnimals>()._numGatos = _gatosActuales;
        }
       if (this.name == "Cube Pajaro(Clone)")
        {
            int _pajarosActuales = GameObject.Find("GameController(Clone)").GetComponent<spawAnimals>()._numPajaros;
            _pajarosActuales--;
            GameObject.Find("GameController(Clone)").GetComponent<spawAnimals>()._numPajaros = _pajarosActuales;
        }
       StartCoroutine(AutoDestruir(5));
    }


    IEnumerator AutoDestruir(int numsegundos)
    {
        yield return new WaitForSeconds(numsegundos);
        Destroy(this.gameObject);
    }

}
