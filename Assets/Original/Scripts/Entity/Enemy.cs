using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(AIController))]
public class Enemy : Destructible
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rafiusAttack;
    [SerializeField] private float _damage;

    public AIController AIController { get; private set; }

    private void Awake()
    {
        SetAI();
        SetSpeed();
    }

    private void SetSpeed()
    {
        NavMeshAgent navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = _speed;
    }

    private void SetAI()
    {
        AIController = GetComponent<AIController>();
    }

    private void Start()
    {
        EnemyController.Instance.EnemyesList.Add(this);
    }

    private void OnDisable()
    {
        EnemyController.Instance.EnemyesList.Remove(this);
    }

}
