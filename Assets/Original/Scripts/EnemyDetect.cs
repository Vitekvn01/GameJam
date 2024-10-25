using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class EnemyDetect : MonoBehaviour
{
    [SerializeField] private GameObject player;
    //[SerializeField] private int distance = 33;

    // Заметил ли бот врага.
    private bool angry = false;

    // Для сброса режима.
    private float timer; 

    // Для проверки зоны сбора, которая мешает рейкасту.
    private Interaction interaction;
    private CapsuleCollider capsuleCollider;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            angry = true;
        }
    }

    private void Update()
    {
        /*
        RaycastHit hit;
        // Рейкаст для отслеживания.
        if (Physics.Raycast(gameObject.transform.position, Vector3.forward, out hit, distance))
        {
            Debug.Log(hit.collider.gameObject);

            // Если заметили игрока -> переход в злой режим.
            if(hit.collider.gameObject == player)
            {
                angry = true; 
            }
          
        }

        Debug.Log(angry);

        */
        Debug.Log(angry);
    }

}
