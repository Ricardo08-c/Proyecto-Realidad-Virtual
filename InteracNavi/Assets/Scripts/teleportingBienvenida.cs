using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportingBienvenida : MonoBehaviour
{
    public GameObject _miPlayer;
    public AudioSource _audioSource;

    public void OnTeleportClick()
    {
        _miPlayer.transform.position = new Vector3(this.transform.position.x, transform.position.y + 2.4f, transform.position.z);
        _audioSource.Play();
    }
}
