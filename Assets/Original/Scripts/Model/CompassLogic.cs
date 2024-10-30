using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CompassLogic
{
    public CompassLogic(GameObject compassView)
    {
        _compassView = compassView;
    }

    private GameObject _compassView;
    private GameObject _target;


    private void RotateToTarget(GameObject target)
    {
        _compassView.transform.LookAt(target.transform.position, Vector3.up);
/*        _compassView.transform.localRotation = Quaternion.Euler(0, _compassView.transform.rotation.y, 0);*/
    }

    public void CompassIndicates(GameObject target)
    {
        if (target != null)
        {
            RotateToTarget(target);
        }

    }


    public void CompassShow()
    {
        _compassView.SetActive(true);
    }

    public void CompassHide()
    {
        _compassView.SetActive(false);
    }

    public bool CheckDistatanceToTarget(GameObject target, float radiusStopFind)
    {
       return Vector3.Distance(_compassView.transform.position, target.transform.position) <= radiusStopFind;
    }


}
