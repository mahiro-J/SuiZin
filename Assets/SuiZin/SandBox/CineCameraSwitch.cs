using System;
using UnityEngine;
using Unity.Cinemachine;
using UnityEngine.InputSystem;

public class CineCameraSwitch : MonoBehaviour
{
    [SerializeField] private CinemachineCamera thirdCam;
    [SerializeField] private CinemachineCamera firstCam;
    InputsRyeField _inputs;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _inputs = new InputsRyeField();
        _inputs.Camera.SwitchFS.started += OnSwitchCamera;
        
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

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        _inputs.Disable();
    }
}
