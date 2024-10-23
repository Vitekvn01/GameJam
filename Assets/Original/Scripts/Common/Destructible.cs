using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Destructible : MonoBehaviour
{
    public UnityEvent OnDeadEvent;
    public static UnityEvent OnStaticDeadEvent = new UnityEvent();
    [SerializeField] private float health = 100;


    public virtual void TakeDamage(float strong)
    {
        health = health - strong;
        if (health <= 0)
        {
            Die();
            OnDeadEvent.Invoke();
            OnStaticDeadEvent.Invoke();
        }
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }
}
