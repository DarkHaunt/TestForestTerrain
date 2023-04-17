using UnityEngine;


namespace Forest.Character
{
    [RequireComponent(typeof(CharacterController))]
    public class CharacterControllerCustom : MonoBehaviour
    {
        [SerializeField] private CameraRotator _cameraRotator;

        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _mouseSensetivity = 100f;

        private CharacterController _characterController;
        
        private Vector3 MoveDirection => new Vector3(Input.GetAxis("Vertical"), 0f , -Input.GetAxis("Horizontal")).normalized;


        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            var mouseX = Input.GetAxis("Mouse X") * _mouseSensetivity * Time.deltaTime;
            var mouseY = Input.GetAxis("Mouse Y") * _mouseSensetivity * Time.deltaTime;

            RotateCharacterByY(mouseX);
            RotateCamera(mouseY);
            MoveCharacter();

            CheckForCameraRotationReset();
        }

        private void RotateCharacterByY(float angle)
        {
            transform.Rotate(Vector3.up * angle);
        }

        private void RotateCamera(float angle)
        {
            _cameraRotator.RotateCamera(angle);
        }

        private void CheckForCameraRotationReset()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                _cameraRotator.ResetRotation();
        }

        private void MoveCharacter()
        {
            _characterController.SimpleMove(MoveDirection * Time.deltaTime * _moveSpeed);
        }
    } 
}
