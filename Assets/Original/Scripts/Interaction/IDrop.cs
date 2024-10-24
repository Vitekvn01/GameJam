using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IDrop
{
    /// <summary>
    /// Метод интерфейса для выкидования предмета.
    /// </summary>
    void drop(Inventory inventory);
}
