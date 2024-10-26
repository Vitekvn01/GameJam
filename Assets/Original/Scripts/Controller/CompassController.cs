using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CompassController : SingletonBase<CompassController>
{
    [SerializeField] private GameObject _target;
    [SerializeField] private GameObject _compass;

    [SerializeField] private float _time;
    [SerializeField] private float _reloadTime;

    [SerializeField] private float _radiusStopFind;

    private float _timer;

    private CompassLogic _compassLogic;

    private bool _isActivated;

    private void Start()
    {
        _compassLogic = new CompassLogic(_compass, _target);
    }

    private void Update()
    {
        if (_isActivated)
        {
            _timer += Time.deltaTime;

            _compassLogic.CompassIndicates();

            if (_timer >= _time || _compassLogic.CheckDistatanceToTarget(_radiusStopFind))
            {
                CompassDisactivated();
            }
        }
        else
        {
            _timer += Time.deltaTime;
        }

    }

    public void CompassActivated()
    {
        if (_timer > _reloadTime && _isActivated == false)
        {
            _isActivated = true;
            _compassLogic.CompassShow();
            AttractEnemy();
            _timer = 0;
        }

    }

    public void CompassDisactivated()
    {
        _compassLogic.CompassHide();
        _isActivated = false;
        _timer = 0;
    }

    public void SetTarget(GameObject target)
    {
        _target = target;
    }

    public void AttractEnemy()
    {
        EnemyController.Instance.SendNearestEnemy(transform.position);
    }

}
