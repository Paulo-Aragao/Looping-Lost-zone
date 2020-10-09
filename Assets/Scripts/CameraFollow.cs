using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform _original;
    // Start is called before the first frame update
    void Start()
    {
        _original = transform;
    }
     void Update () {
        transform.position = _original.position;
        transform.rotation = transform.rotation;
    }
}
