using System.Collections.Generic;
using System;
using UnityEngine;


namespace Forest.Character
{
    [RequireComponent(typeof(Camera))]
    public class CharacterCameraController : MonoBehaviour
    {
        [SerializeField] private float _rotationSpeed;

        private Camera _camera;
        private Quaternion _startRotation;


        private void Awake()
        {
            _camera = Camera.main;
            _startRotation = _camera.transform.rotation;
        }

        private void Update()
        {
            if(Input.GetMouseButton(0))
                TryToRotateCamera();

            if (Input.GetKeyDown(KeyCode.Space))
                ResetRotation();
        }

        private void TryToRotateCamera()
        {
            if (Input.GetAxis("Mouse X") == 0 || Input.GetAxis("Mouse Y") == 0)
                return;

            var verticalInput = Input.GetAxis("Mouse Y") * _rotationSpeed * Time.deltaTime;
            var horizontalInput = Input.GetAxis("Mouse X") * _rotationSpeed * Time.deltaTime;

            var rotation = new Vector3(verticalInput, horizontalInput, 0f);

            _camera.transform.Rotate(rotation);
        }

        private void ResetRotation()
        {
            _camera.transform.rotation = _startRotation;
        }
    }
}
