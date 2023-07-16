using System.Collections.Generic;
using System;
using UnityEngine;


public class TestMoving : MonoBehaviour
{
    [SerializeField] private Transform _end;
    [SerializeField] private float _interpolation = 0f;

    private Vector3 _start;
    private Vector3 _velocity;
    

    private void Awake()
    {
        _start = transform.position;
    }

    private void Update()
    {
        // transform.position = Vector3.Lerp(_start, _end.position, _interpolation);
        var a = Vector3.SmoothDamp(transform.position, _end.position, ref _velocity, _interpolation);
        transform.Translate(_velocity * Time.deltaTime);
    }
}
