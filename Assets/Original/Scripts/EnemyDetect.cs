using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyDetect : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private int distance = 33;

    private int layer = ~0; // Проверка всех слоев.
    private bool angry;     // Переход в режим преследования.

    private void Update()
    {
        RaycastHit hit;
        // Рейкаст для отслеживания.
        Ray ray = new Ray(gameObject.transform.position, transform.forward);

        // Проверка попадания
        if (Physics.Raycast(ray, out hit, distance, layer, QueryTriggerInteraction.Ignore))
        {
            Debug.Log(hit.collider.gameObject);                 // DBG

            // Если заметили игрока -> переход в злой режим.
            if (hit.collider.gameObject == player)
            {
                angry = true;
            }


            Debug.DrawLine(ray.origin, hit.point, Color.red);   // DBG
            Debug.Log(angry);                                   // DBG
        }
    }
}
