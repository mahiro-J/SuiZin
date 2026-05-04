using UnityEngine;
using Unity.Cinemachine;
using UnityEngine.InputSystem;

namespace SuiZin.InGame.Camera
{
    public class ChangeCam : MonoBehaviour
    {
        [SerializeField] private CinemachineCamera thirdPersonCam;
        [SerializeField] private CinemachineCamera firstPersonCam;

        private PlayerInput _inputs;
        private bool _isFirstPerson = false;

        private void Awake()
        {
            _inputs = new PlayerInput();
            _inputs.Camera.ChangeCam.started += OnCameraSwitch;
            _inputs.Enable();
        }

        private void OnCameraSwitch(InputAction.CallbackContext context)
        {
            _isFirstPerson = !_isFirstPerson;

            if (_isFirstPerson)
            {
                thirdPersonCam.Priority = 0;
                firstPersonCam.Priority = 1;
            }
            else
            {
                thirdPersonCam.Priority = 1;
                firstPersonCam.Priority = 0;
            }
        }

        private void OnDestroy()
        {
            _inputs.Camera.ChangeCam.started -= OnCameraSwitch;
            _inputs.Dispose();
        }
    }
}