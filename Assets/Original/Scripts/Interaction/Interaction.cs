using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    // Проверка на то, что мы находимся в зоне с нужными предметами.
    private bool searchIteam = false;

    // Список обьектов с нужными тегами в зоне с которыми находимся.
    private List<GameObject> objects = new List<GameObject>();

    private HitController CheckHit;

    private void Start()
    {
        CheckHit = new HitController(gameObject);
    }

    // Вход в зону поиска + добавление обьекта в список.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<IPickup>(out IPickup pickup))
        {
            searchIteam = true;
            objects.Add(other.gameObject);
        }

        if (other.gameObject.TryGetComponent<IDrop>(out IDrop drop))
        {
            searchIteam = true;
            objects.Add(other.gameObject);
        }

        if(other.gameObject.TryGetComponent<IHide>(out IHide hide))
        {
            searchIteam = true;
            objects.Add(other.gameObject);
        }

        if (other.gameObject.TryGetComponent<IDoorController>(out IDoorController doorTry))
        {
            searchIteam = true;
            objects.Add(other.gameObject);
        }

        if(other.gameObject.TryGetComponent<IQuestPerson>(out IQuestPerson personTry))
        {
            searchIteam = true;
            objects.Add(other.gameObject);
        }
    }

    
    // Выход из зоны поиска + уничтожение обьекта из списка.
    private void OnTriggerExit(Collider other)
    {
        for (int i = 0; i < objects.Count; i++)
        {
            if (objects[i] == other.gameObject)
            {
                objects.Remove(objects[i]);
                CheckObjects();
            }
        }
    }

    private void Update()
    {
        if (searchIteam == true)
        {
            RaycastObject();
        }

        for (int i = 0; i < objects.Count; i++)
        {
            UnityEngine.Debug.Log(objects[i]);
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
            if (hit.collider.gameObject.TryGetComponent<IPickup>(out IPickup pickup) ||
                hit.collider.gameObject.TryGetComponent<IDrop>(out IDrop drop) ||
                hit.collider.gameObject.TryGetComponent<IHide>(out IHide hider) ||
                hit.collider.gameObject.TryGetComponent<IDoorController>(out IDoorController door) ||
                hit.collider.gameObject.TryGetComponent<IQuestPerson>(out IQuestPerson questPerson))
            {
                for (int i = 0; i < objects.Count; i++)
                {
                    UnityEngine.Debug.Log(hit.collider);

                    // Проверяем смотрим ли мы на тот обьект в чей зоне находимся.
                    if (hit.collider.gameObject == objects[i])
                    {
                        

                        //Проверяем нажатие кнопки.
                        if (Input.GetKeyDown(KeyCode.F))
                        {
                            // Проверяем подходящий ли обьект, записываем его.
                            IPickup pickupHit = hit.collider.gameObject.GetComponent<IPickup>();
                            IDrop dropHit = hit.collider.gameObject.GetComponent<IDrop>();
                            IHide hide = hit.collider.gameObject.GetComponent<IHide>();
                            IDoorController doorController = hit.collider.gameObject.GetComponent<IDoorController>();
                            IQuestPerson person = hit.collider.gameObject.GetComponent<IQuestPerson>();

                            if (pickupHit != null)
                            {
                                // Обработка попадания по обьекту.
                                CheckHit.Hit(pickupHit, objects, i);
                            }
                            else if (dropHit != null)
                            {
                                // Обработка поподания по обьекту.
                                CheckHit.Hit(dropHit, objects, i);
                            }
                            else if (hide != null)
                            {
                                CheckHit.Hit(hide, objects, i);
                            }
                            else if (doorController != null)
                            {
                                CheckHit.Hit(doorController, objects, i);
                            }
                            else if (person != null)
                            {
                                CheckHit.Hit(person, objects, i);
                            }
                        }
                    }
                }
            }
        }
    }

    private void CheckObjects()
    {
        //int counterObjects = 0;

        /*
        for (int i = 0; i < objects.Count; i++)
        {
            if (objects[i] != null)
            {
                counterObjects++;
            }
        }

        if(counterObjects == objects.Count)
        {
            searchIteam = false;
        }
        */

        if(objects.Count == 0)
        {
            searchIteam = false;
        }

    }
}
