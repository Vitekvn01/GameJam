using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestPerson : MonoBehaviour, IQuestPerson
{
    public void dialog()
    {
        //GetComponent<SubtitlesContainer>().PlaySubtitlesContainer();

        Debug.Log("mather privet");
    }
}
