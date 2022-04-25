using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public bool isInitialized = true;

    [Space]
    public Camera _camera;

    [Space]
    public Transform target;
    public Vector3 offset;

    

    private void Start()
    {
        _camera = Camera.main;
    }


    public void Update()
    {
        if(isInitialized)
        {
            transform.LookAt(transform.position + _camera.transform.rotation * Vector3.forward, _camera.transform.rotation * Vector3.up);
            transform.position = new Vector3(target.position.x + offset.x, target.position.y + offset.y, target.position.z + offset.z);
        }
    }
}
