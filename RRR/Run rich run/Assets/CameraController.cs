using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform _target;

    private Vector3 _position;

    private void Start()
    {
        _position = _target.InverseTransformPoint(transform.position);
    }
    private void Update()
    {
        var currentPosition = _target.TransformPoint(_position);
        transform.position = currentPosition;
        transform.LookAt(_target);
    }

}
