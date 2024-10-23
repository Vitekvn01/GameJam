using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _rotationSensetive;
    [SerializeField] private GameObject _playerCam;

    private float _normalizeRotX;
    private float _normalizeRotY;

    private float _normalizeDirZ;
    private float _normalizeDirX;
    
    private bool _isSpeedUp;

    private MovementLogic _movementLogic;
    private FPSCamLogic _camLogic;

    private void Start()
    {
        _movementLogic = new MovementLogic(this.gameObject);
        _camLogic = new FPSCamLogic(_playerCam);
    }

    private void Update()
    {
        CheckInput();

        Movement();

        Rotation();
    }

    private void CheckInput()
    {
        _normalizeRotX = Input.GetAxis("Mouse Y");
        _normalizeRotY = Input.GetAxis("Mouse X");

        _normalizeDirZ = Input.GetAxisRaw("Vertical");
        _normalizeDirX = Input.GetAxisRaw("Horizontal");

        _isSpeedUp = Input.GetAxisRaw("Run") > 0;
    }

    private void Movement()
    {
        _movementLogic.Movement(_normalizeDirZ, _normalizeDirX, _speed, _isSpeedUp);
    }

    private void Rotation()
    {
        _movementLogic.RotationBody(_normalizeRotY, _rotationSensetive, _rotationSpeed);
        _camLogic.RotationCamera(_normalizeRotX, _rotationSensetive, _rotationSpeed);
    }
}
