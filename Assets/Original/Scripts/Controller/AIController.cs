using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public enum MovementState
{
    MoveToWaypoints,
    MoveToPosition,
    ChaseTarget
}
[RequireComponent(typeof(NavMeshAgent))]
public class AIController : MonoBehaviour
{
    private MovementState _movementState;


    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _distanceComplete = 2;


    private AILogic _logic;
    private NavMeshAgent _agent;


    private void Awake()
    {
        _agent = gameObject.GetComponent<NavMeshAgent>();
        _logic = new AILogic(_waypoints, _distanceComplete, _agent);
        SubscribeEvent();
    }


    private void Update()
    {
        switch (_movementState)
        {
            case MovementState.MoveToWaypoints:
                _logic.MovementByWaypoints();
                break;

            case MovementState.MoveToPosition:
                _logic.MovementToTargetPos();
                break;

            case MovementState.ChaseTarget:
                _logic.ChasingTarget();
                break;
        }
    }

    private void SubscribeEvent()
    {
        _logic.OnCompleteMoveToTarget += MoveToWaypoints;
    }

    private void UnsubscribeEvent()
    {
        _logic.OnCompleteMoveToTarget -= MoveToWaypoints;
    }

    public void MoveToPos(Vector3 pos)
    {
        _logic.SetTargetPos(pos);
        _movementState = MovementState.MoveToPosition;
        Debug.Log(_movementState + " " + gameObject.name);
    }

    public void MoveToWaypoints()
    {
        _movementState = MovementState.MoveToWaypoints;
        Debug.Log(_movementState + " " + gameObject.name);
    }

    public void ChasingTarget(Transform target)
    {
        _logic.SetTargetTranform(target);
        _movementState = MovementState.ChaseTarget;
        Debug.Log(_movementState + " " + gameObject.name);
    }

    private void OnDisable()
    {
        UnsubscribeEvent();
    }
}

