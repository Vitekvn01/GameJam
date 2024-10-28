using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HitController
{
    private GameObject player;
    public HitController(GameObject gameObject)
    {
        player = gameObject;
    }

    // Хит для поднятия.
    public void Hit(IPickup pickupInterfaceObject, List<GameObject> objects, int i)
    {
        // Берем с обьекта инветарь.
        Inventory playerInventory = player.GetComponentInParent<Inventory>();

        if (playerInventory != null)
        {
            pickupInterfaceObject.pickup(playerInventory);

            //Убираем обьект из списка.
            objects.RemoveAt(i);
        }
    }

    // Хит для отдачи.
    public void Hit(IDrop dropInterfaceObject, List<GameObject> objects, int i)
    {
        // Берем с обьекта инветарь.
        Inventory playerInventory = player.GetComponentInParent<Inventory>();

        if (playerInventory != null)
        {
            dropInterfaceObject.drop(playerInventory);

            //Убираем обьект из списка.
            objects.RemoveAt(i);
        }
    }
    // Хит для пряток.
    public void Hit(IHide HideInterfaceObject, List<GameObject> objects, int i)
    {
        // Берем с обьекта инветарь.
        Inventory playerInventory = player.GetComponentInParent<Inventory>();

        if (playerInventory != null)
        {
            HideInterfaceObject.Hide(player.transform.root.gameObject);


            //Убираем обьект из списка.
            objects.RemoveAt(i);
        }
    }
    // Хит для дверей.
    public void Hit(IDoorController doorObject, List<GameObject> objects, int i)
    {
        // Берем с обьекта инветарь.
        Inventory playerInventory = player.GetComponentInParent<Inventory>();

        if (playerInventory != null)
        {
            doorObject.useDoor(player.transform.root.gameObject);
        }
    }

    public void Hit(IQuestPerson questPerson, List<GameObject> objects, int i)
    {
        // Берем с обьекта инветарь.
        Inventory playerInventory = player.GetComponentInParent<Inventory>();

        if (playerInventory != null)
        {
            questPerson.dialog(player.transform.root.gameObject);
        }
    }
}
