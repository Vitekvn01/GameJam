using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour, IPickup
{
    public void pickup(Inventory inventory)
    {

        // ��������� ������ � ������ �� ��������.
        inventory.AddList(gameObject.name);
        // ���������� ������ ����� ������ � list
        Destroy(gameObject);
    }

}
