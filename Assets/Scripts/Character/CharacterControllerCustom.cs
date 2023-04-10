using UnityEngine;


namespace Forest.Character
{
    [RequireComponent(typeof(CharacterController))]
    public class CharacterControllerCustom : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private CharacterController _characterController;
        
        private Vector3 MoveDireaction => new Vector3(Input.GetAxis("Vertical"), 0f , -Input.GetAxis("Horizontal")).normalized;


        private void Update()
        {
            _characterController.SimpleMove(MoveDireaction * Time.deltaTime * _speed);
        }

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }
    } 
}
