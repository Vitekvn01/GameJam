using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CompassLogic
{
    public CompassLogic(GameObject compassView, float time, float reloadTime, float radiusFind)
    {
        _compassView = compassView;
        _time = time;
        _reloadTime = reloadTime;
        _radiusFind = radiusFind;
    }

    private GameObject _compassView;

    private float _time;
    private float _reloadTime;
    private float _timer;

    private float _radiusFind;

    private bool _isActivated;

    private void RotateToTarget(GameObject target)
    {
        _compassView.transform.LookAt(target.transform.position, Vector3.up);
    }

    public void LookCompass(GameObject target)
    {
        if (_isActivated)
        {
            _timer += Time.deltaTime;

            RotateToTarget(target);
/*            Debug.Log(_timer + " чутьё " + _time);*/

            Debug.Log(Vector3.Distance(_compassView.transform.position, target.transform.position) <= _radiusFind);
            if (_timer >= _time || Vector3.Distance(_compassView.transform.position, target.transform.position) <= _radiusFind)
            {
                CompassHide();
                _isActivated = false;
                _timer = 0;
            }

        }
        else
        {
            _timer += Time.deltaTime;
            Debug.Log(_timer + " перезарядка " + _reloadTime);
        }
    }

    public void CompassAtivated()
    {
        if (_timer > _reloadTime && _isActivated == false)
        {
            _isActivated = true;
            CompassShow();
            _timer = 0;
        }

    }

    private void CompassShow()
    {
        _compassView.SetActive(true);
    }

    private void CompassHide()
    {
        _compassView.SetActive(false);
    }



}
