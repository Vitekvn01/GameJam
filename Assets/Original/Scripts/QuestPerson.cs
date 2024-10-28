using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestPerson : MonoBehaviour, IQuestPerson
{
    public void dialog(GameObject gameObject)
    {
        GetComponent<QuestPerson>().dialog(gameObject);
    }
}
