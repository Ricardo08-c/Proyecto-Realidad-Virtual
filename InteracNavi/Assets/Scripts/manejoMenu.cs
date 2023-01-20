using UnityEngine;
using UnityEngine.SceneManagement;

public class manejoMenu : MonoBehaviour
{
    //[SerializeField] AudioSource audioAmbiente;
    private Renderer _myRenderer;
    private Vector3 _startingPosition;

    public void Start()
    {
        _startingPosition = transform.parent.localPosition;
        _myRenderer = GetComponent<Renderer>();
    }

    public void CargarVRROOM()
    {
        SceneManager.LoadScene("MoverObjetos");
    }

    public void CargarPaint()
    {
        SceneManager.LoadScene("Paint"); 
    }

    public void CargarLaberinto()
    {
        SceneManager.LoadScene("Laberinto"); 
    }

    public void CargarAvatar()
    {
        SceneManager.LoadScene("MoverObjetosAang"); 
    }

    public void CargarAcercaDe()
    {
        SceneManager.LoadScene("AcercaDe"); // Carga escena de acerca de
    }




    public void RegresarMenu()
    {
        SceneManager.LoadScene("NuevoMenu");
    }

    public void SalirApp()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
    /*
    public void EncenderAudio()
    {
        if (audioAmbiente.isPlaying)
            audioAmbiente.Stop();
        else
            audioAmbiente.Play();
    }*/
}
