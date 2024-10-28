using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : SingletonBase<PlayerController>
{
    [SerializeField] private GameObject _pauseControllerPrefab;
    private PauseController _pauseController;

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
    public FPSCamLogic CamLogic { get; private set; }

    private void Start()
    {
        InitPauseController();
        _movementLogic = new MovementLogic(this.gameObject);
        CamLogic = new FPSCamLogic(_playerCam);
        CamLogic.CursorLocked();
    }

    private void Update()
    {
        CheckInput();

        Rotation();

        if (Input.GetKeyDown(KeyCode.Q))
        {
            CompassActivated();
        }
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void CheckInput()
    {
        _normalizeRotX = Input.GetAxis("Mouse Y");
        _normalizeRotY = Input.GetAxis("Mouse X");

        _normalizeDirZ = Input.GetAxisRaw("Vertical");
        _normalizeDirX = Input.GetAxisRaw("Horizontal");

        _isSpeedUp = Input.GetAxis("Run") > 0;
    }

    private void Movement()
    {
        _movementLogic.Movement(_normalizeDirZ, _normalizeDirX, _speed, _isSpeedUp);
    }

    private void Rotation()
    {
        _movementLogic.RotationBody(_normalizeRotY, _rotationSensetive, _rotationSpeed);
        CamLogic.RotationCamera(_normalizeRotX, _rotationSensetive, _rotationSpeed);
    }

    private void CompassActivated()
    {
        if (CompassController.Instance != null)
        {
            CompassController.Instance.CompassActivated();
        }
    }

    private void InitPauseController()
    {
        _pauseController = Instantiate(_pauseControllerPrefab).GetComponent<PauseController>();
    }
}
