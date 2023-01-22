using UnityEngine;
using UnityEngine.SceneManagement;
public class CameraPointerAang : MonoBehaviour
{
    // Start is called before the first frame update
    private const float _maxDistance = 35;
    private GameObject _gazedAtObject = null;

    [SerializeField] private GameObject pointer;
    [SerializeField] AudioSource audioAang;
    [SerializeField] GameObject objectPiz;
    [SerializeField] ParticleSystem sis;
    private int aangObjects;
    private readonly string interactableTag = "Interactable";
    private readonly string teleportTag = "Teleporting";
    private readonly string grabTag = "Grab";
    private readonly string ungrabTag = "UnGrab";
    public GameObject _attachPoint;
    private bool reach = true;
    [SerializeField] AudioSource correct;
    [SerializeField] AudioSource sayan;


    private void Start()
    {


        int row = 20;
        int col = 10;
        GameObject duplicate = null;
        Vector3 position = new Vector3();
        GameObject original = objectPiz;
        GameObject originalRow = objectPiz;
        GazeManager.Instance.OnGazeSelection += GazeSelection;

        if (objectPiz == null)
        {
            return;
        }
        for (int k = 0; k < col; k++)
        {
            for (int i = 0; i < row; i++)
            {
                duplicate = Instantiate(original);

                duplicate.tag = "Board";
                position = original.transform.position;
                position -= original.transform.forward * (original.transform.lossyScale.z / 2 + duplicate.transform.lossyScale.z / 2);
                duplicate.transform.position = position;
                original = duplicate;




            }
            duplicate = Instantiate(original);
            position = originalRow.transform.position;
            position.y += originalRow.transform.lossyScale.y / 2;
            position.y += duplicate.transform.lossyScale.y / 2;
            duplicate.transform.position = position;
            original = duplicate;
            originalRow = duplicate;

        }



    }
    private void CountObj() {
        this.aangObjects++;
        if (this.aangObjects == 4) {
            sis.Play();
            sayan.Play();
        }

    }
    private bool comp(string s1, string s2)
    {
        int i = 0;
        foreach (char c in s1)
        {
            if (c != s2[i])
            {
                print(c + "-" + s2[i]);
                return false;
            }
            i++;
        }
        return true;
    }

    private void GazeSelection()
    {

        if (_gazedAtObject.name == "EscenaVR360")
            _gazedAtObject?.SendMessage("CargarVRROOM", null, SendMessageOptions.DontRequireReceiver);

        if (_gazedAtObject.name == "AcercaDe")
            _gazedAtObject?.SendMessage("CargarAcercaDe", null, SendMessageOptions.DontRequireReceiver);

        if (_gazedAtObject.name == "Elements")
            _gazedAtObject?.SendMessage("CargarAvatar", null, SendMessageOptions.DontRequireReceiver);

        if (_gazedAtObject.name == "Paint")
            _gazedAtObject?.SendMessage("CargarPaint", null, SendMessageOptions.DontRequireReceiver);

        if (_gazedAtObject.name == "Laberinto")
            _gazedAtObject?.SendMessage("CargarLaberinto", null, SendMessageOptions.DontRequireReceiver);

        if (_gazedAtObject.name == "Fin")
            _gazedAtObject?.SendMessage("SalirApp", null, SendMessageOptions.DontRequireReceiver);
        if (_gazedAtObject.name == "Regresar")
            SceneManager.LoadScene("NuevoMenu");
        if (_gazedAtObject != null && _gazedAtObject.CompareTag("Head"))
        {
            if (_attachPoint.transform.childCount == 0) return;
            Transform _detachObject = _attachPoint.transform.GetChild(0);


            Material mat = _detachObject.gameObject.GetComponent<Renderer>().material;
            Renderer renderer = _gazedAtObject.GetComponent<Renderer>();
            renderer.material = mat;
            GameObject[] steveParts = GameObject.FindGameObjectsWithTag("Head");
            this.reach = true;

            for (int i = 0; i < steveParts.Length; i++)
            {

                GameObject part = steveParts[i];
                if (part.name == "hand" || part.name == "leg")
                {

                    string name = part.GetComponent<Renderer>().material.name;
                    string s = part.name + "s";



                    if (!comp(name.Substring(0, 4), s))
                    {

                        this.reach = false;
                        break;


                    }
                }
                else
                {
                    string name = part.GetComponent<Renderer>().material.name;
                    string s = part.name;
                    if (!comp(name.Substring(0, 4), s))
                    {
                        this.reach = false;
                        break;

                    }
                }



            }
            print(this.reach);
            if (this.reach)
                correct.Play();

        }

        // Esta funcionan va a tomar un objeto con el Gaze y lo va a atachar a la mano indicada
        if (_gazedAtObject.CompareTag(grabTag))
            _gazedAtObject?.SendMessage("OnGrabRayInteractionAttach", null, SendMessageOptions.DontRequireReceiver);

        // Esta funcionan va a tomar un objeto y lo va a des-atachar sobre la mesa colisionada
        if (_gazedAtObject.CompareTag(ungrabTag))
        {
            CountObj();
            _gazedAtObject?.SendMessage("OnGrabRayInteractionDeAttach", null, SendMessageOptions.DontRequireReceiver);
        }

    }


    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    ///
    public void pointAtBoard(Transform pos)
    {

        Transform _detachObject = _attachPoint.transform.GetChild(0);
        print(_detachObject.gameObject.name);
        GameObject thrownObject = Instantiate(_detachObject.gameObject, _detachObject.transform.position, transform.rotation);


        // Set the triggerPressed variable to false



        GameObject myObject = thrownObject;
        Rigidbody rigid = thrownObject.GetComponent<Rigidbody>();



        Vector3 startPos = pos.forward * 10;


        float x = (startPos).x;
        float y = (startPos).y;
        float z = (startPos).z + 6;

        Vector3 endPos = new Vector3(x, y, z);


        // Declare the speed of the movement


        // Update the object's position using Ve;ctor3.Lerp
        rigid.transform.position = endPos;



    }
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

                _gazedAtObject = hit.transform.gameObject;

                if (_gazedAtObject.name == "Avatarrr")
                    audioAang.Play();
                if (hit.transform.CompareTag("Head"))
                    GazeManager.Instance.StartGazeSelection();
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
            audioAang.Stop();
            _gazedAtObject = null;
        }
        if (_gazedAtObject != null && _gazedAtObject.CompareTag("Board"))
        {
            if (_attachPoint.transform.childCount == 0) return;
            Transform _detachObject = _attachPoint.transform.GetChild(0);


            Material mat = _detachObject.gameObject.GetComponent<Renderer>().material;
            Renderer renderer = _gazedAtObject.GetComponent<Renderer>();
            renderer.material = mat;

        }


    }

}
