using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InteractionUIController : MonoBehaviour
{
    [SerializeField] private GameObject canvasInteraction;

    private TextMeshProUGUI text;

    private GameObject canvas;

    [SerializeField] private float distance;
    private DialogController dialogController;

    private void Start()
    {
        dialogController = GetComponentInParent<DialogController>();
        text = canvasInteraction.GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Update()
    {
        ReycastInteraction();
    }


    public void SetUiController(string stringText)
    {
        if(text != null)
        {
            text.text = stringText;
        }
    }

    private void ReycastInteraction()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit,distance))
        {
            // Проверяем, что обьект надо отображать.
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

                    // Изменение текста, если надо прятаться и возвращаем обратно если нет.
                    if (hit.collider.gameObject.TryGetComponent<HidePlace>(out HidePlace hide))
                    {
                        if (text != null)
                        {
                            text.text = "E - Спрятаться";
                        }
                    }
                    else
                    {
                        text.text = "F - Взаимодействие";
                    }
                        
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
