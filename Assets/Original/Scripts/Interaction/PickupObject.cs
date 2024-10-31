using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour, IPickup
{
    public static List<PickupObject> PickupObjects = new List<PickupObject>();

    private void Start()
    {
        PickupObjects.Add(this);
    }

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

    private void OnDisable()
    {
        PickupObjects.Remove(this);
    }
}
