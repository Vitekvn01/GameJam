using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CompassController : SingletonBase<CompassController>
{
    [SerializeField] private GameObject _viewUIPrefab;
    [SerializeField] private GameObject _target;
    [SerializeField] private GameObject _compass;

    [SerializeField] private float _time;
    [SerializeField] private float _reloadTime;

    [SerializeField] private float _radiusStopFind;

    private float _timer;

    private CompassLogic _compassLogic;
    private ViewUICompass _viewUICompass;

    [SerializeField] private bool _isActivated;

    private void Start()
    {
        _compassLogic = new CompassLogic(_compass);
        ViewUIInit();
        _viewUICompass.SetGray();
    }

    private void Update()
    {
        if (PickupObject.PickupObjects != null)
        {
            FindObject();
        }


        if (_isActivated)
        {

            _timer += Time.deltaTime;
            if (_target != null)
            {
                _compassLogic.CompassIndicates(_target);
            }


            if (_timer >= _time || _compassLogic.CheckDistatanceToTarget(_target, _radiusStopFind))
            {
                CompassDisactivated();
            }
        }
        else
        {
            _timer += Time.deltaTime;
            if (_timer > _reloadTime)
            {
                if (_viewUICompass != null)
                {
                    _viewUICompass.ResetColor();
                }

            }
        }

    }

    public void CompassActivated()
    {
        if (_timer > _reloadTime && _isActivated == false && _target != null)
        {
            _isActivated = true;
            _compassLogic.CompassShow();
            AttractEnemy();
            _timer = 0;
        }

    }

    public void CompassDisactivated()
    {
        _viewUICompass.SetGray();
        _compassLogic.CompassHide();
        _isActivated = false;
        _timer = 0;
    }

    public void SetTarget(GameObject target)
    {
        _target = target;
    }

    private void ViewUIInit()
    {
        _viewUICompass = Instantiate(_viewUIPrefab).GetComponent<ViewUICompass>();

    }

    public void AttractEnemy()
    {
        if (EnemyController.Instance != null)
        {
            //EnemyController.Instance.SendNearestEnemy(transform.position);
        }
    }

    public void FindObject()
    {
             GameObject nearestQuestObject = null;

            float minDistance = Mathf.Infinity;

            foreach (PickupObject pickupObject in PickupObject.PickupObjects)
            {
                float distanceToPlayer = Vector3.Distance(_compass.transform.position, pickupObject.gameObject.transform.position);

                if (distanceToPlayer < minDistance)
                {
                    minDistance = distanceToPlayer;
                    nearestQuestObject = pickupObject.gameObject;
                }
            }

        if (nearestQuestObject != null)
        {
            _target = nearestQuestObject;
        }
            
    }
}

