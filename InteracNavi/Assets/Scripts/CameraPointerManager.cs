using UnityEngine;
using UnityEngine.SceneManagement;
public class CameraPointerManager : MonoBehaviour
{
    // Start is called before the first frame update
    private const float _maxDistance = 35;
    private GameObject _gazedAtObject = null;

    [SerializeField] private GameObject pointer;
    [SerializeField] AudioSource audioAang;

    private readonly string interactableTag = "Interactable";
    private readonly string teleportTag = "Teleporting";
    private readonly string grabTag = "Grab";
    private readonly string ungrabTag = "UnGrab";




    private void Start()
    {
        GazeManager.Instance.OnGazeSelection += GazeSelection;
    }

    private void GazeSelection()
    {

        if (_gazedAtObject.name == "EscenaVR360")
            _gazedAtObject?.SendMessage("CargarVRROOM", null, SendMessageOptions.DontRequireReceiver);
              
        if (_gazedAtObject.name == "AcercaDe")
            _gazedAtObject?.SendMessage("CargarAcercaDe", null, SendMessageOptions.DontRequireReceiver);
        if (_gazedAtObject.name == "Fin")
            _gazedAtObject?.SendMessage("SalirApp", null, SendMessageOptions.DontRequireReceiver);
        if (_gazedAtObject.name == "Regresar")
            SceneManager.LoadScene("NuevoMenu");

        if (_gazedAtObject.CompareTag(interactableTag))
            _gazedAtObject?.SendMessage("OnPointerClick", null, SendMessageOptions.DontRequireReceiver);
        if (_gazedAtObject.CompareTag(teleportTag))
            _gazedAtObject?.SendMessage("OnTeleportClick", null, SendMessageOptions.DontRequireReceiver);

        // Esta funcionan va a tomar un objeto con el Gaze y lo va a atachar a la mano indicada
        if (_gazedAtObject.CompareTag(grabTag))
            _gazedAtObject?.SendMessage("OnGrabRayInteractionAttach", null, SendMessageOptions.DontRequireReceiver);

        // Esta funcionan va a tomar un objeto y lo va a des-atachar sobre la mesa colisionada
        if (_gazedAtObject.CompareTag(ungrabTag))
        {
            
            _gazedAtObject?.SendMessage("OnGrabRayInteractionDeAttach", null, SendMessageOptions.DontRequireReceiver);
        }
    }


    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    public void Update()
    {
        // Casts ray towards camera's forward direction, to detect if a GameObject is being gazed
        // at.
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, _maxDistance))
        {
            // GameObject detected in front of the camera.
            if (_gazedAtObject != hit.transform.gameObject)
            {
                _gazedAtObject?.SendMessage("OnPointerExit", null, SendMessageOptions.DontRequireReceiver);
                _gazedAtObject = hit.transform.gameObject;
                _gazedAtObject.SendMessage("OnPointerEnter", null, SendMessageOptions.DontRequireReceiver);
                if (_gazedAtObject.name == "Avatarrr")
                    audioAang.Play();
                if (hit.transform.CompareTag(interactableTag))
                    GazeManager.Instance.StartGazeSelection();
                if (hit.transform.CompareTag(teleportTag))
                    GazeManager.Instance.StartGazeSelection();
                if (hit.transform.CompareTag(grabTag))
                    GazeManager.Instance.StartGazeSelection();
                if (hit.transform.CompareTag(ungrabTag))
                    GazeManager.Instance.StartGazeSelection();
            }
        }
        else
        {
            GazeManager.Instance.CancelGazeSelection();
            _gazedAtObject?.SendMessage("OnPointerExit", null, SendMessageOptions.DontRequireReceiver);
            audioAang.Stop();
            _gazedAtObject = null;
        }


    }
}
