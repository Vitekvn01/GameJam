using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestComplete : MonoBehaviour
{
    [SerializeField] private Animator animationQuestComplite;

    public void FinishQuest()
    {
        // ¬ключаем анимацию.
        animationQuestComplite.enabled = true;
    }
}
