using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    // �������� �� ��, ��� �� ��������� � ���� � ������� ����������.
    private bool searchIteam = false;

    // ������ �������� � ������� ������ � ���� � �������� ���������.
    private List<GameObject> objects = new List<GameObject>();


    // ���� � ���� ������ + ���������� ������� � ������.
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
    }

    
    // ����� �� ���� ������ + ����������� ������� �� ������.
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
    }

    /// <summary>
    /// ����������� ������� �� �� ������ �����.
    /// </summary>
    private void RaycastObject()
    {
        // ������� ��� �� ������ ������.
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // ��������� ������� ���������� IPickup.
            if (hit.collider.gameObject.TryGetComponent<IPickup>(out IPickup pickup) ||
                hit.collider.gameObject.TryGetComponent<IDrop>(out IDrop drop))
            {
                for (int i = 0; i < objects.Count; i++)
                {
                    // ��������� ������� �� �� �� ��� ������ � ��� ���� ���������.
                    if (hit.collider.gameObject == objects[i])
                    {
                        //��������� ������� ������.
                        if (Input.GetKeyDown(KeyCode.F))
                        {
                            // ��������� ���������� �� ������, ���������� ���.
                            IPickup pickupHit = hit.collider.gameObject.GetComponent<IPickup>();
                            IDrop dropHit = hit.collider.gameObject.GetComponent<IDrop>();

                            if (pickupHit != null)
                            {
                                // ����� � ������� ��������.
                                Inventory playerInventory = gameObject.GetComponentInParent<Inventory>();

                                if (playerInventory != null)
                                {
                                    pickupHit.pickup(playerInventory);

                                    //������� ������ �� ������.
                                    objects.RemoveAt(i);
                                }

                            }
                            else if (dropHit != null)
                            {
                                // ����� � ������� ��������.
                                Inventory playerInventory = gameObject.GetComponentInParent<Inventory>();

                                if (playerInventory != null)
                                {
                                    dropHit.drop(playerInventory);
                                    objects.RemoveAt(i);
                                }

                            }
                        }
                    }
                }
            }
        }
    }

    private void CheckObjects()
    {
        int counterObjects = 0;

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

    }
}
