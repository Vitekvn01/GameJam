using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : SingletonBase<EnemyController>
{
    public List<Enemy> EnemyesList = new List<Enemy>();
    private Transform _playerTransform;

    void Start()
    {
        _playerTransform = PlayerController.Instance.transform;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private Enemy CheckNearestEnemy()
    {
        Enemy nearestEnemy = null;
        float minDistance = Mathf.Infinity;

        foreach (Enemy enemy in EnemyesList)
        {
            float distanceToPlayer = Vector3.Distance(_playerTransform.position, enemy.transform.position);

            if (distanceToPlayer < minDistance)
            {
                minDistance = distanceToPlayer;
                nearestEnemy = enemy;
            }
        }

        return nearestEnemy;
    }

    public void SendNearestEnemy(Vector3 pos)
    {
        CheckNearestEnemy().AIController.MoveToPos(pos);
    }
}
