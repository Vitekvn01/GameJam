using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class AILogic
{
    public AILogic(Transform[] waypoints, float distanceComplete, NavMeshAgent agent)
    {
        _waypoints = waypoints;
        _distanceComplete = distanceComplete;
        _agent = agent;
    }


    private Transform[] _waypoints;
    private Transform _target;

    private Vector3 _targetPos;

    private float _distanceComplete = 2;
    private int _currentWaypoint = 0;

    private NavMeshAgent _agent;

    public event Action OnCompleteMoveToTarget;

    #region MovementToPos
    private void MoveToTarget()
    {
        _agent.destination = _targetPos;
    }
    public void SetTargetPos(Vector3 pos)
    {
        _targetPos = pos;
    }


    public void MovementToTargetPos()
    {
        MoveToTarget();

        if (CopmleteWaypoint(_targetPos, _distanceComplete))
        {
            OnCompleteMoveToTarget.Invoke();
        }
    }

    #endregion


    #region Chasing
    public void SetTargetTranform(Transform target)
    {
        _target = target;
    }


    public void ChasingTarget()
    {
        _agent.destination = _target.position;
    }

    #endregion

    #region WaypointsMovement
    private void MoveToWaypoint(Transform waypoint)
    {
        _agent.destination = waypoint.position;
    }

    private bool CopmleteWaypoint(Vector3 pos, float distanceComplete)
    {

        return (Vector3.Distance(_agent.gameObject.transform.position, pos) < distanceComplete);

    }

    public void MovementByWaypoints()
    {
        MoveToWaypoint(_waypoints[_currentWaypoint]);

        if (CopmleteWaypoint(_waypoints[_currentWaypoint].transform.position, _distanceComplete))
        {
            if (_currentWaypoint < _waypoints.Length - 1)
            {
                _currentWaypoint++;
            }
            else
            {
                _currentWaypoint = 0;
            }
        }
    }

    #endregion


}
