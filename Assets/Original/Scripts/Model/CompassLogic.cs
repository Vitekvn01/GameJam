using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CompassLogic
{
    public CompassLogic(GameObject compassView, GameObject target)
    {
        _compassView = compassView;
        _target = target;
    }

    private GameObject _compassView;
    private GameObject _target;


    private void RotateToTarget(GameObject target)
    {
        _compassView.transform.LookAt(target.transform.position, Vector3.up);
    }

    public void CompassIndicates()
    {
        RotateToTarget(_target);
    }


    public void CompassShow()
    {
        _compassView.SetActive(true);
    }

    public void CompassHide()
    {
        _compassView.SetActive(false);
    }

    public bool CheckDistatanceToTarget(float radiusStopFind)
    {
       return Vector3.Distance(_compassView.transform.position, _target.transform.position) <= radiusStopFind;
    }


}
