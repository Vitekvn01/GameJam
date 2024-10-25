using System;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _distanceComplete = 2;


    private AILogic _logic;
    private NavMeshAgent _agent;

    private void Awake()
    {
        _agent = gameObject.GetComponent<NavMeshAgent>();
        _logic = new AILogic(_waypoints, _distanceComplete, _agent);
    }

    private void Start()
    {
        _logic.StartMovementPath();
    }

    private void Update()
    {
        _logic.MovementPath();
    }


}

