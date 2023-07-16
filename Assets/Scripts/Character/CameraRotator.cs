using System.Collections.Generic;
using System;
using UnityEngine;


namespace Forest.Character
{
    [RequireComponent(typeof(Camera))]
    public class CameraRotator : MonoBehaviour
    {
        private const float MaxRotationAngle = 88f;
        private const float MinRotationAngle = -88f;

        private Camera _camera;
        private Quaternion _startRotation;

        private float _xRotation = 0f;


        private void Awake()
        {
            _camera = Camera.main;
            _startRotation = _camera.transform.rotation;
        }


        public void RotateCamera(float angle)
        {
            _xRotation += angle;
            _xRotation = Mathf.Clamp(_xRotation, MinRotationAngle, MaxRotationAngle);

            var rawRotationValue = Quaternion.Euler(_xRotation, 0f, 0f);

            _camera.transform.localRotation = Quaternion.Inverse(rawRotationValue);
        }

        public void ResetRotation()
        {
            _camera.transform.rotation = _startRotation;
        }
    }
}
