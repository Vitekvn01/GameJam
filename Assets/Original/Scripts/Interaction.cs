using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    // Проверка на то, что мы находимся в зоне с нужными предметами.
    private bool searchIteam = false;

    // Список обьектов с нужными тегами в зоне с которыми находимся.
    private List<GameObject> objects = new List<GameObject>();


    // Вход в зону поиска + добавление обьекта в список.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<IPickup>(out IPickup pickup))
        {
            searchIteam = true;
            objects.Add(other.gameObject);
            UnityEngine.Debug.Log(other.gameObject);
        }
    }

    
    // Выход из зоны поиска + уничтожение обьекта из списка.
    private void OnTriggerExit(Collider other)
    {
        for (int i = 0; i < objects.Count; i++)
        {
            if (objects[i] == other.gameObject)
            {
                searchIteam = false;
            }
        }
    }

    private void Update()
    {
        if (searchIteam == true)
        {
            RaycastObject();
        }
    }

    /// <summary>
    /// Отслеживаем смотрим ли на нужный обект.
    /// </summary>
    private void RaycastObject()
    {
        // Создаем луч из центра камеры.
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // Проверяем наличие интерфейса IPickup.
            if(hit.collider.gameObject.TryGetComponent<IPickup>(out IPickup pickup)) 
            {
                //Проверяем нажатие кнопки.
                if (Input.GetKeyDown(KeyCode.F))
                {
                    // Проверяем подходящий ли обьект.
                    IPickup pickupHit = hit.collider.gameObject.GetComponent<IPickup>();

                    if(pickupHit != null)
                    {
                        // Берем с обьекта инветарь.
                        Inventory playerInventory = gameObject.GetComponentInParent<Inventory>();

                        if (playerInventory != null)
                        {
                            pickupHit.pickup(playerInventory);
                        }
                        
                    }
                    
                }
            }
            
        }
    }
}
