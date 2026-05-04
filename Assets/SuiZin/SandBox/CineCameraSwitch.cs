using System;
    using UnityEngine;
    using Unity.Cinemachine;
    using UnityEngine.InputSystem;
    
    public class CineCameraSwitch : MonoBehaviour
    {
        [SerializeField] private CinemachineCamera thirdCam;
        [SerializeField] private CinemachineCamera firstCam;
        InputsRyeField _inputs;
        
        void Awake()
        {
            _inputs = new InputsRyeField();
            // 正しいアクション名に変更してください
            _inputs.Camera.SwitchFS.started += OnSwitchCamera;
            // _inputs.Camera.SwitchCamera.started += OnSwitchCamera;  // または実際の名前に置き換え
            
            _inputs.Enable();
        }
    
        private void Start()
        {
            thirdCam.Priority = 1;
            firstCam.Priority = 0;
        }
    
        void OnSwitchCamera(InputAction.CallbackContext context)
        {
            if (thirdCam.Priority > firstCam.Priority)
            {
                thirdCam.Priority = 0;
                firstCam.Priority = 1;
            }
            else
            {
                thirdCam.Priority = 1;
                firstCam.Priority = 0;
            }
        }
    
        void Update()
        {
            
        }
    
        private void OnDestroy()
        {
            _inputs.Dispose();
        }
    }