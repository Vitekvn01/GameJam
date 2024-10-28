using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour, IPickup
{
    public void pickup(Inventory inventory)
    {
        if (gameObject.TryGetComponent(out SubtitlesContainer Subtitles))
        {
            Subtitles.PlaySubtitlesContainer();
        }
        // Добавляем обьект в список по названию.
        inventory.AddList(gameObject.name);
        // Уничтожаем обьект после записи в list
        Destroy(gameObject);
    }

}
