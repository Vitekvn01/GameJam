using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.Events;

public class InteractionUIController : MonoBehaviour
{
    [SerializeField] private GameObject canvasInteraction;

    private GameObject canvas;

    [SerializeField] private float distance;

    private void Update()
    {
        ReycastInteraction();

    }


    private void ReycastInteraction()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit,distance))
        {
            if(hit.collider.gameObject.TryGetComponent<InteractionObject>(out InteractionObject interactionObject))
            {

                if(interactionObject.CheckState() == true)
                {
                    canvasInteraction.SetActive(true);
                }
                else if (interactionObject.CheckState() == false)
                {
                    canvasInteraction.SetActive(false);
                }
            }
            else
            {
                canvasInteraction.SetActive(false);
            }

        }
        else
        {
            canvasInteraction.SetActive(false);
        }
        

    }
}
