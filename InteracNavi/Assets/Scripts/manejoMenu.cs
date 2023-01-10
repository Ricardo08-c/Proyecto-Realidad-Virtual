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
        SceneManager.LoadScene(1);
    }
    /*
    public void CargarPatio()
    {
        SceneManager.LoadScene(3);
    }*/
    public void CargarAcercaDe()
    {
        SceneManager.LoadScene(2); // Carga escena de acerca de
    }

    public void RegresarMenu()
    {
        SceneManager.LoadScene(0);
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
