using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AILogic
{
    public AILogic(Transform[] waypoints, float distanceComplete, NavMeshAgent agent)
    {
        _waypoints = waypoints;
        _distanceComplete = distanceComplete;
        _agent = agent;
    }


    private Transform[] _waypoints;

    private float _distanceComplete = 2;

    private int _currentWaypoint = 0;

    private NavMeshAgent _agent;

    public void StartMovementPath()
    {
        if (_waypoints.Length > 0)
        {
            MoveToWaypoint(_waypoints[_currentWaypoint]);
        }
    }

    private void SetCurrentWaypoint(int indexWaypoint)
    {
        _currentWaypoint = indexWaypoint;
    }

    private void MoveToWaypoint(Transform waypoint)
    {
        _agent.destination = waypoint.position;
    }

    private bool CopmleteWaypoint(float distanceComplete)
    {
        if (_waypoints.Length > 0)
        {
            Debug.Log((Vector3.Distance(_agent.gameObject.transform.position, _waypoints[_currentWaypoint].position) < distanceComplete));
            return (Vector3.Distance(_agent.gameObject.transform.position, _waypoints[_currentWaypoint].position) < distanceComplete);
        }
        else return false;

    }

    public void MovementPath()
    {
        if (CopmleteWaypoint(_distanceComplete))
        {
            if (_currentWaypoint < _waypoints.Length - 1)
            {
                _currentWaypoint++;
                MoveToWaypoint(_waypoints[_currentWaypoint]);
            }
            else
            {
                _currentWaypoint = 0;
                MoveToWaypoint(_waypoints[_currentWaypoint]);
            }
        }
    }
}
