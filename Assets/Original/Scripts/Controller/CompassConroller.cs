using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassConroller : SingletonBase<CompassConroller>
{
    [SerializeField] private GameObject _target;
    [SerializeField] private GameObject _compass;

    [SerializeField] private float _time;
    [SerializeField] private float _reloadTime;

    [SerializeField] private float _radiusStopFind;

    private float _timer;

    private CompassLogic _compassLogic;

    private void Start()
    {
        _compassLogic = new CompassLogic(_compass, _time, _reloadTime, _radiusStopFind);
    }

    private void Update()
    {
        _compassLogic.LookCompass(_target);
    }

    public void ConpassAtivated()
    {
        _compassLogic.CompassAtivated();
    }

   /* private void CompassShow()
    {
        if (_timer >= _reloadTime && _isActivated == false)
        {
            _compass.SetActive(true);


        }

    }

    private void CompassHide()
    {
        _compass.SetActive(false);
        _isActivated = false;
    }

    private void CompassRotate()
    {
        if (_target != null)
        {
            _compassLogic.RotateToTarget(_compass, _target);
        }
    }*/

    public void SetTarget(GameObject target)
    {
        _target = target;
    }


}
