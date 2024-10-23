using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCamLogic 
{

    private float _currentXRotation = 0f;
    private GameObject _camObject;
    public FPSCamLogic(GameObject playerCam)
    {
        _camObject = playerCam;

    }

    public void RotationCamera(float dirRotX, float sensetive, float rotSpeed)
    {
        float rotationAmount = dirRotX * sensetive * rotSpeed;

        _currentXRotation -= rotationAmount;
        _currentXRotation = Mathf.Clamp(_currentXRotation, -90f, 90f);

        _camObject.transform.localRotation = Quaternion.Euler(_currentXRotation, _camObject.transform.localEulerAngles.y, 0f);
    }

}
