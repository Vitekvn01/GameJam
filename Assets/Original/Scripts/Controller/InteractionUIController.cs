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
    private DialogController dialogController;

    private void Start()
    {
        dialogController = GetComponentInParent<DialogController>();
    }

    private void Update()
    {
        ReycastInteraction();

        Debug.Log(dialogController.GetDialog());

        /*
        if (dialogController != null)
        {
            if (dialogController.GetDialog() == true)
            {
                canvasInteraction.SetActive(false);
            }
        }
        */

    }

    private void ReycastInteraction()
    {
        /*
        if (dialogController != null)
        {
            if (dialogController.GetDialog() == true) return;
        }
        */

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit,distance))
        {
            if(hit.collider.gameObject.TryGetComponent<InteractionObject>(out InteractionObject interactionObject))
            {
                if(dialogController.GetDialog() == true)
                {
                    if(hit.collider.gameObject.TryGetComponent<QuestPerson>(out QuestPerson quest))
                    {
                        canvasInteraction.SetActive(false);
                        return;
                    }
                }

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
