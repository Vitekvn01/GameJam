using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyDetect : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private int distance = 33;
    private AIController _aIController;

    private int layer = ~0; // Проверка всех слоев.
    private bool angry;     // Переход в режим преследования.

    private void Start()
    {
        _aIController = GetComponent<AIController>();

        if(_aIController == null) // !!!!!!!!!!!!!
        {
            _aIController = GetComponentInParent<AIController>();
        }
    }

    private void Update()
    {

        if (player.activeSelf == false)
        {
            angry = false;
        }


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
                //_aIController.MoveToPos(player.transform.position);
            }


            Debug.DrawLine(ray.origin, hit.point, Color.red);   // DBG
            Debug.Log(angry);                                   // DBG
        }

        if(angry == true)
        {
            _aIController.MoveToPos(player.transform.position);
        }
    }
}
