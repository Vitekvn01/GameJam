using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestPerson : MonoBehaviour, IQuestPerson
{
    [SerializeField] private bool endDialog = false;

    [SerializeField] private GameObject canvasObject;

    public void dialog()
    {
        
        if (endDialog == true)
        {
            canvasObject.SetActive(true);
            return;
        }
        
        if (GetComponent<SubtitlesContainer>() != null)
        {
            GetComponent<SubtitlesContainer>().PlaySubtitlesContainer();
        }
    }
}
