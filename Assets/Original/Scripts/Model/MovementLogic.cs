using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementLogic
{
    public MovementLogic(GameObject playerObject)
    {
        _object = playerObject;
        _rb = playerObject.GetComponent<Rigidbody>();
    }

    private GameObject _object;
    private Rigidbody _rb;

    public void Movement(float dirZ, float dirX, float speed, bool SpeedUp)
    {
        Vector3 gravity = new Vector3(0, _rb.velocity.y, 0);
        _rb.velocity = gravity + DirectionMove(dirZ, dirX) * speed * speedUp(SpeedUp) * Time.fixedDeltaTime;
    }

    public void RotationBody(float dirRotX, float sensetive, float rotSpeed)
    {
        _object.transform.Rotate(DirectionRotation(dirRotX, sensetive) * rotSpeed);
    }


    private Vector3 DirectionMove(float inputZ, float inputX)
    {
        Vector3 direction = Vector3.zero;
        return direction += _object.transform.forward * (inputZ) + _object.transform.right * (inputX);
    }

    private Vector3 DirectionRotation(float input, float sensitive)
    {
        return _object.transform.up * (input * sensitive);
    }

    private float speedUp(bool isSpeedUp)
    {
        if (isSpeedUp)
        {
            return 2;
        }
        else return 1;
    }

}
