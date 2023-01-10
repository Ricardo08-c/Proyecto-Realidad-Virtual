using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetenerGameController : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject _miController;
    

    public void OnPointerClick()
    {
        _miController = GameObject.Find("GameController");

        Destroy(_miController);

    }
}
