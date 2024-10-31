using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestComplete : MonoBehaviour
{
    //[SerializeField] private Animator animationQuestComplite;

    [SerializeField] private GameObject questObject;
    private Animator animationQuestComplite;

    public void FinishQuest()
    {
        animationQuestComplite = questObject.GetComponent<Animator>();

        if (animationQuestComplite != null)
        {
            // ¬ключаем анимацию.
            animationQuestComplite.enabled = true;
        }

        if (questObject.TryGetComponent<InteractionObject>(out InteractionObject interactionObject))
        {
            Destroy(interactionObject);
        }


    }
}
