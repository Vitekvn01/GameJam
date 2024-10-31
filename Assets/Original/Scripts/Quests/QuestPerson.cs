using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestPerson : MonoBehaviour, IQuestPerson
{



    public void dialog()
    {
        if (GetComponent<SubtitlesContainer>() != null)
        {
            GetComponent<SubtitlesContainer>().PlaySubtitlesContainer();
        }
    }
}
