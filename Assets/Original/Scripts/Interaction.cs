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
            UnityEngine.Debug.Log(other.gameObject);
        }
    }

    
    // ����� �� ���� ������ + ����������� ������� �� ������.
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
            if(hit.collider.gameObject.TryGetComponent<IPickup>(out IPickup pickup)) 
            {
                //��������� ������� ������.
                if (Input.GetKeyDown(KeyCode.F))
                {
                    // ��������� ���������� �� ������.
                    IPickup pickupHit = hit.collider.gameObject.GetComponent<IPickup>();

                    if(pickupHit != null)
                    {
                        // ����� � ������� ��������.
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
