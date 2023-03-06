using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {


    private Transform _player;
    public Transform Player
    {
        get { return _player; }
        set
        {
            offset = transform.position - value.position;
            _player = value;
        }
    }


    private Vector3 offset;

    void LateUpdate ()
    {
        transform.position = Player.position + offset;
    }
}
