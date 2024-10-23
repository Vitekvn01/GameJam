using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour, IPickup,IDrop
{
    public void pickup(Inventory inventory)
    {
        // Добавляем обьект в список по названию.
        inventory.AddList(gameObject.name);
        Destroy(gameObject);
    }

    public void drop()
    {
        // Заглушка.
    }
}
