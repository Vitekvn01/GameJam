using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPickup
{
    /// <summary>
    /// Метод интерфейса для добавления предмета.
    /// </summary>
    void pickup(Inventory inventory);
}
