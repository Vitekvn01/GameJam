using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestPerson : MonoBehaviour, IQuestPerson
{
    [SerializeField] private bool EndDialog = false;

    private bool ControllEndDialog = false;
    public void dialog()
    {
        // Если после побочного разговора надо выключить диалог EndDualog = true;
        /*
        if(ControllEndDialog == false)
        {
            // Бесконечное повторение диалога, если EndDualog == false;
            if (GetComponent<SubtitlesContainer>() != null)
            {
                GetComponent<SubtitlesContainer>().PlaySubtitlesContainer();
            }

            // Если диалог должен закончиться.
            if(EndDialog)
            {
                ControllEndDialog = true;
            }

        }
        */


        if (GetComponent<SubtitlesContainer>() != null)
        {
            GetComponent<SubtitlesContainer>().PlaySubtitlesContainer();
        }

    }
}
